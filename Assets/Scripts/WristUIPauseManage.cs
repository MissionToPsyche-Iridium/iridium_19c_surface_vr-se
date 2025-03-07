using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; // Import the Unity Engine UI library for the Button.
using UnityEngine;

using System.Linq; // Import the System Linq library for the Select method to handle the array of fast travel spots.


using UnityEngine.InputSystem; // Import the Unity Engine Input System library for the InputAction.CallbackContext.
using UnityEngine.SceneManagement; // Import the Unity Engine Scene Management library for the SceneManager.

public class WristUIPauseManage : MonoBehaviour
{
    public GameObject wristPauseUI; // The wrist pause UI object.
    public bool turnOnWristPauseUI = true; // A boolean to turn on the wrist pause UI when a specific button is pressed(X button on left VR controller).
    public GameObject decisionPanel; // The object for the decision panel to handle "Yes" or "No" buttons

    [Header("Component Settings for Fast Travel")]
    public Transform vrUser;  // The Setting for assigning the XR Origin or Camera Rig prefab on the component setting.
    public Transform[] extraTeleportSpots; // Optional manually assigned locations.
                                           // Decided to implement Fast Travel function where it can be both manually and automatically assigned for scalability.
    private Transform[] teleportSpots; // Stores all valid travel points
    private int mostRecentIndex = -1; // Tracks the most recent fast travel spot teleported to.


    // Start is called before the first frame update

    // Update: 02/19/2025 - Added the decisionPanel.SetActive(false)
    // to set the decision panel to false when the game starts.
    void Start()
    {
        SetUpFastTravel();

        ShowUIForWristPause();

        if (decisionPanel != null)
            decisionPanel.SetActive(false);

    }

    // Update is called once per frame
    /*
    void Update()
    {

    }
    */

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
        else
        {
            wristPauseUI.SetActive(true);   
            turnOnWristPauseUI = true;
            Time.timeScale = 0;
        }
    }

    /// <summary>
    /// Description: Task #239 - Adding the additional function, which is to Return to the Title/Main Menu Scene.
    /// 
    /// Contribution: jlgrijal(Jose)
    /// Date: 02/07/2025
    /// </summary>
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenuVR");
    }

    /// <summary>
    /// Description: Task #258 - Adding the additional function, which is to Go to the Mars Site 3 Scene, from Mars Site 2 or Mars Site 1.
    /// 
    /// Contribution: jlgrijal(Jose)
    /// Date: 02/15/2025
    /// </summary>
    public void GoToMarsSite3()
    {
        SceneManager.LoadScene("Mars Site 3");
    }

    /// <summary>
    /// Description: Task #258 - Adding the additional function, which is to Go to the Mars Site 2 Scene, from Mars Site 3 or Mars Site 1.
    /// 
    /// Contribution: jlgrijal(Jose)
    /// Date: 02/15/2025
    public void GoToMarsSite2()
    {
        SceneManager.LoadScene("Mars Site 2");
    }

    /// <summary>
    /// Description: Task #258 - Adding the additional function, which is to Go to the Mars Site 1 Scene, from Mars Site 3 or Mars Site 2.
    /// 
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
    /// 
    /// Contribution: jlgrijal(Jose)
    /// Date: 02/19/2025
    /// </summary>
    public void DisplayDecisionPanel()
    {
        if (decisionPanel != null)
        {
            decisionPanel.SetActive(true);
        }
    }

    /// <summary>
    /// A method to close the application when you click the "Yes" button on the decision panel.
    /// 
    /// Contribution: jlgrijal(Jose)
    /// Date: 02/19/2025
    /// </summary>
    public void DoNotCloseApplication()
    {
        if (decisionPanel != null)
        {
            decisionPanel.SetActive(false);
        }
    }

    /// <summary>
    /// A function for detecting and storing the fast travel spots manually and auto-detected objects
    /// based on the "FastTravel" tag.
    /// 
    /// Contribution: jlgrijal(Jose)
    /// Date: 03/06/2025
    /// </summary>
    public void SetUpFastTravel()
    {
        // Any game object tagged with "FastTravel" will be auto-detected.
        GameObject[] autoFoundedSpots = GameObject.FindGameObjectsWithTag("FastTravel");
        Transform[] autoTravelSpots = new Transform[autoFoundedSpots.Length];

        for (int i = 0; i < autoFoundedSpots.Length; i++)
        {
            autoTravelSpots[i] = autoFoundedSpots[i].transform;
            Debug.Log($"Auto-detected spot: {autoTravelSpots[i].position}");
        }

        // Concatenate the auto-detected spots with the manually assigned spots, if any.
        int overallSpotCount = extraTeleportSpots.Length + autoTravelSpots.Length;
        teleportSpots = new Transform[overallSpotCount];

        // Loop through the extra teleport spots and
        // auto travel spots to assign them to the teleportSpots array.
        for (int i = 0; i < extraTeleportSpots.Length; i++)
        {
            teleportSpots[i] = extraTeleportSpots[i];
        }

        // Loop through the auto travel spots to assign them to the teleportSpots array.
        for (int i = 0; i < autoTravelSpots.Length; i++)
        {
            teleportSpots[extraTeleportSpots.Length + i] = autoTravelSpots[i];
        }


        // Debug log to check if fast travel spots are initialized.
        Debug.Log($"Fast Travel Started: {teleportSpots.Length}");
    }

    /// <summary>
    /// A method to enact the fast travel functinionality where the user
    /// actually teleports to the intended spots(s). If only one spot is available,
    /// the user gets teleported to that spot. If there are more than one spot available,
    /// it cycles through the spots sequentially.
    /// 
    /// Contribution: jlgrijal(Jose)
    /// Date: 03/06/2025
    /// 
    /// </summary>
    public void EnactFastTravel()
    {

        // Making sure the VR user is assigned.
        if (vrUser == null)
        {
            Debug.LogWarning("No Vr User assigned.");
            return;
        }


        // Making sure that there exists any travel spots.
        if (teleportSpots == null || teleportSpots.Length == 0)
        {
            Debug.LogWarning("No teleport spots found.");
            return;
        }


        // Defining the intended position to teleport to.
        Vector3 intendedPosition = teleportSpots[0].position;

        // Checking if the XR Origin has a Character Controller component and then to temporarily disable it before teleporting
        // so the character controller does not block the teleportation.
        CharacterController cc = vrUser.GetComponent<CharacterController>();
        if (cc != null)
        {
            Debug.Log("Character Controller found. Disabling it for teleportation.");
            cc.enabled = false;
        }

        vrUser.position = intendedPosition + new Vector3(0, 0.5f, 0); // Adding marginal offset to
                                                                      // to make sure movement occurs.

        // Re-enabling the Character Controller after teleportation.
        if (cc != null)
        {
            cc.enabled = true;
        }

    }
}
