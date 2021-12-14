using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScr : MonoBehaviour
{
    public Transform Target;
    public Vector3 offset;
    public float SmoothMove;
    void Start()
    {
        //offset = transform.position - Target.position;
    }

    void LateUpdate() 
    {
        Vector3 PositionToBe = Target.position + offset;
        Vector3 SmoothedPosition = Vector3.Lerp(transform.position, PositionToBe, Time.deltaTime * SmoothMove);        
        transform.position = SmoothedPosition;
    }
    
}
