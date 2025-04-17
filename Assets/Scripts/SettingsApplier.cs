using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.SceneManagement;

public class SettingsApplier : MonoBehaviour
{
    private AudioSource[] _audioSources; //List of all the audio sources in the scene
    private float _prevVolume; //Records previous volume setting
    private CustomSettings _customSettings; //Custom settings asset to read the settings from
    private bool _errorMessageDisplayed; //Check to display an error message only once
    private Volume[] _volume; //The light source of the scene
    private Exposure _exposure; // The exposure of the volume
    private float _lightIntensityBase; //The base intensity of the light in the scene
    private float _lightIntensityRange; //The range of intensity of the light in the scene
    private Scene _currentScene;
    
    public static SettingsApplier instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        // Assigns variables and finds AudioSource, LightSource
        _errorMessageDisplayed = false;
        _customSettings = LoadCustomSettings();
        _prevVolume = _customSettings.Volume;
        _audioSources = FindObjectsOfType<AudioSource>();
        _volume = FindObjectsOfType<Volume>();
        _lightIntensityRange = 6;
        _currentScene = SceneManager.GetActiveScene();
        
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
                    VARIABLE.Play();
                }
            }
        }
        
        // Apply brightness
        for (int i = 0; i < _volume.Length; i++)
        {
            if (_volume[i].profile.TryGet(out _exposure))
            {
                _exposure.compensation.value = (_lightIntensityRange * _customSettings.Brighntness);
            }
        }
        
        
        // Handles null error messaging
        if (_errorMessageDisplayed == false)
        {
            if (_audioSources == null && _volume == null)
            {
                Debug.Log("SettingsAppliers: AudioSources and LightSource not initialized.");
                _errorMessageDisplayed = true;
            }
            else if(_volume == null){
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
        //If the scene isn't the same scene and isn't on a menu scene find new audio sources
        AudioSource[] tempAudioSources = GetComponentsInChildren<AudioSource>();

        if (tempAudioSources.Length > 0) 
        {
            if (!isOnMenuScene())
            {
                foreach (var audioSource in tempAudioSources)
                {
                    audioSource.Stop();
                }
            }
            else
            {
                foreach (var audioSource in tempAudioSources)
                {
                    if (!audioSource.isPlaying)
                    {
                        audioSource.Play();
                    }
                }
            }
        }

        _currentScene = SceneManager.GetActiveScene();
        
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
                    if (variable != null)
                    {
                        variable.volume = _prevVolume;
                    }
                }
            }
        }
        
        // Updates Brightness
        for (int i = 0; i < _volume.Length; i++)
        {
            if (_volume[i].profile.TryGet(out _exposure))
            {
                _exposure.compensation.value = (_lightIntensityRange * _customSettings.Brighntness);
            }
        }
        
        // Handles null error messaging
        if (_errorMessageDisplayed == false)
        {
            if (_audioSources == null && _volume == null)
            {
                Debug.Log("SettingsAppliers: AudioSources and LightSource not initialized.");
                _errorMessageDisplayed = true;
            }
            else if(_volume == null){
                Debug.Log("SettingsAppliers: LightSource not initialized.");
                _errorMessageDisplayed = true;
            }
            else if(_audioSources == null){
                Debug.Log("SettingsAppliers: AudioSources not initialized.");
                _errorMessageDisplayed = true;
            }
            
        }

        
        
    }

    public bool isOnMenuScene()
    {
        var answer = false;
        var tempScene = SceneManager.GetActiveScene();
        if (tempScene.Equals(SceneManager.GetSceneByName("AboutScreen"))
            || tempScene.Equals(SceneManager.GetSceneByName("SettingsScreen"))
            || tempScene.Equals(SceneManager.GetSceneByName("MarsMenu"))
            || tempScene.Equals(SceneManager.GetSceneByName("MainMenuVR"))
            || tempScene.Equals(SceneManager.GetSceneByName("CreditsScreen"))
            || tempScene.Equals(SceneManager.GetSceneByName("Quiz")))
        {
            answer = true;
        }
        
        return answer;
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
