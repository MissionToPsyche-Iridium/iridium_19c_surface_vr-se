using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsApplier : MonoBehaviour
{
    private AudioSource[] AudioSources;

    private float prevVolume;

    private CustomSettings _customSettings;
    // Start is called before the first frame update
    void Start()
    {
        _customSettings = LoadCustomSettings();
        prevVolume = _customSettings.Volume;
        AudioSources = FindObjectsOfType<AudioSource>();
        if (AudioSources != null)
        {
            foreach (var VARIABLE in AudioSources)
            {
                VARIABLE.volume = prevVolume;
            }
        }
        else
        {
            Debug.Log("SettingsAppliers: AudioSources not initialized.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (AudioSources != null)
        {
            if (!Mathf.Approximately(prevVolume, _customSettings.Volume) ) // If the volume has change by a noticeable amount that way it isn't re-writing every update
            {
                prevVolume = _customSettings.Volume;
                foreach (var VARIABLE in AudioSources)
                {
                    VARIABLE.volume = prevVolume;
                }
            
            }
        }
        else
        {
            Debug.Log("SettingsAppliers: AudioSources not initialized.");
        }
        
    }
    
    private CustomSettings LoadCustomSettings()
    {
        return Resources.Load<CustomSettings>("CustomSettings");
    }
    
}
