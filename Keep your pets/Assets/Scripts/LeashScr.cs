using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeashScr : MonoBehaviour
{
    public int length;
    public LineRenderer lineRend;
    public Vector3[] segmentPoses;
    Vector3[] segmentV;
    public Transform targetDir;
    Transform FinishtDir;
    public float targetDist;
    public float smoothSpeed;
    public float trailSpeed;
    
    void Start()
    {
        lineRend.positionCount = length;  
        segmentPoses = new Vector3[length];
        segmentV = new Vector3[length]; 
        
        FinishtDir = GameObject.FindGameObjectWithTag("FinishDir").transform;    
    }

    // Update is called once per frame
    void Update()
    {
        segmentPoses[0] = targetDir.position;
        
        for (int i= 1; i < segmentPoses.Length; i++)
        {
            segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], segmentPoses[i - 1] + targetDir.right * targetDist, ref segmentV[i], smoothSpeed);
        }
        segmentPoses[segmentPoses.Length-1] = FinishtDir.position;
        lineRend.SetPositions(segmentPoses);
        
    }
}
