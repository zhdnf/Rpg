using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
*/

/// <summary>
///
/// </summary>

public class CharactorAnimation : MonoBehaviour
{
    const float locomationAnimationSmoothTime = .1f;

    NavMeshAgent agent;
    Animator animator;
    private void Start()
    {
        
        agent = this.GetComponent<NavMeshAgent>();
        animator = this.GetComponentInChildren<Animator>();
        
    }

    private void Update()
    {
        float speedPercent = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("speedPercent", speedPercent, locomationAnimationSmoothTime, Time.deltaTime);
    }
}
