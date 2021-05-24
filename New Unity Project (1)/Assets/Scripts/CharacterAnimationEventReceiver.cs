using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*/

/// <summary>
///
/// </summary>

public class CharacterAnimationEventReceiver : MonoBehaviour
{
    public CharacterCombat combat;
    
    
    
    public void AttackHitEvent()
    {
        combat.AttackHit_AnimationEvent();
    }
}
