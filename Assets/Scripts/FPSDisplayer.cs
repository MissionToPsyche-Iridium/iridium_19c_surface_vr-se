using System;
using System.Collections;
using TMPro;
using UnityEngine;

/// <summary>
/// This class is meant to display the current FPS on the frames Per Second User Interface's attached TMP_Text component.
/// </summary>
public class FPSDisplayer : MonoBehaviour
{
    // Game object that has a TMP_Text component on to be updated
    [SerializeField] 
    private GameObject framesPerSecondUserInterface;

    // The UI TMP_Text object.
    private TMP_Text m_Text;
    
    // If FPS is enabled.
    private bool m_IsFPSEnabled;
    
    private void Awake()
    {
        framesPerSecondUserInterface.SetActive(false);
        var settings = LoadCustomSettings();
        if (settings == null || !settings.FramesPerSecond) return;
        m_IsFPSEnabled = settings.FramesPerSecond;
        framesPerSecondUserInterface.SetActive(true);
        DontDestroyOnLoad(gameObject); // Makes it so this gameObject follows into other scenes.
        m_Text = framesPerSecondUserInterface.GetComponent<TMP_Text>();
        StartCoroutine(checkForUpdate());
    }

    IEnumerator checkForUpdate()
    {
        yield return new WaitForSecondsRealtime(1f);
        m_IsFPSEnabled = LoadCustomSettings().FramesPerSecond;
        StartCoroutine(checkForUpdate());
    }

    private void Update()
    {
        if (!m_IsFPSEnabled)
        {
            framesPerSecondUserInterface.SetActive(false);
            return;
        }
        framesPerSecondUserInterface.SetActive(true);
        if (m_Text != null)
        {
            float timer = 0;
            const float refresh = 0;
            float avgFramerate = 0;
            const string display = "{0} FPS";
            var timelapse = Time.smoothDeltaTime;
            timer = timer <= 0 ? refresh : timer -= timelapse;

            if(timer <= 0) avgFramerate = (int) (1f / timelapse);
            m_Text.text = string.Format(display,avgFramerate.ToString());
        }
        else
        {
            Debug.LogWarning("FPS Displayer: Can not find UI component in " + framesPerSecondUserInterface.name);
        }
    }

    /// <summary>
    /// This methods retrieves config project settings.
    /// </summary>
    /// <returns>CustomSettings</returns>
    private static CustomSettings LoadCustomSettings()
    {
        return Resources.Load<CustomSettings>("CustomSettings");
    }
}
