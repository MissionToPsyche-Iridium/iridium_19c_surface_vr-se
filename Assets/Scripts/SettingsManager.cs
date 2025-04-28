using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    private const string QualityPrefKey = "GraphicsQuality";

    [FormerlySerializedAs("BrightnessSlider")] [SerializeField] private GameObject brightnessSlider;

    [FormerlySerializedAs("VolumeSlider")] [SerializeField] private GameObject volumeSlider;

    [FormerlySerializedAs("GraphicsDropdown")] public TMP_Dropdown graphicsDropdown;

    [FormerlySerializedAs("InteractionFeedbackSlider")] [SerializeField] private GameObject interactionFeedbackSlider;

    [SerializeField] private GameObject framesPerSecondToggle;

    private void Start()
    {
        int savedQualityLevel = PlayerPrefs.GetInt(QualityPrefKey, QualitySettings.GetQualityLevel());
        QualitySettings.SetQualityLevel(savedQualityLevel);
        graphicsDropdown.value = savedQualityLevel;
        graphicsDropdown.RefreshShownValue();

        //Set Settings from the config project settings
        CustomSettings configSettings = LoadCustomSettings();
        brightnessSlider.GetComponent<Slider>().value = configSettings.Brightness;
        volumeSlider.GetComponent<Slider>().value = configSettings.Volume;
        interactionFeedbackSlider.GetComponent<Slider>().value = configSettings.InteractionFeedback;
        framesPerSecondToggle.GetComponent<Toggle>().isOn = configSettings.FramesPerSecond;
    }

    public void ChangeGraphicsQuality()
    {
        int selectedQualityLevel = graphicsDropdown.value;
        QualitySettings.SetQualityLevel(selectedQualityLevel);
        PlayerPrefs.SetInt(QualityPrefKey, selectedQualityLevel);
        PlayerPrefs.Save();
        Debug.Log("Current Quality Level: " + QualitySettings.GetQualityLevel());
    }

    public void ChangeBrightnessLevel()
    {
        if (brightnessSlider == null)
        {
            Debug.LogError("Brightness Slider is not assigned!");
            return;
        }

        // Get the slider's current value
        LoadCustomSettings().Brightness = brightnessSlider.GetComponent<Slider>().value;
    }

    public void ChangeVolumeLevel()
    {
        if (volumeSlider == null)
        {
            Debug.LogError("VolumeSlider is not assigned!");
            return;
        }

        // Get the slider's current value
        float selectedVolumeLevel = volumeSlider.GetComponent<Slider>().value;
        CustomSettings temp = LoadCustomSettings();
        temp.Volume = selectedVolumeLevel;
    }

    public void ChangeInteractionFeedbackLevel()
    {
        if (interactionFeedbackSlider == null)
        {
            Debug.LogError("Interaction Feedback Slider is not assigned!");
            return;
        }

        // Get the slider's current value
        LoadCustomSettings().InteractionFeedback = interactionFeedbackSlider.GetComponent<Slider>().value;
    }

    public void ChangeFramesPerSecondToggle()
    {
        if (framesPerSecondToggle == null)
        {
            Debug.LogError("Frames Per Second Toggle is not assigned");
            return;
        }

        // Get the toggle's current value
        bool selectedFramesPerSecond = framesPerSecondToggle.GetComponent<Toggle>().isOn;
        CustomSettings temp = LoadCustomSettings();
        temp.FramesPerSecond = selectedFramesPerSecond;
    }

    private static CustomSettings LoadCustomSettings()
    {
        return Resources.Load<CustomSettings>("CustomSettings");
    }
}