using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogDistractionScr : MonoBehaviour
{
    Rigidbody CatRb;
    Vector3 catmove;
    public GameObject PetChase;
    void Start()
    {
        CatRb = GetComponent<Rigidbody>();
    }


    void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Pet")
        {
            CatChase();
            Destroy(gameObject, 2);
        }
    }
    public void CatChase()
    {
        Collider collider = GetComponent<Collider>();
        collider.enabled = false;
        PetChase.SetActive(true);
        if(transform.position.x > 0)
        {
            catmove.x = 15;
            transform.Rotate(0,-110,0); 
        }
        else
        {
            catmove.x = -15;
            transform.Rotate(0,110,0); 
        }
        
        CatRb.AddForce(catmove, ForceMode.Impulse);
    }
    
}
