using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetScr : MonoBehaviour
{
    Rigidbody PetRb;
    public float FrontSpeed, SideSpeed;
    Transform PlayerPos;
    bool FinaleBool;
    LineRenderer lineRenderer;
    Vector3 PetBoost;
    GameMechanic gameMechanic;
    Joystick joystick;
    public Vector3 PetMovement;
    GameMenuScr gameMenuScr;
    PlayerScr playerScr;
    public Animator animator;
    SoundsScr soundsScr;
    void Start()
    {
        PetRb = GetComponent<Rigidbody>();
        PlayerPos = GameObject.FindGameObjectWithTag("Owner").transform;
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        gameMechanic = GameObject.FindObjectOfType<GameMechanic>();
        joystick = GameObject.FindObjectOfType<Joystick>();
        gameMenuScr = GameObject.FindObjectOfType<GameMenuScr>();
        playerScr = GameObject.FindObjectOfType<PlayerScr>();
        soundsScr = GameObject.FindObjectOfType<SoundsScr>();
        FinaleBool = false;

        gameMechanic.PetsCount ++;
        PetMovement.z = FrontSpeed;
    }

     void Update()
    {
        if(!FinaleBool)
        {
            //for pc
            PetMovement.x = Input.GetAxisRaw("Horizontal");
            
            //ForMobile
            if(joystick.Horizontal > 0.7f)
                PetMovement.x = joystick.Horizontal;            
            else if(joystick.Horizontal < -0.7)
                PetMovement.x = joystick.Horizontal;
            /*else 
                PetMovement.x = 0;  */
        }
    }
    void FixedUpdate() 
    {     
        animator.SetFloat("movement", PetMovement.z);   
        if(!playerScr.ManualPauseGame)
        {
            if(!gameMenuScr.PauseGame)
            {
                if(!FinaleBool)
                {   
                    PetRb.MovePosition(PetRb.position + PetMovement * SideSpeed * Time.deltaTime);
                }
            }
        }
        
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.collider.tag == "Road")
        {
            gameMechanic.PetsCount--;
            Destroy(gameObject,2);
            lineRenderer.enabled = false;
            if(transform.position.x > 0)
            {
                transform.Rotate(0,90,0); 
                PetRb.AddForce(new Vector3(15,0,0),ForceMode.Impulse);
            }
            else
            {
                transform.Rotate(0,-90,0); 
                PetRb.AddForce(new Vector3(-15,0,0),ForceMode.Impulse);            
            }
        }
    }
    void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Distraction")
        {
            DogLoss();
        } 
        if(other.tag == "Finale")
        {
            FinaleBool = true;
            lineRenderer.enabled = false;
            int RandomX = Random.Range(0,2);
            if(RandomX == 0)
                PetBoost = new Vector3(15,0,2);
            else
                PetBoost = new Vector3(-15,0,2); 
            PetRb.AddForce(PetBoost, ForceMode.Impulse);
        }  
        if(other.tag == "Collectables")
        {
            soundsScr.Coin();
            gameMechanic.CoinsCount ++;
        }       
    }
    public void DogLoss()
    {
        soundsScr.Cat();
        gameMechanic.PetsCount--;
        Destroy(gameObject);
    }
}
