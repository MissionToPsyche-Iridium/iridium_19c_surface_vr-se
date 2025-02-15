using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem; // Import the Unity Engine Input System library for the InputAction.CallbackContext.
using UnityEngine.SceneManagement; // Import the Unity Engine Scene Management library for the SceneManager.

public class WristUIPauseManage : MonoBehaviour
{
    public GameObject wristPauseUI; // The wrist pause UI object.

    public bool turnOnWristPauseUI = true; // A boolean to turn on the wrist pause UI when a specific button is pressed(X button on left VR controller).

    // Start is called before the first frame update
    void Start()
    {
        ShowUIForWristPause();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// A method to show the wrist pause UI when the X button on the left VR controller is pressed.
    /// </summary>
    /// <param name="context"></param>
    public void PressingWristUIButton(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            ShowUIForWristPause();
        }
    }

    /// <summary>
    /// A method to fully handle the wrist pause UI. If the boolean is true, turn off the wrist pause UI and set the time scale to 1.
    /// </summary>
    public void ShowUIForWristPause()
    {
        // If the boolean is true, turn off the wrist pause UI and set the time scale to 1.
        if (turnOnWristPauseUI)
        {
            wristPauseUI.SetActive(false);
            turnOnWristPauseUI = false;
            Time.timeScale = 1;
        } // If the boolean is false, turn on the wrist pause UI and set the time scale to 0.
        else if (!turnOnWristPauseUI)
        {
            wristPauseUI.SetActive(true);
            turnOnWristPauseUI = true;
            Time.timeScale = 0;
        }
    }

    /// <summary>
    /// Description: Task #239 - Adding the additional function, which is to Return to the Title/Main Menu Scene.
    /// Contribution: jlgrijal(Jose)
    /// Date: 02/07/2025
    /// </summary>
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenuVR");
    }

    /// <summary>
    /// Description: Task #258 - Adding the additional function, which is to Go to the Mars Site 3 Scene, from Mars Site 2 or Mars Site 1.
    /// Contribution: jlgrijal(Jose)
    /// Date: 02/15/2025
    /// </summary>
    public void GoToMarsSite3()
    {
        SceneManager.LoadScene("Mars Site 3");
    }

    /// <summary>
    /// Description: Task #258 - Adding the additional function, which is to Go to the Mars Site 4 Scene, from Mars Site 2.
    /// Contribution: jlgrijal(Jose)
    /// Date: 02/15/2025
    public void GoToMarsSite4()
    {
        SceneManager.LoadScene("Mars Site 2");
    }

    /// <summary>
    /// A method to exit the application completely once you click/touch the exit button on the wrist pause UI.
    /// </summary>
    public void CloseApplication()
    {
        Application.Quit();
    }
}
