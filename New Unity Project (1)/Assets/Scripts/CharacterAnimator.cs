using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
*/

/// <summary>
///
/// </summary>

public class CharacterAnimator : MonoBehaviour
{
    public AnimationClip replacebleAttackAnim;
    public AnimationClip[] defaultAttackAnimSet;
    protected AnimationClip[] currentAttackAnimSet;
    const float locomationAnimationSmoothTime = .1f;

    NavMeshAgent agent;
    protected Animator animator;
    protected CharacterCombat combat;
    public AnimatorOverrideController overrideController;
    protected virtual void Start()
    {
        
        agent = this.GetComponent<NavMeshAgent>();
        animator = this.GetComponentInChildren<Animator>();
        combat = GetComponent<CharacterCombat>();
        if(overrideController == null)
        {
            overrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        }
        animator.runtimeAnimatorController = overrideController;
        currentAttackAnimSet = defaultAttackAnimSet;
        combat.OnAttack += OnAttack;
    }

    protected virtual void Update()
    {
        float speedPercent = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("speedPercent", speedPercent, locomationAnimationSmoothTime, Time.deltaTime);
        animator.SetBool("inCombat", combat.inCombat);
    }

    protected virtual void OnAttack()
    {
        animator.SetTrigger("attack");
        int attackIndex = Random.Range(0, currentAttackAnimSet.Length);
        overrideController[replacebleAttackAnim.name] = currentAttackAnimSet[attackIndex];

    }
}
