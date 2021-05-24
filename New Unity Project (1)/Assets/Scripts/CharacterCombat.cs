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
    const float combatCooldown = 5f;
    float lastAttackTime;

    public float attackDelay = .6f;

    public bool inCombat { get; private set; }
    public event System.Action OnAttack;

    CharacterStats myStats;
    CharacterStats opponentStats;
    private void Update()
    {
        attackCooldown -= Time.deltaTime;    
        if(Time.time - lastAttackTime > combatCooldown)
        {
            inCombat = false;
        }
    }

    private void Start()
    {
        myStats = GetComponent<CharacterStats>();
    }

    public void Attack(CharacterStats targetStats)
    {
        if(attackCooldown <= 0f)
        {
            //StartCoroutine(DoDamge(myStats, attackDelay));
            opponentStats = targetStats;
            if (OnAttack != null)
            {
                OnAttack.Invoke();
            }

            attackCooldown = 1f / attackSpeed;
            inCombat = true;
            lastAttackTime = Time.time;
        }


        
    }

    //IEnumerator DoDamge(CharacterStats stats, float delay)
    //{
    //    yield return new WaitForSeconds(delay);
    //    stats.TakeDamage(myStats.damage.GetValue());
    //    if(stats.currentHealth <= 0)
    //    {
    //        inCombat = false;
    //    }
    //}

    public void AttackHit_AnimationEvent()
    {
        opponentStats.TakeDamage(myStats.damage.GetValue());
        if (opponentStats.currentHealth <= 0)
        {
            inCombat = false;
        }
    }
}
