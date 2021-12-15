using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScr : MonoBehaviour
{
    Rigidbody PlayerRb;
    public float FrontSpeed, SideSpeed;
    public GameObject DogColliders, DogColliders2;
    public Vector3 PlayerBoost;
    bool Finale;
    public Transform DogSpownPos;
    public GameObject DogPre;
    public GameMechanic gameMechanic;
    public int FinalScore;
    public int MultiplierCount;
    public Joystick joystick;
    public Vector3 PlayerMovement;

    void Start()
    {
        PlayerRb = GetComponent<Rigidbody>();
        Finale = false;
        MultiplierCount = 1;
        PlayerMovement.z = FrontSpeed;
    }
    void Update() 
    {
        //for pc
        PlayerMovement.x = Input.GetAxisRaw("Horizontal");     
        
        //ForMobile
        if(joystick.Horizontal > 0.7f)
            PlayerMovement.x = joystick.Horizontal;            
        else if(joystick.Horizontal < -0.7)
            PlayerMovement.x = joystick.Horizontal;  
        /*else 
        PlayerMovement.x = 0;  */
    }

    void FixedUpdate() 
    {
        if(!Finale)
        {
            PlayerRb.MovePosition(PlayerRb.position + PlayerMovement * SideSpeed * Time.deltaTime);
        }
    }
    void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "PreFinale")
        {
            DogColliders.SetActive(false);
            DogColliders2.SetActive(false);
            
        }  
        if(other.tag == "Finale")
        {
            StartCoroutine(PlayerPush());
            StartCoroutine(CountScore());
        }  
        if(other.tag == "DogSpowner")   
        {
            DogSpown();
        }  
        if(other.tag == "Collectables")
        {
            gameMechanic.CoinsCount ++;
        }
        if(other.tag == "Multiplier")
        {
            MultiplierCount ++;
        }
    }
    IEnumerator PlayerPush()
    {   
        yield return new WaitForSeconds(1.5f);
        Finale = true;
        
        int PlayerBoostX = 50 + (gameMechanic.PetsCount * 10);
        if(PlayerBoostX >= 160)
            PlayerBoostX = 160;

        PlayerBoost = new Vector3(0, 40, PlayerBoostX);
        PlayerRb.AddForce(PlayerBoost, ForceMode.Impulse);
    }
    IEnumerator CountScore()
    {   
        yield return new WaitForSeconds(13f);
        FinalScore = gameMechanic.CoinsCount * MultiplierCount;
        Debug.Log(FinalScore);      
    }

    public void DogSpown()
    {      
        Instantiate(DogPre, DogSpownPos.position, Quaternion.identity, transform.parent);
    }

}
