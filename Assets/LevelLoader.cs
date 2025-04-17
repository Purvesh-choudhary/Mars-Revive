using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{

    [SerializeField] int index , loadingLevelIndex;
    [SerializeField] float timer;
    

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        GameManager.Instance.StartCoroutine(GameManager.Instance.LoadSceneCoroutine(timer,index));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
