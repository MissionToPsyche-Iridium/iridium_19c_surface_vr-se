using UnityEngine;
using UnityEngine.XR;
using System.Collections;
using System.Collections.Generic;

public class VRChecker : MonoBehaviour
{
    // UI Text GameObject here to be updated if no VR headset is detected.
    public GameObject warningTextUI;

    // bool for toggling this script on and off for testing purposes.
    [SerializeField]
    private bool isVRCheckerEnabled = true;
    
    void Start()
    {
        StartCoroutine(CheckHeadsetWithDelay());
    }

    IEnumerator CheckHeadsetWithDelay()
    {
        // Needs to use coroutine to wait for a second to give XR time to initialize.
        yield return new WaitForSeconds(1f);

        if (!isVRCheckerEnabled) yield break; // If VRChecker is disabled don't do anything.
        if (!IsVRHeadsetConnected())
        {
            Debug.LogWarning("VRChecker: No VR headset detected.");
            if (warningTextUI != null)
                warningTextUI.SetActive(true);
        }
        else
        {
            Debug.Log("VRChecker: VR headset or VR headset software is detected.");
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