using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CustomSettings : ScriptableObject
{

    
    internal static CustomSettings GetOrCreateSettings()
    {
        var settings = AssetDatabase.LoadAssetAtPath<CustomSettings>(customSettingsPath);
        if (settings == null)
        {
            settings = ScriptableObject.CreateInstance<CustomSettings>();
            settings.isVRMode = true;
            settings.brightness = 0.5f;
            settings.volume = 0.5f;
            settings.isVRMode = true;
            settings.interactionFeedback = 0.5f;
            AssetDatabase.CreateAsset(settings, customSettingsPath);
            AssetDatabase.SaveAssets();
        }
        return settings;
    }

    internal static SerializedObject GetSerializedSettings()
    {
        return new SerializedObject(GetOrCreateSettings());
    }
    
     public const string customSettingsPath = "Assets/Resources/CustomSettings.asset";

    [SerializeField]
    private bool isVRMode;
    public bool IsVRMode
    {
        get => isVRMode;
        set
        {
            isVRMode = value;
            Save();
        }
    }
    
    [SerializeField]
    [Range(0,1)]
    private float brightness;
    public float Brighntness
    {
        get => brightness;
        set
        {
            if (!Mathf.Approximately(brightness, value))
            {
                brightness = value;
                Save();
            }
        }
    
    }
    
    [SerializeField]
    [Range(0,1)]
    private float volume;
    public float Volume
    {
        get => volume;
        set
        {
            if (Mathf.Approximately(volume, value)) return; // Doesn't change if it is about the right value
            volume = value;
            Save();
        }
    
    }
    
    [SerializeField]
    [Range(0,1)]
    private float interactionFeedback;
    public float InteractionFeedback
    {
        get => interactionFeedback;
        set
        {
            if (Mathf.Approximately(interactionFeedback, value)) return; // Doesn't change if it is about the right value
            interactionFeedback = value;
            Save();
        }
    
    }
    
    // Centralized save methoda
    private void Save()
    {
        EditorUtility.SetDirty(this); // Used to mark the asset as dirty so it gets saved
        AssetDatabase.SaveAssets();  // Save changes to disk
    }
}
