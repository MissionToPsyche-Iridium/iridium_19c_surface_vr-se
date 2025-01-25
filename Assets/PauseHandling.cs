using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using UnityEngine;


/*
 * Description: This script is used to handle the pause menu(in a more traditional UI) in the VR software.
 * Originally, there were attempts made to implement XR Ray Interactor to take the spot of the VR Hands model when pausing the simulation.
 * However, only the pausing of the locomotion and temporary disabling of VR Hands models functioned as intended.
 * For now, this C# will be saved as is and then commited and pushed. Then, for the next task, there will be an alternative Wrist UI C# script that will be created to compare
 * options between this and the traditional pause menu US of this C# Script to determine which would be more user-friendly. 
 * 
*/
public class PauseHandling : MonoBehaviour
{
    public GameObject uiForPauseMenu;
    public GameObject leftHandModelInteract;
    public GameObject rightHandModelInteract;
    public ContinuousMoveProviderBase locomotionDisable;
    public InputActionReference responseOfPause;

    private bool isPaused = false; // This is the default state of the pause menu where the VR simulation is not paused and runs like normal.

    /// <summary>
    /// The Start() function is used to set the pause menu to be inactive when the VR simulation starts.
    /// </summary>
    void Start()
    {
        uiForPauseMenu.SetActive(false);

        if (responseOfPause != null)
            responseOfPause.action.Enable();
    }

    /// <summary>
    /// The update() function checks if the binded input action for pausing is pressed. 
    /// If it is pressed, then the TogglePause() function is called.
    /// </summary>
    void Update()
    {
        if (responseOfPause.action.WasPressedThisFrame())
        {
            TogglePause();
        }
    }

    /// <summary>
    /// This function is used to toggle the pause menu on and off. In this function,
    /// I set up a component to disable the locomotion when the pause menu is active
    /// and the VR Hands model to be disabled when the pause menu is active.
    /// </summary>
    public void TogglePause()
    {
        isPaused = !isPaused;

        // Debug.Log("State of Pause: " + isPaused);

        uiForPauseMenu.SetActive(isPaused);

        if (locomotionDisable != null)
        {
            locomotionDisable.enabled = !isPaused;
        }

        if (leftHandModelInteract != null) leftHandModelInteract.SetActive(!isPaused);
        if (rightHandModelInteract != null) rightHandModelInteract.SetActive(!isPaused);
    }
}
