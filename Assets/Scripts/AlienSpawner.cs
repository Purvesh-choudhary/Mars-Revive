using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform[] spawnPoints;

    public void SpawnEnemy()
    {
        int enemy = Random.Range(0, enemyPrefabs.Length);
        int index = Random.Range(0, spawnPoints.Length);
        Instantiate(enemyPrefabs[enemy], spawnPoints[index].position, Quaternion.identity);
    }
}
