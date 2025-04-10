using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienGiant : AlienBase
{
    protected override void Attack()
    {
        animator.SetBool("isWalking",false);
        Debug.Log("Giant alien smashes hard!");
        player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
        // Optional: Add screen shake / ground slam FX
    }
}
