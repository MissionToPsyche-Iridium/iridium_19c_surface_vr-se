using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// UPDATE(1/17/2025): This script was modified to be cleaner and more optimized for
/// Task #184 of User Story #183. Modification was made so it can be a little more scalable
/// in the future if more adjustments or modifications are needed.
/// </summary>

public class HandAnimationInput : MonoBehaviour
{

    // Making all of the variables private and serializable
    // so that the variables can't unintentionally be changed from other scripts.
    [SerializeField] private Animator handAnimator;
    [SerializeField] private InputActionProperty animatingPinch;
    [SerializeField] private InputActionProperty animatingGrip;

    /// <summary>
    /// In this update method, the value of the trigger and grip are 
    /// being read from the input system and then being set to the animator in Unity.
    /// 
    /// Modification: Added a null check for the animator to prevent errors if no animator is assigned,
    /// and restructured the float value-reading implementation to be more readable and cleaner.
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        if (handAnimator == null) return; // Taking extra precaution to prevent
                                         // errors if no Animator is assigned.

        // Setting the trigger and grip values to the animator.
        handAnimator.SetFloat("Trigger", animatingPinch.action.ReadValue<float>());
        handAnimator.SetFloat("Grip", animatingGrip.action.ReadValue<float>());

    }
}
