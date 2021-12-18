using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsScr : MonoBehaviour
{   
    public SoundsScr soundsScr;
    void Start() 
    {
        soundsScr.IntroSong();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
