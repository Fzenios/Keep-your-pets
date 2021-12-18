using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScr : MonoBehaviour
{
    public Transform Target;
    public Vector3 offset;
    public float SmoothMove;
    public bool Follow;
    void Start()
    {
        Follow = true;  
    }

    void LateUpdate() 
    {
        if(Follow)
        {
            Vector3 PositionToBe = Target.position + offset;
            Vector3 SmoothedPosition = Vector3.Lerp(transform.position, PositionToBe, Time.deltaTime * SmoothMove);        
            transform.position = SmoothedPosition;
        }
    }
    
}
