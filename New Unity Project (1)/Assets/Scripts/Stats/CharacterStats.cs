using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*/

/// <summary>
///
/// </summary>

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth
    {
        get;
        private set;
    }

    public Stat damage;
    public Stat armour;

    public event System.Action<int, int> OnHealthChanged;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }

 
    // 被攻击
    public void TakeDamage(int damage)
    {
        damage -= armour.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage");

        if (OnHealthChanged != null)
        {
            OnHealthChanged.Invoke(maxHealth, currentHealth);
        }

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        //Die in some way
        // this method is meant to be overwritten
        Debug.Log(transform.name + " Die");
    }
}
