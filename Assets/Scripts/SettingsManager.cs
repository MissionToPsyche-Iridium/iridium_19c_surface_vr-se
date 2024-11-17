using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    // Singleton instance
    public static SettingsManager Instance;

    // Brightness value
    [Range(0, 1)]
    public float brightnessValue = 0.5f;

    private const string BrightnessPrefKey = "BrightnessValue";

    private void Awake()
    {
        // Singleton Pattern
        if (Instance == null)
        {
            Instance = this;
            // Persist across scenes
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            // Destroy duplicate
            Destroy(gameObject); 
            return;
        }

        // Load saved brightness value
        brightnessValue = PlayerPrefs.GetFloat(BrightnessPrefKey, 0.5f);
        UnityEngine.Debug.Log("Loaded brightness value: " + brightnessValue);
    }

    // Update brightness and save it
    public void UpdateBrightness(float value)
    {
        brightnessValue = value;
        PlayerPrefs.SetFloat(BrightnessPrefKey, value);
        PlayerPrefs.Save();
        UnityEngine.Debug.Log("Brightness updated to: " + brightnessValue);
        FindObjectOfType<BrightnessManager>().AdjustBrightness(brightnessValue);
    }

    // Apply the brightness value
    public void SetBrightness()
    {
        FindObjectOfType<BrightnessManager>().AdjustBrightness(brightnessValue);
    }
}