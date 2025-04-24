using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


/// <summary>
/// Functionality: Starts a timer for X minutes and Y seconds. After which it changes the scene back to the main menu.
/// This script is supposed to be called by a button with the script "FindPlayTimer."
/// Should be a child of a gameObject with a DontDestroyOnLoad.
/// </summary>
public class PlayTimer : MonoBehaviour
{
    [SerializeField]
    private float minutes; // Amount of minutes for timer.

    [SerializeField] 
    private float seconds; // Amount of seconds for timer.

    [SerializeField] 
    private GameObject TimerUI; // The Timer UI that displays the timer countdown.

    [SerializeField] 
    private TMP_Text TextMinutes; // The Timer UI text that displays the minutes remaining.
    
    [SerializeField] 
    private TMP_Text TextSeconds; // The Timer UI text that displays the seconds remaining.
    
    [SerializeField] 
    private GameObject StartTimerButtonUI; // The UI button that starts the timer.

    [SerializeField] 
    private ChangeScenes sceneChanger; // Needs access to a sceneChanger script to move the scene.
    
    private bool isRunning = false; // Tracks to see if the Coroutine is still running.

    private Coroutine timerCoroutine; // Stores a reference to the Coroutine so that it can stop and reset it.

    public void StartTimer()
    {
        
        if (!isRunning)
        {
            // Starts the timer.
            timerCoroutine = StartCoroutine(Timer());
            TimerUI.SetActive(true);
            isRunning = true;
        }
        else
        {
            // Restart the timer.
            StopCoroutine(timerCoroutine);
            isRunning = false;
            StartTimer();
        }
    }

    // Coroutine used as a Timer
    IEnumerator Timer()
    {
        float totalSeconds = (minutes * 60f) + seconds;
        Debug.Log("Timer started");

        // Main time keep loop.
        while (totalSeconds > 0)
        {
            int displayMinutes = Mathf.FloorToInt(totalSeconds / 60f);
            int displaySeconds = Mathf.FloorToInt(totalSeconds % 60f);

            TextMinutes.SetText(displayMinutes.ToString("00"));
            TextSeconds.SetText(displaySeconds.ToString("00"));

            yield return new WaitForSecondsRealtime(1f);
            totalSeconds -= 1f;
        }

        // Sets the format of the text for the UI.
        TextMinutes.SetText("00");
        TextSeconds.SetText("00");

        Debug.Log("Timer ended after a delay of " + minutes + " minutes and " + seconds + " seconds.");
        
        // Turns off the timer then returns to the Main Menu Scene.
        TimerUI.SetActive(false);
        isRunning = false;
        sceneChanger.goToMainMenuScreen();
    }


}
