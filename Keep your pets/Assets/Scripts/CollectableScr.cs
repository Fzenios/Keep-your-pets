using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScr : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Owner" || other.tag == "Pet")
        {
            Destroy(gameObject);
            
        }      
    }
}
