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
        }else if(Instance != this){
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
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

    public void RestartLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void MainMenu(){
        SceneManager.LoadScene(0);
    }

    public void loadScene(int index){
        SceneManager.LoadScene(index);
    }

    public IEnumerator LoadSceneCoroutine(float timer ,int index){
        yield return new WaitForSeconds(timer); 
        loadScene(index);
    }

}
