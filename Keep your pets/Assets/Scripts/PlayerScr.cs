using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScr : MonoBehaviour
{
    Rigidbody PlayerRb;
    public float FrontSpeed, SideSpeed;
    public KeyCode Front, Left, Right; 
    void Start()
    {
        PlayerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
    }
    void FixedUpdate() 
    {
        //if(Input.GetKey(Front))
        //{
            PlayerRb.AddForce(0, 0, FrontSpeed * Time.deltaTime);
        //} 
        
        if(Input.GetKey(Left))
        {
            PlayerRb.AddForce(-SideSpeed, 0, 0 * Time.deltaTime);
        } 
        if(Input.GetKey(Right))
        {
            PlayerRb.AddForce(SideSpeed, 0, 0 * Time.deltaTime);
        }   

    }

}
