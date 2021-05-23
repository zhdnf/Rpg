using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*/

/// <summary>
///
/// </summary>


[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    public float attackSpeed  = 1f;
    private float attackCooldown = 0f;

    public float attackDelay = .6f;

    public event System.Action OnAttack;

    CharacterStats myStats;

    private void Update()
    {
        attackCooldown -= Time.deltaTime;    
    }

    private void Start()
    {
        myStats = GetComponent<CharacterStats>();
    }

    public void Attack(CharacterStats targetStats)
    {
        if(attackCooldown <= 0f)
        {
            StartCoroutine(DoDamge(myStats, attackDelay));
            attackCooldown = 1f / attackSpeed;
        }

        if(OnAttack != null)
        {
            OnAttack.Invoke();
        }
        
    }

    IEnumerator DoDamge(CharacterStats stats, float delay)
    {
        yield return new WaitForSeconds(delay);
        stats.TakeDamage(myStats.damage.GetValue());

    }
}
