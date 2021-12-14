using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetScr : MonoBehaviour
{
    Rigidbody PlayerRb;
    public float FrontSpeed, SideSpeed, CurrentSpeed, SlowSpeed, FastSpeed, SuperFastSpeed, SuperSlowSpeed;
    public KeyCode Front, Left, Right; 
    float Distance;
    public GameObject Player;
    Transform PlayerPos;
    void Start()
    {
        PlayerRb = GetComponent<Rigidbody>();
        PlayerPos = GameObject.FindGameObjectWithTag("Owner").transform;
        CurrentSpeed = FrontSpeed;
    }

     void Update()
    {
        Distance = Vector3.Distance(transform.position, PlayerPos.position);
        if(Distance >= 8)
            CurrentSpeed = SlowSpeed;
        else if (Distance >= 6 && Distance <= 7.9f)
            CurrentSpeed = SuperSlowSpeed;    
        else if (Distance <= 1.8f)
            CurrentSpeed = FastSpeed;
        else CurrentSpeed = FrontSpeed;
        
       // Debug.Log(Distance);
    }
    void FixedUpdate() 
    {
        PlayerRb.AddForce(0, 0, CurrentSpeed * Time.deltaTime);
        
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
