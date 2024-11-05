using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR; // Needed for the Hand class.
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(ActionBasedController))] // This script requires the ActionBasedController component to be attached to the same GameObject.
public class HandControls : MonoBehaviour
{
    ActionBasedController controller; // Deprecated function but will stick with it for now until the newer tools or functions are fully understood and learned.
    HandScript hand; // This is the HandScript class that was created in the previous step but the file is called Hand.cs
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<ActionBasedController>();
    }

    // Update is called once per frame
    void Update()
    {
        hand.setGrip(controller.selectAction.action.ReadValue<float>());
    }
}
