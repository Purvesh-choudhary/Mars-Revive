using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] GameObject pausePanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)){
            if(Time.timeScale == 1){
                Pause();
            }else{
                Continue();
            }
        }    
    }

    public void Pause(){
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    
    public void Continue(){
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void BackToBase(){
        Time.timeScale =1;
        GameManager.Instance.MainMenu();
    }

    public void Restart(){
        Time.timeScale =1;
        GameManager.Instance.RestartLevel();
    }

}
