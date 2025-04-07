using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using UnityEngine.XR.Interaction.Toolkit;


/// <summary>
/// C# Script Description: This script is a very short and simple script that plays a sound when the info point sphere object is clicked.
/// The implementation is very similar to the ButtonClickSoundEffect.cs script.
/// </summary>
public class InfoPointClickSound : MonoBehaviour
{
    [SerializeField] private AudioSource infoAudioSource;
    public AudioClip infoClickSound;

    /// <summary>
    /// The XRBaseInteractable component is used to detect when the info point sphere object is clicked by either VR hands grabbing
    /// with the XR Ray Interactor or by the mouse pointer.
    /// </summary>
    void Awake()
    {
        var interactable = GetComponent<XRBaseInteractable>();
        interactable.selectEntered.AddListener(_ => PlayClickSound());
    }

    /// <summary>
    /// This method is called to play the click sound when the info point sphere object is clicked.
    /// </summary>
    public void PlayClickSound()
    {
        UnityEngine.Debug.Log("Sphere clicked!");
        if (infoClickSound != null && infoAudioSource != null)
        {
            infoAudioSource.PlayOneShot(infoClickSound, 1f);
        }
        else
        {
            UnityEngine.Debug.LogWarning("Missing AudioClip or AudioSource.");
        }
    }

    /// <summary>
    /// Just an extra method to play the click sound when the info point sphere object is clicked with the mouse pointer.
    /// </summary>
    void OnMouseDown()
    {
        PlayClickSound();
    }
}
