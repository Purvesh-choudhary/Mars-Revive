using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    [SerializeField] int lvlIndex;
    public List<BaseHealth> allBases;
    public List<EnergyBall> allEnergyBalls;

    // UI RELATED 
    [SerializeField] GameObject levelCompletePanel, hudPanel, finalEnemyPanel;
    [SerializeField] TextMeshProUGUI scoreUI, finalScoreUI , finalEnemyCounts;
    int score;
    //  // DEBUGS 🚨
    [SerializeField] TextMeshProUGUI basesCounterDebug , energyballCounterDebug , hintText;

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


    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        if(allBases.Count == 0 && allEnergyBalls.Count == 0){
            hintText.gameObject.SetActive(true);
            hintText.text =  "Clear the Area!";
            finalEnemyPanel.SetActive(true);
            finalEnemyCounts.text = alienSpawner.GetCurrentEnemies().ToString();
            if(alienSpawner.GetCurrentEnemies() <= 0){
                LevelComplete();
            }
        }

        if(allBases.Count > 0 && allEnergyBalls.Count == 0){
            hintText.gameObject.SetActive(true);
            hintText.text =  allBases.Count + " Base Left!";
        }
        

    }

    void BaseDestroyedHandler(BaseHealth destroyedBase)
    {
        allBases.Remove(destroyedBase);
        basesCounterDebug.text = allBases.Count.ToString();  // Debug 🚨
        // if (allBases.Count == 0)
        // {
        //     LevelComplete();
        //     // Load next level or show win UI
        // }
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

    void LevelComplete(){
        Debug.Log("Level Complete!");
        levelCompletePanel.SetActive(true);
        hudPanel.SetActive(false);
        finalEnemyPanel.SetActive(false);
        finalScoreUI.text = score.ToString();
        GameManager.Instance.LevelComplete(score, lvlIndex);
    }


    public void NextLevel(){
        GameManager.Instance.NextLevel();
    }

}
