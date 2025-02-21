using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; // Import the Unity Engine UI library for the Button.
using UnityEngine;

using UnityEngine.InputSystem; // Import the Unity Engine Input System library for the InputAction.CallbackContext.
using UnityEngine.SceneManagement; // Import the Unity Engine Scene Management library for the SceneManager.

public class WristUIPauseManage : MonoBehaviour
{
    public GameObject wristPauseUI; // The wrist pause UI object.
    public bool turnOnWristPauseUI = true; // A boolean to turn on the wrist pause UI when a specific button is pressed(X button on left VR controller).
    public GameObject decisionPanel; // The object for the decision panel to handle "Yes" or "No" buttons

    // Start is called before the first frame update
    // Update: 02/19/2025 - Added the decisionPanel.SetActive(false)
    // to set the decision panel to false when the game starts.
    void Start()
    {
        ShowUIForWristPause();

        if (decisionPanel != null)
            decisionPanel.SetActive(false);

        // For now, trying to force trigger a button click for testing
        // as the buttons on the main Wrist UI menu suddenly becoming completely
        // unresponsive after implementing the DecisionPanel function.
        Button[] testbuttons = wristPauseUI.GetComponentsInChildren<Button>();
        foreach (Button btn in testbuttons)
        {
            Debug.Log("Found Button: " + btn.gameObject.name);
        }
    }


    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 10f))
        {
            Debug.Log("XR Raycast hit: " + hit.collider.gameObject.name);
        }
        else
        {
            Debug.Log("XR Raycast is NOT hitting anything.");
        }
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
    /// Description: Task #258 - Adding the additional function, which is to Go to the Mars Site 2 Scene, from Mars Site 3 or Mars Site 1.
    /// Contribution: jlgrijal(Jose)
    /// Date: 02/15/2025
    public void GoToMarsSite2()
    {
        SceneManager.LoadScene("Mars Site 2");
    }

    /// <summary>
    /// Description: Task #258 - Adding the additional function, which is to Go to the Mars Site 1 Scene, from Mars Site 3 or Mars Site 2.
    /// Contribution: jlgrijal(Jose)
    /// Date: 02/15/2025
    public void GoToMarsSite1()
    {
        SceneManager.LoadScene("Mars Site 1");
    }

    /// <summary>
    /// A method to exit the application completely once you click/touch the exit button on the wrist pause UI.
    /// </summary>
    public void CloseApplication()
    {
        Debug.Log("Yes button clicked - Quitting Application");
        Application.Quit();
    }


    /// <summary>
    /// A method to display the decision panel when you click the "Close Application" button 
    /// on the wrist pause UI.
    /// Contribution: jlgrijal(Jose)
    /// Date: 02/19/2025
    /// </summary>
    public void DisplayDecisionPanel()
    {
        if (decisionPanel != null)
        {
            decisionPanel.SetActive(true);
            wristPauseUI.SetActive(false); // Hide the wrist pause UI when you click the "Close Application" button
        }
    }

    /// <summary>
    /// A method to close the application when you click the "Yes" button on the decision panel.
    /// Contribution: jlgrijal(Jose)
    /// Date: 02/19/2025
    /// </summary>
    public void DoNotCloseApplication()
    {
        Debug.Log("No button clicked - Returning to Main UI");
        if (decisionPanel != null)
        {
            decisionPanel.SetActive(false);
            wristPauseUI.SetActive(true); // Show the wrist pause UI when you click the "No" button on the deicsion panel
        }
    }
}
