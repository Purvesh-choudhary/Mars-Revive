using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<BaseHealth> allBases;

    void OnEnable()
    {
        BaseHealth.OnBaseDestroyed += BaseDestroyedHandler;
    }

    void OnDisable()
    {
        BaseHealth.OnBaseDestroyed -= BaseDestroyedHandler;
    }

    void Start()
    {
        // Optional: automatically populate if needed
        // allBases.AddRange(FindObjectsOfType<BaseHealth>());
    }

    void BaseDestroyedHandler(BaseHealth destroyedBase)
    {
        allBases.Remove(destroyedBase);

        if (allBases.Count == 0)
        {
            Debug.Log("Level Complete!");
            // Load next level or show win UI
        }
    }
}
