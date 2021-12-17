using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogDistractionScr : MonoBehaviour
{
    Rigidbody CatRb;
    public Vector3 catmove;
    void Start()
    {
        CatRb = GetComponent<Rigidbody>();
        CatChase();
    }


    void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Pet")
        {
            CatChase();
            Destroy(gameObject, 2);
        }
    }
    void CatChase()
    {
        if(transform.position.x > 0)
            catmove.x = 15;
            //transform.rotation = 60;
        else
            catmove.x = -15;
        
        CatRb.AddForce(catmove, ForceMode.Impulse);
    }
    
}
