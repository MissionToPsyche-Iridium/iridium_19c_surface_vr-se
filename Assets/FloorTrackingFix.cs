using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class FloorTrackingFix : MonoBehaviour
{
    void Start()
    {
        SetTrackingToFloor();
    }

    void SetTrackingToFloor()
    {
        // Recenter tracking to adjust to floor level
        InputTracking.Recenter();
        Debug.Log("Tracking recentered to floor level.");
    }

}
