using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameMechanic : MonoBehaviour
{
    public int PetsCount;
    public int CoinsCount;
    public TMP_Text Coinstxt;

    void Start()
    {
        
    }

    void Update()
    {
        Coinstxt.text = "Coins: " + CoinsCount;
    }
}
