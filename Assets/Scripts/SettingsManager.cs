using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEngine.UI;


public class SettingsManager : MonoBehaviour
{
    [SerializeField]
    private GameObject VRModeToggle;
    
    [SerializeField]
    private GameObject BrightnessSlider;
    
    [SerializeField]
    private GameObject VolumeSlider;
    
    public TMP_Dropdown GraphicsDropdown;
    
    [SerializeField]
    private GameObject InteractionFeedbackSlider;
    
    private const string QualityPrefKey = "GraphicsQuality";

    private void Start()
    {
        int savedQualityLevel = PlayerPrefs.GetInt(QualityPrefKey, QualitySettings.GetQualityLevel());
        QualitySettings.SetQualityLevel(savedQualityLevel);
        GraphicsDropdown.value = savedQualityLevel;
        GraphicsDropdown.RefreshShownValue(); 
        
        //Set Settings from the config project settings
        CustomSettings configSettings = loadCustomSettings();
        VRModeToggle.GetComponent<UnityEngine.UI.Toggle>().isOn = configSettings.IsVRMode;
        BrightnessSlider.GetComponent<UnityEngine.UI.Slider>().value = configSettings.Brighntness;
        VolumeSlider.GetComponent<UnityEngine.UI.Slider>().value = configSettings.Volume;
        InteractionFeedbackSlider.GetComponent<UnityEngine.UI.Slider>().value = configSettings.InteractionFeedback;

    }

    public void ChangeGraphicsQuality()
    {
        int selectedQualityLevel = GraphicsDropdown.value;
        QualitySettings.SetQualityLevel(selectedQualityLevel);
        PlayerPrefs.SetInt(QualityPrefKey, selectedQualityLevel); 
        PlayerPrefs.Save();
        UnityEngine.Debug.Log("Current Quality Level: " + QualitySettings.GetQualityLevel());
    }

    // Need to implement actually switching to VR later
    public void ChangeVRMode()
    {
        if (VRModeToggle == null)
        {
            UnityEngine.Debug.LogError("VR Toggle is not assigned!");
            return;
        }
        // Get the toggle's current value
        loadCustomSettings().IsVRMode = VRModeToggle.GetComponent<UnityEngine.UI.Toggle>().isOn;
        
    }
    
    public void ChangeBrightnessLevel()
    {
        if (BrightnessSlider == null)
        {
            UnityEngine.Debug.LogError("Brightness Slider is not assigned!");
            return;
        }
        // Get the slider's current value
        loadCustomSettings().Brighntness = BrightnessSlider.GetComponent<UnityEngine.UI.Slider>().value;

    }
    
    public void ChangeVolumeLevel()
    {
        if (VolumeSlider == null)
        {
            UnityEngine.Debug.LogError("VolumeSlider is not assigned!");
            return;
        }
        // Get the slider's current value
        float selectedVolumeLevel = VolumeSlider.GetComponent<UnityEngine.UI.Slider>().value;
        CustomSettings temp = loadCustomSettings();
        temp.Volume = selectedVolumeLevel;
        
    }
    
    public void ChangeInteractionFeedbackLevel()
    {
        if (InteractionFeedbackSlider == null)
        {
            UnityEngine.Debug.LogError("Interaction Feedback Slider is not assigned!");
            return;
        }
        // Get the slider's current value
        loadCustomSettings().InteractionFeedback = InteractionFeedbackSlider.GetComponent<UnityEngine.UI.Slider>().value;

    }

    private CustomSettings loadCustomSettings()
    {
        return Resources.Load<CustomSettings>("CustomSettings");
    }
}