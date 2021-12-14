using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogSpownerScr : MonoBehaviour
{
    PlayerScr playerScr;
    void Start()
    {
        playerScr = GameObject.FindObjectOfType<PlayerScr>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Owner") 
        {
            //playerScr.DogSpown();
            Destroy(gameObject);
        }       
    }
}
