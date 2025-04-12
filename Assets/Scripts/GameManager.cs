using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance;
    
    void Awake()
    {
        if(Instance == null){
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame(){
        SceneManager.LoadScene(1);
    }
    
    public void LoadGame(){

    }
    public void Credits(){

    }
    public void Settings(){

    }
    public void Quit(){
        Debug.Log($"QUITED");
        Application.Quit();
    }

    public void Back(){
        Debug.Log($"BACK");
    }

}
