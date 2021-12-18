using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuScr : MonoBehaviour
{
    public bool PauseGame;
    public GameObject PauseMenuObj;
    void Start() 
    {
        PauseGame = false;        
    }
    public void PauseBtn()
    {
        PauseGame =! PauseGame;
        if(PauseGame)
        {
            PauseMenuObj.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            PauseMenuObj.SetActive(false);
            Time.timeScale = 1;  
        } 
    }
    public void ExitBtn()
    {
        Time.timeScale = 1;  
        SceneManager.LoadScene(0);
    }
}
