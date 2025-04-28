using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetOptionFromUI : MonoBehaviour
{
    public Scrollbar volumeSlider;
    public TMP_Dropdown turnDropdown;
    public SetTurnTypeFromPlayerPref turnTypeFromPlayerPref;

    private void Start()
    {
        volumeSlider.onValueChanged.AddListener(SetGlobalVolume);
        turnDropdown.onValueChanged.AddListener(SetTurnPlayerPref);

        if (PlayerPrefs.HasKey("turn"))
            turnDropdown.SetValueWithoutNotify(PlayerPrefs.GetInt("turn"));
    }

    /// <summary>
    /// Changes value of the audio listener.
    /// </summary>
    /// <param name="value"> The new value of volume. </param>
    private static void SetGlobalVolume(float value)
    {
        AudioListener.volume = value;
    }

    /// <summary>
    /// Turns the Player Pref by given value.
    /// </summary>
    /// <param name="value"> The value to turn the Player Pref.</param>
    private void SetTurnPlayerPref(int value)
    {
        PlayerPrefs.SetInt("turn", value);
        turnTypeFromPlayerPref.ApplyPlayerPref();
    }
}