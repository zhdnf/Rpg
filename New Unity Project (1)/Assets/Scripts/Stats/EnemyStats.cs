using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*/

/// <summary>
///
/// </summary>

public class EnemyStats : CharacterStats
{
    public override void Die()
    {
        base.Die();

        // Add ragdoll effect / death animation

        Destroy(this.gameObject);
    }
}
