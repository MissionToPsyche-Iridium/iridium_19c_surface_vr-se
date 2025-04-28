using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.SceneManagement;

public class SettingsApplier : MonoBehaviour
{
    private static SettingsApplier _instance;
    private AudioSource[] m_AudioSources; //List of all the audio sources in the scene
    private Scene m_CurrentScene;
    private CustomSettings m_CustomSettings; //Custom settings asset to read the settings from
    private bool m_ErrorMessageDisplayed; //Check to display an error message only once
    private Exposure m_Exposure; // The exposure of the volume
    private float m_LightIntensityBase; //The base intensity of the light in the scene
    private float m_LightIntensityRange; //The range of intensity of the light in the scene
    private float m_PrevVolume; //Records previous volume setting
    private Volume[] m_Volume; //The light source of the scene

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        // Assigns variables and finds AudioSource, LightSource
        m_ErrorMessageDisplayed = false;
        m_CustomSettings = LoadCustomSettings();
        m_PrevVolume = m_CustomSettings.Volume;
        m_AudioSources = FindObjectsOfType<AudioSource>();
        m_Volume = FindObjectsOfType<Volume>();
        m_LightIntensityRange = 6;
        m_CurrentScene = SceneManager.GetActiveScene();

        // Apply audio
        if (m_AudioSources != null)
        {
            if (m_AudioSources.Length == 0)
                Debug.Log("SettingsAppliers: No AudioSources found in this scene.");
            else
                foreach (AudioSource variable in m_AudioSources)
                {
                    variable.volume = m_PrevVolume;
                    variable.Play();
                }
        }

        // Apply brightness
        for (int i = 0; i < m_Volume.Length; i++)
            if (m_Volume[i].profile.TryGet(out m_Exposure))
                m_Exposure.compensation.value = m_LightIntensityRange * m_CustomSettings.Brightness;


        // Handles null error messaging
        if (m_ErrorMessageDisplayed == false)
        {
            if (m_AudioSources == null && m_Volume == null)
            {
                Debug.Log("SettingsAppliers: AudioSources and LightSource not initialized.");
                m_ErrorMessageDisplayed = true;
            }
            else if (m_Volume == null)
            {
                Debug.Log("SettingsAppliers: LightSource not initialized.");
                m_ErrorMessageDisplayed = true;
            }
            else if (m_AudioSources == null)
            {
                Debug.Log("SettingsAppliers: AudioSources not initialized.");
                m_ErrorMessageDisplayed = true;
            }
        }
    }

    // Update is called once per frame
    private void Update()
    {
        //If the scene isn't the same scene and isn't on a menu scene find new audio sources
        AudioSource[] tempAudioSources = GetComponentsInChildren<AudioSource>();

        if (tempAudioSources.Length > 0)
        {
            if (!isOnMenuScene())
                foreach (AudioSource audioSource in tempAudioSources)
                    audioSource.Stop();
            else
                foreach (AudioSource audioSource in tempAudioSources)
                    if (!audioSource.isPlaying)
                        audioSource.Play();
        }

        m_CurrentScene = SceneManager.GetActiveScene();

        // Updates Volume
        if (m_AudioSources != null)
        {
            if (m_AudioSources.Length == 0 && m_ErrorMessageDisplayed == false) // If there are no audioSources
            {
                Debug.Log("SettingsAppliers: No AudioSources found in this scene.");
                m_ErrorMessageDisplayed = true;
            }
            else if
                (!Mathf.Approximately(m_PrevVolume,
                    m_CustomSettings
                        .Volume)) // If the volume has change by a noticeable amount that way it isn't re-writing every update)
            {
                m_PrevVolume = m_CustomSettings.Volume;
                foreach (AudioSource variable in m_AudioSources)
                    if (variable != null)
                        variable.volume = m_PrevVolume;
            }
        }

        // Updates Brightness
        for (int i = 0; i < m_Volume.Length; i++)
            if (m_Volume[i].profile.TryGet(out m_Exposure))
                m_Exposure.compensation.value = m_LightIntensityRange * m_CustomSettings.Brightness;

        // Handles null error messaging
        if (m_ErrorMessageDisplayed == false)
        {
            if (m_AudioSources == null && m_Volume == null)
            {
                Debug.Log("SettingsAppliers: AudioSources and LightSource not initialized.");
                m_ErrorMessageDisplayed = true;
            }
            else if (m_Volume == null)
            {
                Debug.Log("SettingsAppliers: LightSource not initialized.");
                m_ErrorMessageDisplayed = true;
            }
            else if (m_AudioSources == null)
            {
                Debug.Log("SettingsAppliers: AudioSources not initialized.");
                m_ErrorMessageDisplayed = true;
            }
        }
    }

    public bool isOnMenuScene()
    {
        bool answer = false;
        Scene tempScene = SceneManager.GetActiveScene();
        if (tempScene.Equals(SceneManager.GetSceneByName("AboutScreen"))
            || tempScene.Equals(SceneManager.GetSceneByName("SettingsScreen"))
            || tempScene.Equals(SceneManager.GetSceneByName("MarsMenu"))
            || tempScene.Equals(SceneManager.GetSceneByName("MainMenuVR"))
            || tempScene.Equals(SceneManager.GetSceneByName("CreditsScreen"))
            || tempScene.Equals(SceneManager.GetSceneByName("Quiz")))
            answer = true;

        return answer;
    }


    /// <summary>
    ///     This methods retrieves config project settings
    /// </summary>
    /// <returns>CustomSettings</returns>
    private CustomSettings LoadCustomSettings()
    {
        return Resources.Load<CustomSettings>("CustomSettings");
    }
}