using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Return)){
        GameManager.Instance.NextLevel();
       } 
    }

    public void SkipIntro(){
        GameManager.Instance.NextLevel();
    }
}
