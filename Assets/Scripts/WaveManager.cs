using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public AlienSpawner spawner;
    public int enemiesPerWave = 5;

    public void SpawnWave(int noOfAliens)
    {
        enemiesPerWave = noOfAliens;
        for (int i = 0; i < enemiesPerWave; i++)
        {
            spawner.SpawnEnemy();
        }
    }
}
