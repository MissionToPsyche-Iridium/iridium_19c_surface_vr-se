using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;


/// <summary>
/// C# Script Description: This script is a very short and simple script that plays a sound when the info point sphere object is clicked.
/// The implementation is very similar to the ButtonClickSoundEffect.cs script.
/// </summary>
public class InfoPointClickSound : MonoBehaviour
{
    [SerializeField] private AudioSource infoPointClickSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        // Get the AudioSource component attached to this GameObject
        infoPointClickSound = GetComponent<AudioSource>();
    }
}
