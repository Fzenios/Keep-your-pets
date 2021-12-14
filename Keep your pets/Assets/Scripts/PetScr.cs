using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetScr : MonoBehaviour
{
    Rigidbody PlayerRb;
    public float FrontSpeed, SideSpeed, CurrentSpeed, SlowSpeed, FastSpeed, SuperSlowSpeed;
    public KeyCode Left, Right; 
    float Distance;
    Transform PlayerPos;
    bool FinaleBool;
    LineRenderer lineRenderer;
    Vector3 PetBoost;
    GameMechanic gameMechanic;
    void Start()
    {
        PlayerRb = GetComponent<Rigidbody>();
        PlayerPos = GameObject.FindGameObjectWithTag("Owner").transform;
        lineRenderer = gameObject.GetComponent<LineRenderer>();

        gameMechanic = GameObject.FindObjectOfType<GameMechanic>();

        CurrentSpeed = FrontSpeed;
        FinaleBool = false;

        gameMechanic.PetsCount ++;
    }

     void Update()
    {
        if(!FinaleBool)
        {
            Distance = Vector3.Distance(transform.position, PlayerPos.position);
            if(Distance >= 8)
                CurrentSpeed = SlowSpeed;
            else if (Distance >= 6 && Distance <= 7.9f)
                CurrentSpeed = SuperSlowSpeed;    
            else if (Distance <= 1.8f)
                CurrentSpeed = FastSpeed;
            else CurrentSpeed = FrontSpeed;
            }
        
       // Debug.Log(Distance);
    }
    void FixedUpdate() 
    {
        PlayerRb.AddForce(0, 0, CurrentSpeed * Time.deltaTime);
        
        if(!FinaleBool)
        {
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
    void OnCollisionEnter(Collision other)
    {
        if(other.collider.tag == "Road")
        {
            Destroy(gameObject);
            gameMechanic.PetsCount--;
        }
    }
    void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Distraction")
        {
            Destroy(gameObject);
            gameMechanic.PetsCount--;
        } 
        if(other.tag == "Finale")
        {
            FinaleBool = true;
            CurrentSpeed = 0;
            lineRenderer.enabled = false;
            int RandomX = Random.Range(0,2);
            if(RandomX == 0)
                PetBoost = new Vector3(12,0,2);
            else
                PetBoost = new Vector3(-12,0,2); 
            PlayerRb.AddForce(PetBoost, ForceMode.Impulse);
        }         
    }
}
