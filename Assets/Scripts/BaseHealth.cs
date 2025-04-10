using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    [SerializeField] ParticleSystem halfDamageFx , fullDamageFx;
    private float currentHealth;

    public delegate void BaseDestroyed(BaseHealth baseHealth);
    public static event BaseDestroyed OnBaseDestroyed;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if(currentHealth <= (maxHealth/2)){
            halfDamageFx.gameObject.SetActive(true);
        }

        if (currentHealth <= 0)
        {
            OnBaseDestroyed?.Invoke(this);
            Destroy(halfDamageFx.gameObject);
            fullDamageFx.transform.SetParent(null, true);
            fullDamageFx.gameObject.SetActive(true);
            fullDamageFx.GetComponent<CinemachineImpulseSource>()?.GenerateImpulse();
            Destroy(gameObject);
        }
    }
}
