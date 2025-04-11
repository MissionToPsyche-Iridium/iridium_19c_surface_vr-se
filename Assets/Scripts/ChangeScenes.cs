using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

// Class to handle scene changes in the application
public class ChangeScenes : MonoBehaviour
{
    [FormerlySerializedAs("m_VRChecker")] [SerializeField]
    private VRChecker vrChecker;
    
    // Load the "AboutScreen" scene
    public void goToAboutScreen()
    {
        if (vrChecker.IsVRHeadsetConnected())
            SceneManager.LoadScene("AboutScreen");
        
    }

    // Load the "SettingsScreen" scene
    public void goToSettingsScreen()
    {
        if (vrChecker.IsVRHeadsetConnected())
        SceneManager.LoadScene("SettingsScreen");
    }

    // Load the "MarsMenu" scene
    public void goToMarsMenuScreen()
    {
        if (vrChecker.IsVRHeadsetConnected())
        SceneManager.LoadScene("MarsMenu");
    }

    // Load the "MainMenu" scene
    public void goToMainMenuScreen()
    {
        if (vrChecker.IsVRHeadsetConnected())
        SceneManager.LoadScene("MainMenuVR");
    }

    // Load the "Credits" scene
    public void goToCreditsScreen()
    {
        if (vrChecker.IsVRHeadsetConnected())
        SceneManager.LoadScene("CreditsScreen");
    }

    // Load the Mars site 2 scene
    public void goToMars2Screen()
    {
        if (vrChecker.IsVRHeadsetConnected())
        SceneManager.LoadScene("Mars Site 2");
    }

    // Load the Mars site 3 scene
    public void goToMars3Screen()
    {
        if (vrChecker.IsVRHeadsetConnected())
        SceneManager.LoadScene("Mars Site 3");
    }
    
    // Exits the Application
    public void Exit()
    {
        Application.Quit();
    }

    // Load Quiz scene
    public void goToQuizScreen()
    {
        if (vrChecker.IsVRHeadsetConnected())
        SceneManager.LoadScene("Quiz");
    }
}
