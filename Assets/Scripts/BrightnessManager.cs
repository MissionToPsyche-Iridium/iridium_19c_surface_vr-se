using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.UI;

public class BrightnessManager : MonoBehaviour
{
    // Reference to the global volume
    public Volume globalVolume;
    // Exposure component for adjusting brightness
    private Exposure exposure;    

    void Awake()
    {
        // Make this object persist across scenes
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        // Find the global volume in the scene
        Volume foundVolume = FindObjectOfType<Volume>();
        if (globalVolume != null)
        {
            UnityEngine.Debug.Log("Global Volume found or created.");
        }

        // Get the exposure component from the global volume profile
        if (globalVolume.profile.TryGet(out exposure))
        {
            UnityEngine.Debug.Log("Exposure component found.");
            AdjustBrightness(SettingsManager.Instance.brightnessValue);
        }
        else
        {
            UnityEngine.Debug.LogError("Exposure component not found in the global volume.");
        }
    }

    // Adjust the brightness by modifying exposure
    public void AdjustBrightness(float value)
    {
        if (exposure != null)
        {
            
            exposure.fixedExposure.value = Mathf.Lerp(-2f, 2f, value);
        }
        else
        {
            UnityEngine.Debug.LogError("Exposure component is null.");
        }
    }

    // Update brightness from the slider and save it in SettingsManager
    public void UpdateBrightnessFromSlider(float value)
    {
        SettingsManager.Instance.UpdateBrightness(value);
        AdjustBrightness(value);
    }

    // Set brightness using the value from SettingsManager
    public void SetBrightness()
    {
        AdjustBrightness(SettingsManager.Instance.brightnessValue);
    }
}
