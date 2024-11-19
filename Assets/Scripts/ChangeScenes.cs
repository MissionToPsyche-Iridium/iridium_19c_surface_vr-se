using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

// Class to handle scene changes in the application
public class ChangeScenes : MonoBehaviour
{
    // Load the "AboutScreen" scene
    public void goToAboutScreen()
    {
        SceneManager.LoadScene("AboutScreen");
    }

    // Load the "SettingsScreen" scene
    public void goToSettingsScreen()
    {
        SceneManager.LoadScene("SettingsScreen");
    }

    // Load the "MarsMenu" scene
    public void goToMarsMenuScreen()
    {
        SceneManager.LoadScene("MarsMenu");
    }

    // Load the "MainMenu" scene
    public void goToMainMenuScreen()
    {
        SceneManager.LoadScene("MainMenuVR");
    }

    // Load the "Credits" scene
    public void goToCreditsScreen()
    {
        SceneManager.LoadScene("CreditsScreen");
    }

    // Load the Mars site 2 scene
    public void goToMars2Screen()
    {
        SceneManager.LoadScene("Mars Site 2");
    }
}
