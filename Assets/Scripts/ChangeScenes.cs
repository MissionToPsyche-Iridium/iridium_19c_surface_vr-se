using UnityEngine;
using UnityEngine.SceneManagement;

// Class to handle scene changes in the application
public class ChangeScenes : MonoBehaviour
{
    // Load the "AboutScreen" scene
    public void GoToAboutScreen()
    {
        SceneManager.LoadScene("AboutScreen");
    }

    // Load the "SettingsScreen" scene
    public void GoToSettingsScreen()
    {
        SceneManager.LoadScene("SettingsScreen");
    }

    // Load the "MarsMenu" scene
    public void GoToMaArsMenuScreen()
    {
        SceneManager.LoadScene("MarsMenu");
    }

    // Load the "MainMenu" scene
    public void GoToMainMenuScreen()
    {
        SceneManager.LoadScene("MainMenuVR");
    }

    // Load the "Credits" scene
    public void GoToCreditsScreen()
    {
        SceneManager.LoadScene("CreditsScreen");
    }

    // Load the Mars site 2 scene
    public void GoToMars2Screen()
    {
        SceneManager.LoadScene("Mars Site 2");
    }

    // Load the Mars site 3 scene
    public void GoToMars3Screen()
    {
        SceneManager.LoadScene("Mars Site 3");
    }

    // Exits the Application
    public void Exit()
    {
        Application.Quit();
    }

    // Load Quiz scene
    public void GoToQuizScreen()
    {
        SceneManager.LoadScene("Quiz");
    }
}