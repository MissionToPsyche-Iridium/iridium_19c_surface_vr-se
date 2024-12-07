using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystemModule : MonoBehaviour
{

    private AudioSource ambientSoundPlayer;

    [Range(0, 100)]
    public float ambientSoundVolume = 50;

    private AudioClip[] ambientSounds;
    private int currentSound = 0;
    // Start is called before the first frame update
    void Start()
    {
        ambientSounds = Resources.LoadAll<AudioClip>("Audio/Ambient Sounds"); // Loads all audio clips to an array

        // Gets the audioSource 
        ambientSoundPlayer = GetComponent<AudioSource>();
        if(ambientSoundPlayer != null) // Makes sure the audio source exists
        {
            if(ambientSounds != null)
            {
                ambientSoundPlayer.clip = ambientSounds[currentSound]; // Sets the first audio clip
                ambientSoundPlayer.volume = ambientSoundVolume / 100; // Sets volume
                ambientSoundPlayer.Play(); // Plays the audio
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!ambientSoundPlayer.isPlaying) // Switches to next sound after the current sound has stopped
        {
            ambientSoundPlayer.clip = ambientSounds[(++currentSound) % ambientSounds.Length]; // Switches to next sound in the lists of Ambient Sounds
            ambientSoundPlayer.Play(); // Plays the audio
        }
        ambientSoundPlayer.volume = ambientSoundVolume / 100; // Sets volume
    }
}
