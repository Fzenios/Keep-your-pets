using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsScr : MonoBehaviour
{   
    public SoundsScr soundsScr;
    public AllData allData;
    void Start() 
    {
        soundsScr.IntroSong();
    }

    public void PlayGame()
    {
        allData.TotalCoins = 0;
        allData.Mute = false;
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
