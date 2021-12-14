using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMechanic : MonoBehaviour
{
    public Transform DogSpownPos;
    public GameObject DogPre;
    public Vector3 DogSpownVector;
    void Start()
    {
        
    }

    void Update()
    {
        DogSpownVector.Set(DogSpownPos.position.x, DogSpownPos.position.y , DogSpownPos.position.z);
        if(Input.GetKeyDown(KeyCode.K))
        {
            DogSpown();

        }
    }
    public void DogSpown()
    {
        Instantiate(DogPre, DogSpownVector, Quaternion.identity, transform.parent);
    }
}
