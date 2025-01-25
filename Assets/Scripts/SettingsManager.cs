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

    public TMP_Dropdown GraphicsDropdown;
    
    [SerializeField]
    private GameObject VolumeSlider;

    
    private const string QualityPrefKey = "GraphicsQuality";

    private void Start()
    {
        int savedQualityLevel = PlayerPrefs.GetInt(QualityPrefKey, QualitySettings.GetQualityLevel());
        QualitySettings.SetQualityLevel(savedQualityLevel);
        GraphicsDropdown.value = savedQualityLevel;
        GraphicsDropdown.RefreshShownValue(); 
        
        //Set Volume from the config
        VolumeSlider.GetComponent<UnityEngine.UI.Slider>().value = loadCustomSettings().Volume;
    }

    public void ChangeGraphicsQuality()
    {
        int selectedQualityLevel = GraphicsDropdown.value;
        QualitySettings.SetQualityLevel(selectedQualityLevel);
        PlayerPrefs.SetInt(QualityPrefKey, selectedQualityLevel); 
        PlayerPrefs.Save();
        UnityEngine.Debug.Log("Current Quality Level: " + QualitySettings.GetQualityLevel());
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
    
    

    private CustomSettings loadCustomSettings()
    {
        return Resources.Load<CustomSettings>("CustomSettings");
    }
}