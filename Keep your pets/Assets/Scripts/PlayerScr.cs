using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScr : MonoBehaviour
{
    Rigidbody PlayerRb;
    public float FrontSpeed, SideSpeed;
    public KeyCode Front, Left, Right; 
    public GameObject DogColliders, DogColliders2;
    public Vector3 PlayerBoost;
    bool Finale;
    public Transform DogSpownPos;
    public GameObject DogPre;
    public GameMechanic gameMechanic;

    void Start()
    {
        PlayerRb = GetComponent<Rigidbody>();
        Finale = false;
    }

    void Update()
    {
        
    }
    void FixedUpdate() 
    {
        if(!Finale)
        {
            PlayerRb.AddForce(0, 0, FrontSpeed * Time.deltaTime);
            
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
        }  
        if(other.tag == "DogSpowner")   
        {
            DogSpown();
            
           // Debug.Log(gameMechanic.PetsCount);
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

    public void DogSpown()
    {
        Instantiate(DogPre, DogSpownPos.position, Quaternion.identity, transform.parent);
    }

}
