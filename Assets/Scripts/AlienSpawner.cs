using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AlienSpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform[] spawnPoints;
    public int maxEnemiesInScene = 10;
    [SerializeField] TextMeshProUGUI enemiesinscene;

    private List<GameObject> weightedEnemies = new List<GameObject>();

    public bool canSpawn = true;

    void Start()
    {   
        // SMALL
        weightedEnemies.Add(enemyPrefabs[0]);
        weightedEnemies.Add(enemyPrefabs[0]);
        weightedEnemies.Add(enemyPrefabs[0]);
        weightedEnemies.Add(enemyPrefabs[0]);
        // MID
        weightedEnemies.Add(enemyPrefabs[1]);
        weightedEnemies.Add(enemyPrefabs[1]);
        // GIANT
        weightedEnemies.Add(enemyPrefabs[2]); 
    }


    void Update()
    {
        int currentEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        enemiesinscene.text = currentEnemies.ToString();                // Debug 🚨
        if (currentEnemies < maxEnemiesInScene && canSpawn){
            SpawnEnemy();
        }

        // Vector3 rand apoja = new Vector3(Random.Range)
    }

    public void SpawnEnemy()
    {
        // int enemy = Random.Range(0, enemyPrefabs.Length);
        // int index = Random.Range(0, spawnPoints.Length);
        // Instantiate(enemyPrefabs[enemy], spawnPoints[index].position, Quaternion.identity);

        int enemyIndex = Random.Range(0, weightedEnemies.Count);
        int spawnIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(weightedEnemies[enemyIndex], spawnPoints[spawnIndex].position, Quaternion.identity);
    
    }
}
