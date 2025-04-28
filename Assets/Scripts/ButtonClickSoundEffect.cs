using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// C# Script Description: This script is mean to be a simple implementation of 
/// adding sound effects to button click events for each individual button.
/// </summary>
[RequireComponent(typeof(Button))] // This component makes sure that Button component is attached to the GameObject
public class ButtonClickSoundEffect : MonoBehaviour
{
    [SerializeField] private AudioClip soundEffectForButton;
    private AudioSource m_SourceForAudio;
    private Button m_Button;

    /// <summary>
    /// Awake function for when the script instance is being loaded.
    /// It then initializes the AudioSource and registers the click event listener. 
    /// </summary>
    void Awake()
    {
        // Attempt to get an AudioSource from the main camera
        if (Camera.main != null) m_SourceForAudio = Camera.main.GetComponent<AudioSource>();
        if (m_SourceForAudio == null)
        {
            UnityEngine.Debug.LogWarning("AudioSource component for Camera GameObject is missing.");
        }

        m_Button = GetComponent<Button>();
        m_Button.onClick.AddListener(PlayForSoundEffect);

    }

    /// <summary>
    /// Function for playing the assigned click sound utilizing the AudioSource.
    /// Gets called when the button is clicked.
    /// </summary>
    void PlayForSoundEffect()
    {
        // Play sound effect here
        if (m_SourceForAudio != null && soundEffectForButton != null)
        {
            m_SourceForAudio.PlayOneShot(soundEffectForButton);
        }
    }
}
