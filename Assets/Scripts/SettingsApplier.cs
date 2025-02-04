using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class SettingsApplier : MonoBehaviour
{
    private AudioSource[] _audioSources; //List of all the audio sources in the scene
    private float _prevVolume; //Records previous volume setting
    private CustomSettings _customSettings; //Custom settings asset to read the settings from
    private bool _errorMessageDisplayed; //Check to display an error message only once
    private HDAdditionalLightData _lightSource; //The light source of the scene
    private float _lightIntensityBase; //The base intensity of the light source of the scene
    
    // Start is called before the first frame update
    void Start()
    {
        // Assigns variables and finds AudioSource, LightSource
        _errorMessageDisplayed = false;
        _customSettings = LoadCustomSettings();
        _prevVolume = _customSettings.Volume;
        _audioSources = FindObjectsOfType<AudioSource>();
        _lightSource = FindObjectOfType<HDAdditionalLightData>();
        
        // Apply audio
        if (_audioSources != null)
        {
            if (_audioSources.Length == 0)
            {
                Debug.Log("SettingsAppliers: No AudioSources found in this scene.");
            }
            else
            {
                foreach (var VARIABLE in _audioSources)
                {
                    VARIABLE.volume = _prevVolume;
                }
            }
        }
        
        // Apply brightness
        if (_lightSource != null)
        {
            _lightIntensityBase = _lightSource.intensity;
            _lightSource.intensity = _lightIntensityBase * _customSettings.Brighntness;
        }
        
        // Handles null error messaging
        if (_errorMessageDisplayed == false)
        {
            if (_audioSources == null && _lightSource == null)
            {
                Debug.Log("SettingsAppliers: AudioSources and LightSource not initialized.");
                _errorMessageDisplayed = true;
            }
            else if(_lightSource == null){
                Debug.Log("SettingsAppliers: LightSource not initialized.");
                _errorMessageDisplayed = true;
            }
            else if(_audioSources == null){
                Debug.Log("SettingsAppliers: AudioSources not initialized.");
                _errorMessageDisplayed = true;
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Updates Volume
        if (_audioSources != null)
        {
            if (_audioSources.Length == 0 && _errorMessageDisplayed == false) // If there are no audioSources
            {
                Debug.Log("SettingsAppliers: No AudioSources found in this scene.");
                _errorMessageDisplayed = true;
            }
            else if (!Mathf.Approximately(_prevVolume, _customSettings.Volume)) // If the volume has change by a noticeable amount that way it isn't re-writing every update)
            {
                _prevVolume = _customSettings.Volume;
                foreach (var variable in _audioSources)
                {
                    variable.volume = _prevVolume;
                }
            }
        }
        
        // Updates Brightness
        if (_lightSource != null)
        {
            _lightSource.intensity = _lightIntensityBase * _customSettings.Brighntness;
        }
        
        // Handles null error messaging
        if (_errorMessageDisplayed == false)
        {
            if (_audioSources == null && _lightSource == null)
            {
                Debug.Log("SettingsAppliers: AudioSources and LightSource not initialized.");
                _errorMessageDisplayed = true;
            }
            else if(_lightSource == null){
                Debug.Log("SettingsAppliers: LightSource not initialized.");
                _errorMessageDisplayed = true;
            }
            else if(_audioSources == null){
                Debug.Log("SettingsAppliers: AudioSources not initialized.");
                _errorMessageDisplayed = true;
            }
            
        }
        
    }
    
    /// <summary>
    /// This methods retrieves config project settings
    /// </summary>
    /// <returns>CustomSettings</returns>
    private CustomSettings LoadCustomSettings()
    {
        return Resources.Load<CustomSettings>("CustomSettings");
    }
    
}
