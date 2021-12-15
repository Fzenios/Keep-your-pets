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
    public float TotalCoins;
    float ScoreCounting, CoinsToGive;
    public TMP_Text Coinstxt, FinalCoinsTxt, TotalCoinsTxt;
    public bool ShowScore, CollectCoinsBool;
    public GameObject CoinsObj, FinalScoreObj, TotalCoinsObj, CollectBtnObj, NextLvlBtnObj;

    void Start()
    {
        ShowScore = false;
        ScoreCounting = 0;
        TotalCoins = 0;
    }

    void Update()
    {
        Coinstxt.text = "Coins: " + CoinsCount;
        
        if(ShowScore)
       {
           FinalScoreObj.SetActive(true);
            if(ScoreCounting < FinalCoinsCount)
                ScoreCounting += Time.deltaTime * 40;
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
                ScoreCounting -= Time.deltaTime * 70;
                TotalCoins += Time.deltaTime * 70;
           }
           else
           {
               NextLvlBtnObj.SetActive(true);
               CollectCoinsBool = false;
           }
            FinalCoinsTxt.text = "COINS: " + ScoreCounting.ToString("0");
            TotalCoinsTxt.text = TotalCoins.ToString("0");
       }
    }

    public void CollectCoins()
    {
        CoinsToGive = FinalCoinsCount;
        ScoreCounting = FinalCoinsCount;

        CollectCoinsBool = true;
        TotalCoinsObj.SetActive(true);
        CollectBtnObj.SetActive(false);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(0);
    }
    
}
