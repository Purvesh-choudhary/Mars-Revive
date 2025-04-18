using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class AlienGiant : AlienBase
{
    public float smashDelayTimer;
    [SerializeField] ParticleSystem smashFx;

    protected override void Attack()
    {
        //animator.SetBool("isWalking",false);
        Debug.Log("Giant alien smashes hard!");
        StartCoroutine(OnSmash(smashDelayTimer));
        // Optional: Add screen shake / ground slam FX
    }

    private IEnumerator OnSmash(float DelayTimer){
        yield return new WaitForSeconds(DelayTimer);
        gameObject.GetComponent<CinemachineImpulseSource>()?.GenerateImpulse();
        if (distance <= (attackRange+2f))
        {
            if(audioSource.clip != SmashAudio){
                audioSource.clip = SmashAudio;
                audioSource.spatialBlend = 0f;
            }
            
            if(!audioSource.isPlaying){
                audioSource.PlayOneShot(audioSource.clip ,1);
            }
            Instantiate(smashFx, transform.position, Quaternion.identity);
            player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
        }
    }
    
}
