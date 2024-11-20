using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using TMPro;

public class SettingsManager : MonoBehaviour
{

    public TMP_Dropdown GraphicsDropdown;

    private const string QualityPrefKey = "GraphicsQuality";

    private void Start()
    {
        int savedQualityLevel = PlayerPrefs.GetInt(QualityPrefKey, QualitySettings.GetQualityLevel());
        QualitySettings.SetQualityLevel(savedQualityLevel);
        GraphicsDropdown.value = savedQualityLevel;
        GraphicsDropdown.RefreshShownValue(); 
    }

    public void ChangeGraphicsQuality()
    {
        int selectedQualityLevel = GraphicsDropdown.value;
        QualitySettings.SetQualityLevel(selectedQualityLevel);
        PlayerPrefs.SetInt(QualityPrefKey, selectedQualityLevel); 
        PlayerPrefs.Save();
        UnityEngine.Debug.Log("Current Quality Level: " + QualitySettings.GetQualityLevel());
    }


}