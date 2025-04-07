using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSmall : AlienBase
{
    protected override void Attack()
    {
        Debug.Log("Small alien bites!");
        player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
    }

    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount * 1.2f); // Takes extra damage
    }
}
