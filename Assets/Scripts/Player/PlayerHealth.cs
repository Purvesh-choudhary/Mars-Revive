using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    [SerializeField] private TextMeshProUGUI healthUI;

    void Start() => currentHealth = maxHealth;

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthUI.text = currentHealth.ToString();
        if (currentHealth <= 0)
        {
            healthUI.text = "GAME OVER";
            Debug.Log("Player Dead");
            // Game Over
        }
    }
}

