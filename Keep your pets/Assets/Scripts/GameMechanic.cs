using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameMechanic : MonoBehaviour
{
    public int PetsCount;
    public int CoinsCount;
    public int FinalCoinsCount;
    public float TotalCoins, CurrentTotalCoins;
    float ScoreCounting;
    public TMP_Text Coinstxt, FinalCoinsTxt, TotalCoinsTxt;
    public bool ShowScore, CollectCoinsBool;
    public GameObject CoinsObj, FinalScoreObj, TotalCoinsObj, CollectBtnObj, NextLvlBtnObj, FinalCoinObj;
    public SoundsScr soundsScr;
    public AllData allData;

    void Start()
    {
        ShowScore = false;
        ScoreCounting = 0;
        CurrentTotalCoins = allData.TotalCoins;
        soundsScr.MainGameSong("Play");
        TotalCoinsTxt.text = allData.TotalCoins.ToString();
    }

    void Update()
    {
        Coinstxt.text = "Coins: " + CoinsCount;

        
        if(ShowScore)
       {
           FinalScoreObj.SetActive(true);
            if(ScoreCounting < FinalCoinsCount)
                ScoreCounting += Time.deltaTime * 70;
            else 
            {
                ShowScore = false;
                CollectBtnObj.SetActive(true);
            }

            FinalCoinsTxt.text = "COINS: " + ScoreCounting.ToString("0");
       }
       if(CollectCoinsBool)
       {
           if(ScoreCounting > 0)
           {

                ScoreCounting -= Time.deltaTime * 100;
                CurrentTotalCoins += Time.deltaTime * 100;
                if(ScoreCounting < 0)
                {
                    ScoreCounting = 0;
                }
           }
           else
           {
               ScoreCounting = allData.TotalCoins;
               FinalCoinObj.SetActive(false);
               NextLvlBtnObj.SetActive(true);
               CollectCoinsBool = false;
               soundsScr.CoinsCollect("Stop");
           }
            FinalCoinsTxt.text = "COINS: " + ScoreCounting.ToString("0");
            TotalCoinsTxt.text = CurrentTotalCoins.ToString("0");
       }
    }

    public void CollectCoins()
    {
        soundsScr.CoinsCollect("Play");
        soundsScr.MainGameSong("Stop");
        ScoreCounting = FinalCoinsCount;
        allData.TotalCoins += FinalCoinsCount;

        CollectCoinsBool = true;
        TotalCoinsObj.SetActive(true);
        CollectBtnObj.SetActive(false);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(1);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }    
}
