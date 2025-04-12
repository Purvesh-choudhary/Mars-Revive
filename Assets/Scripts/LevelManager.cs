using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public List<BaseHealth> allBases;
    [SerializeField] GameObject levelCompletePanel, hudPanel;

    [SerializeField] TextMeshProUGUI scoreUI;
    int score;
    
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
    }

    void Start()
    {
        score = 0;
        UpdateScore(0);
        // Optional: automatically populate if needed
        allBases.AddRange(FindObjectsOfType<BaseHealth>());
    }

    void BaseDestroyedHandler(BaseHealth destroyedBase)
    {
        allBases.Remove(destroyedBase);

        if (allBases.Count == 0)
        {
            Debug.Log("Level Complete!");
            levelCompletePanel.SetActive(true);
            hudPanel.SetActive(false);
            // Load next level or show win UI
        }
    }

    public void UpdateScore(int newScore){
        score += newScore; 
        scoreUI.text = score.ToString();
    }
}
