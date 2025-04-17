using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public List<BaseHealth> allBases;
    public List<EnergyBall> allEnergyBalls;

    // UI RELATED 
    [SerializeField] GameObject levelCompletePanel, hudPanel;
    [SerializeField] TextMeshProUGUI scoreUI;
    int score;
    //  // DEBUGS 🚨
    [SerializeField] TextMeshProUGUI basesCounterDebug , energyballCounterDebug;

    [SerializeField] Slider energySlider;
    float energyPerBall;

    AlienSpawner alienSpawner;
    
    
    void OnEnable()
    {
        BaseHealth.OnBaseDestroyed += BaseDestroyedHandler;
    }

    void OnDisable()
    {
        BaseHealth.OnBaseDestroyed -= BaseDestroyedHandler;
    }

    private void Awake()
    {
        if(Instance == null){
            Instance = this;
        }    
        alienSpawner = FindObjectOfType<AlienSpawner>();
    }

    void Start()
    {
        score = 0;
        UpdateScore(0);
        // Optional: automatically populate if needed
        allBases.AddRange(FindObjectsOfType<BaseHealth>());
        allEnergyBalls.AddRange(FindObjectsOfType<EnergyBall>());

        basesCounterDebug.text = allBases.Count.ToString();  // Debug 🚨
        energyballCounterDebug.text = allEnergyBalls.Count.ToString();  // Debug 🚨

        energyPerBall = 100 / allEnergyBalls.Count;
        energySlider.value = 0;
        
    }

    void BaseDestroyedHandler(BaseHealth destroyedBase)
    {
        allBases.Remove(destroyedBase);
        basesCounterDebug.text = allBases.Count.ToString();  // Debug 🚨
        if (allBases.Count == 0)
        {
            Debug.Log("Level Complete!");
            levelCompletePanel.SetActive(true);
            hudPanel.SetActive(false);

            // Load next level or show win UI
        }
    }

    public void EnergyBallCollected(EnergyBall collectedEnergyBall){
        allEnergyBalls.Remove(collectedEnergyBall);
        energyballCounterDebug.text = allEnergyBalls.Count.ToString();  // Debug 🚨
        energySlider.value += energyPerBall;
        if(allEnergyBalls.Count == 0){
            alienSpawner.canSpawn = false;
        }
    }

    public void UpdateScore(int newScore){
        score += newScore; 
        scoreUI.text = score.ToString();
    }
}
