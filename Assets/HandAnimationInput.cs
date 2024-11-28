using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandAnimationInput : MonoBehaviour
{
    public InputActionProperty animatingPinch;
    public InputActionProperty animatingGripping;

    public Animator handAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    /// <summary>
    /// In this update method, the value of the trigger and grip are 
    /// being read from the input system and then being set to the animator in Unity.
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        float valueOfTrigger = animatingPinch.action.ReadValue<float>();
        handAnimator.SetFloat("Trigger", valueOfTrigger);
        float valueOfGrip = animatingGripping.action.ReadValue<float>();
        handAnimator.SetFloat("Grip", valueOfGrip);
    }
}
