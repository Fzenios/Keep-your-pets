using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsScr : MonoBehaviour
{
    public bool CollectCoinsBool;
    public GameMechanic gameMechanic;
    int CoinsToGive;

    void Update() 
    {
        if(CollectCoinsBool)
        {
            if(gameMechanic.FinalCoinsCount > 0)
                gameMechanic.FinalCoinsCount -= (int)(Time.deltaTime * 40);
            
        }
        
    }


    public void CollectCoins()
    {
        CoinsToGive = gameMechanic.FinalCoinsCount;
    }


}
