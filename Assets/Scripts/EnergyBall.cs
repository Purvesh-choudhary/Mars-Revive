using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall : MonoBehaviour
{
    public WaveManager waveManager;
    [SerializeField] private int noOfAliens = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            waveManager.SpawnWave(noOfAliens); // Trigger wave spawn
            Destroy(gameObject);
        }
    }
}
