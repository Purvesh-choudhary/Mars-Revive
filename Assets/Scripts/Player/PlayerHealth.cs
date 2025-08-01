using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100;
    private float currentHealth;
    [SerializeField] private TextMeshProUGUI healthUI;

    [Header("Damage On UI")]
    [SerializeField] Image healthHigh; 
    [SerializeField] Image healthMid, healthLow;
    [SerializeField] float highMax=80f ,midMax=50f ,lowMax=20f;

    [SerializeField] GameObject gameOverPanel;

    // void Start() => currentHealth = maxHealth;
    void Start(){
        currentHealth = maxHealth;
        UpdateHealthOnUI(currentHealth);
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        healthUI.text = ((int)currentHealth).ToString();
        UpdateHealthOnUI(currentHealth);
        if (currentHealth <= 0)
        {
            healthUI.text = "0";
            Debug.Log("Player Dead");
            gameOverPanel.SetActive(true);
            // Game Over
        }
    }

    private void UpdateHealthOnUI(float currentHealth)
    {
        if(currentHealth >= highMax){
            SetImageAlpha(healthHigh,0f);
            SetImageAlpha(healthMid,0f);
            SetImageAlpha(healthLow,0f);
        }
        else if(currentHealth >= midMax){
            float alphaHigh = Mathf.InverseLerp(highMax,midMax,currentHealth);
            SetImageAlpha(healthHigh,alphaHigh);
        }
        else if(currentHealth >= lowMax){
            SetImageAlpha(healthHigh,1f);
            float alphaMid = Mathf.InverseLerp(midMax,lowMax,currentHealth);
            SetImageAlpha(healthMid,alphaMid);
        }
        else{
            SetImageAlpha(healthHigh,1f);
            SetImageAlpha(healthMid,1f);
            float alphaLow = Mathf.InverseLerp(lowMax,0,currentHealth);
            SetImageAlpha(healthLow,alphaLow);
        }

    }

    void SetImageAlpha(Image img , float alpha){
        Color c = img.color;
        c.a = alpha;
        img.color = c;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("DropUp")){
            Debug.Log("COLLECTED DROP BOX");
            DropUp dropUp = other.GetComponent<DropUp>();
            if(dropUp.dropType == DropUp.Droptype.health){
                currentHealth += dropUp.dropQuantity;
                if(currentHealth >100) currentHealth = 100;
            }

            healthUI.text = ((int)currentHealth).ToString();
            dropUp.DropCollectFX();
            Destroy(other.gameObject);
        }
    }
}

