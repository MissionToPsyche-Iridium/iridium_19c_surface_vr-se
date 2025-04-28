using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystemModule : MonoBehaviour
{

    private AudioSource m_AmbientSoundPlayer;

    private AudioClip[] m_AmbientSounds;
    private int m_CurrentSound = 0;
    // Start is called before the first frame update
    void Start()
    {
        m_AmbientSounds = Resources.LoadAll<AudioClip>("Audio/Ambient Sounds"); // Loads all audio clips to an array

        // Gets the audioSource 
        m_AmbientSoundPlayer = GetComponent<AudioSource>();
        if(m_AmbientSoundPlayer != null) // Makes sure the audio source exists
        {
            if(m_AmbientSounds != null)
            {
                m_AmbientSoundPlayer.clip = m_AmbientSounds[m_CurrentSound]; // Sets the first audio clip
                m_AmbientSoundPlayer.Play(); // Plays the audio
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_AmbientSoundPlayer.isPlaying) // Switches to next sound after the current sound has stopped
        {
            m_AmbientSoundPlayer.clip = m_AmbientSounds[(++m_CurrentSound) % m_AmbientSounds.Length]; // Switches to next sound in the lists of Ambient Sounds
            m_AmbientSoundPlayer.Play(); // Plays the audio
        }
    }
    
    
    
}
