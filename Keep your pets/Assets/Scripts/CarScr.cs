using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScr : MonoBehaviour
{
    Rigidbody CarRb;
    void Start()
    {
        CarRb = GetComponent<Rigidbody>();
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        CarRb.MovePosition(CarRb.position + new Vector3(0,0,25) * Time.deltaTime);     
    }
}
