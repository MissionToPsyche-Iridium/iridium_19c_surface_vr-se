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
            settings.volume = 0.5f;
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
        set => isVRMode = value;
    }
    
    [SerializeField]
    [Range(0,1)]
    private float volume;
    public float Volume
    {
        get => volume;
        set
        {
            if (Mathf.Approximately(volume, value)) return; // Avoid unnecessary updates
            volume = value;
        }
    
    }
    
}
