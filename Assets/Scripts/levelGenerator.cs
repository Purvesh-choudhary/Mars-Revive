using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class levelGenerator : MonoBehaviour
{

    [SerializeField] GameObject[] objectsToSpawn;
    [SerializeField] float areaMin,areaMax;
    [SerializeField] int spawnCounts = 20;
    [SerializeField] Vector3 rotation;
 
    void Awake()
    {
        SpawnObject();
    }

   

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K)){
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        for (int i = 0; i < spawnCounts; i++)
        {
            
            GameObject randomObject = objectsToSpawn[Random.Range(0,objectsToSpawn.Length)];
            Vector3 randomPosition = new Vector3(Random.Range(areaMin,areaMax),randomObject.transform.position.y,Random.Range(areaMin,areaMax));
            float randomRotaion = Random.Range(0f,360f);
            GameObject newOBJ = Instantiate(randomObject,randomPosition,Quaternion.Euler(-90,randomRotaion,0f));
            newOBJ.transform.SetParent(transform);
        }
    }

}
