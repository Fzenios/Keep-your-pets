using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScr : MonoBehaviour
{
    public float rotationSpeed;
    void Start()
    {
        
    }

    void Update()
    {
		transform.Rotate (Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
    }
    void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Owner" || other.tag == "Pet")
        {
            Destroy(gameObject);
            
        }      
    }
}
