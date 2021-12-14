using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsCalc : MonoBehaviour
{
    public int MultiplierCount;
    public int PetCount;
    void Start()
    {
        MultiplierCount = 0;
    }
    
    void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Multiplier")
        {
            MultiplierCount ++;
            //Debug.Log(MultiplierCount);
        }
    }
}
