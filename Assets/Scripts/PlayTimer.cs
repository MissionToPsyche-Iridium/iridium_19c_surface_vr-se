using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
///     Functionality: Starts a timer for X minutes and Y seconds. After which it changes the scene back to the main menu.
///     This script is supposed to be called by a button with the script "FindPlayTimer."
///     Should be a child of a gameObject with a DontDestroyOnLoad.
/// </summary>
public class PlayTimer : MonoBehaviour
{
    [SerializeField] private float minutes; // Amount of minutes for timer.

    [SerializeField] private float seconds; // Amount of seconds for timer.

    [FormerlySerializedAs("TimerUI")] [SerializeField]
    private GameObject timerUI; // The Timer UI that displays the timer countdown.

    [FormerlySerializedAs("TextMinutes")] [SerializeField]
    private TMP_Text textMinutes; // The Timer UI text that displays the minutes remaining.

    [FormerlySerializedAs("TextSeconds")] [SerializeField]
    private TMP_Text textSeconds; // The Timer UI text that displays the seconds remaining.

    [SerializeField] private ChangeScenes sceneChanger; // Needs access to a sceneChanger script to move the scene.

    private bool m_IsRunning; // Tracks to see if the Coroutine is still running.

    private Coroutine m_TimerCoroutine; // Stores a reference to the Coroutine so that it can stop and reset it.

    public void StartTimer()
    {
        if (!m_IsRunning)
        {
            // Starts the timer.
            m_TimerCoroutine = StartCoroutine(Timer());
            timerUI.SetActive(true);
            m_IsRunning = true;
        }
        else
        {
            // Restart the timer.
            StopCoroutine(m_TimerCoroutine);
            m_IsRunning = false;
            StartTimer();
        }
    }

    // Coroutine used as a Timer
    private IEnumerator Timer()
    {
        float totalSeconds = minutes * 60f + seconds;
        Debug.Log("Timer started");

        // Main time keep loop.
        while (totalSeconds > 0)
        {
            int displayMinutes = Mathf.FloorToInt(totalSeconds / 60f);
            int displaySeconds = Mathf.FloorToInt(totalSeconds % 60f);

            textMinutes.SetText(displayMinutes.ToString("00"));
            textSeconds.SetText(displaySeconds.ToString("00"));

            yield return new WaitForSecondsRealtime(1f);
            totalSeconds -= 1f;
        }

        // Sets the format of the text for the UI.
        textMinutes.SetText("00");
        textSeconds.SetText("00");

        Debug.Log("Timer ended after a delay of " + minutes + " minutes and " + seconds + " seconds.");

        // Turns off the timer then returns to the Main Menu Scene.
        timerUI.SetActive(false);
        m_IsRunning = false;
        sceneChanger.GoToMainMenuScreen();
    }
}