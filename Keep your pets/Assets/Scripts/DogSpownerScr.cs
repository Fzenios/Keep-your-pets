using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogSpownerScr : MonoBehaviour
{
    public float movementSpeed = 3;
    public GameObject RotatePoint;
    public Vector3 Rotateanotherpoint;
    Animator anim;
    Rigidbody rb;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("movement", 1);
        transform.RotateAround(RotatePoint.transform.position, Rotateanotherpoint, movementSpeed * Time.deltaTime);
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
