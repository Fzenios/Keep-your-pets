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
    public int MultiplierCount;
    public Joystick joystick;
    public Vector3 PlayerMovement;
    public GameMenuScr gameMenuScr;
    public bool ManualPauseGame;
    public GameObject StartCounter;
    public Animator animator;
    public GameObject PauseBtnObj;
    public GameObject Car;
    public Transform SpownCar;
    public CameraScr cameraScr;
    public GameObject LostGameObj;
    public SoundsScr soundsScr;

    void Start()
    {
        PlayerRb = GetComponent<Rigidbody>();
        Finale = false;
        MultiplierCount = 0;
        PlayerMovement.z = 0;
        gameMenuScr.PauseGame = false;
        StartCoroutine(StartGame());
    }
    void Update() 
    {
        //for pc
        PlayerMovement.x = Input.GetAxisRaw("Horizontal");     
        
        //ForMobile
        if(joystick.Horizontal > 0.2f)
            PlayerMovement.x = joystick.Horizontal;            
        else if(joystick.Horizontal < -0.2)
            PlayerMovement.x = joystick.Horizontal;  
        /*else 
        PlayerMovement.x = 0;  */
    }

    void FixedUpdate() 
    {
        animator.SetFloat("movement", PlayerMovement.z);
        if(!ManualPauseGame)
        {
            if(!gameMenuScr.PauseGame)
            {
                if(!Finale)
                {
                    PlayerRb.MovePosition(PlayerRb.position + PlayerMovement * SideSpeed * Time.deltaTime);
                    
                }
            }
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
            soundsScr.Coin();
        }
        if(other.tag == "Multiplier")
        {
            MultiplierCount ++;
        }
        if(other.tag == "Distraction")
        {
            if(gameMechanic.PetsCount > 0)
            {
                PetScr petScr;
                petScr = GameObject.FindObjectOfType<PetScr>();
                petScr.DogLoss();
                DogDistractionScr dogDistractionScr;
                dogDistractionScr = other.GetComponent<DogDistractionScr>();
                dogDistractionScr.CatChase();
            }
            else if(gameMechanic.PetsCount == 0)
            {
                soundsScr.Cat();
                cameraScr.Follow = false;
                PlayerRb.AddForce(new Vector3(0,40,0),ForceMode.Impulse);
                Destroy(gameObject,2);
                StartCoroutine(LostGame());
            }
        }
        
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.collider.tag == "Road")
        {
            soundsScr.CarHorn();
            StartCoroutine(LostGame());
            Instantiate(Car, SpownCar.position, Quaternion.identity);
            cameraScr.Follow = false;
            PlayerRb.AddForce(new Vector3(0,40,0),ForceMode.Impulse);
            Destroy(gameObject,2);
        }
    }

    IEnumerator PlayerPush()
    {   
        yield return new WaitForSeconds(0.5f);
        Finale = true;
        
        int PlayerBoostX = 60 + (gameMechanic.PetsCount * 10);
        if(PlayerBoostX >= 170)
            PlayerBoostX = 170;

        PlayerBoost = new Vector3(0, 40, PlayerBoostX);
        PlayerRb.AddForce(PlayerBoost, ForceMode.Impulse);
        animator.SetBool("Falling", true);
        yield return new WaitForSeconds(10f);
        animator.SetBool("Falling", false);
        animator.SetBool("Swim", true);

    }
    IEnumerator CountScore()
    {   
        yield return new WaitForSeconds(10f);
        if(gameMechanic.PetsCount > 0 && MultiplierCount > 0)
        {
            PauseBtnObj.SetActive(false);
            gameMechanic.FinalCoinsCount = gameMechanic.CoinsCount * MultiplierCount;    
            gameMechanic.ShowScore = true;
            gameMechanic.CoinsObj.SetActive(false);
            gameMechanic.FinalScoreObj.SetActive(true);
        }
        else
        {
            StartCoroutine(LostGame());
        }
    }
    IEnumerator StartGame()
    {   
        yield return new WaitForSeconds(0.2f);
        ManualPauseGame = true;
        StartCounter.SetActive(true);
        yield return new WaitForSeconds(4f);
        ManualPauseGame = false;
        StartCounter.SetActive(false);
        PlayerMovement.z = FrontSpeed;
    }
    IEnumerator LostGame()
    {
        yield return new WaitForSeconds(1f);
        PauseBtnObj.SetActive(false);
        LostGameObj.SetActive(true);

    }

    public void DogSpown()
    {      
        Instantiate(DogPre, DogSpownPos.position, Quaternion.identity, transform.parent);
        soundsScr.Dog();
    }
}
