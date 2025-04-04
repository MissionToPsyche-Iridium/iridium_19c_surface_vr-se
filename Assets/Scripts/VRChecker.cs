using UnityEngine;
using UnityEngine.XR;
using System.Collections.Generic;

public class VRChecker : MonoBehaviour
{
    public GameObject warningTextUI; // UI Text GameObject here to be updated if no VR headset is detected.
        
    void Start()
    {
        if (!IsVRHeadsetConnected())
        {
            Debug.LogWarning("No VR headset detected.");
            if (warningTextUI != null)
                warningTextUI.SetActive(true);
        }
    }

    // Checks if a VR Headset is detected.
    public bool IsVRHeadsetConnected()
    {
        // Grabs a list of all active XRInput Systems.
        List<XRInputSubsystem> inputSubsystems = new List<XRInputSubsystem>();
        SubsystemManager.GetInstances(inputSubsystems);

        // Checks for XR subsystems and tries to see if any of them are running.
        foreach (var subsystem in inputSubsystems)
        {
            if (subsystem.running)
                return true;
        }

        return false;
    }
}