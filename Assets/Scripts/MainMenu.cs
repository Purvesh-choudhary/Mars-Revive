using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame(){
        GameManager.Instance.NewGame();
    }

    public void Quit(){
        GameManager.Instance.Quit();
    }

    
    public void OpenURL(string url){
        Application.OpenURL(url);
    }



}
