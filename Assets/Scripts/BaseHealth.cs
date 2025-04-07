using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    public float maxHealth = 100f;
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

        if (currentHealth <= 0)
        {
            OnBaseDestroyed?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
