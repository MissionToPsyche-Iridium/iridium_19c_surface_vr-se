using UnityEngine.Audio;
using System;
using UnityEngine;

//Credit to Brackeys youtube tutorial on Audio managers, as the majority of this code and learning how to use it was made by him.
[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0, 1)]
    public float volume;
    [Range(-3, 3)]
    public float pitch;
    public bool loop = false;
    public bool playOnAwake = false;
    public AudioSource source;

    public Sound()
    {
        volume = 1;
        pitch = 1;
        loop = false;
    }
}

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager Instance;
    //AudioManager

    void Awake()
    {
        Instance = this;

        foreach (Sound s in sounds)
        {
            if (!s.source)
                s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;
            s.source.playOnAwake = s.playOnAwake;
            if (s.playOnAwake)
                s.source.Play();

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string newName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == newName);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + newName + " not found");
            return;
        }

        s.source.Play();
    }

    public void Stop(string newName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == newName);

        s.source.Stop();
    }
}