using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CustomSettings : ScriptableObject
{
     public const string customSettingsPath = "Assets/Resources/CustomSettings.asset";

    [SerializeField]
    private bool isVRMode;


    internal static CustomSettings GetOrCreateSettings()
    {
        var settings = AssetDatabase.LoadAssetAtPath<CustomSettings>(customSettingsPath);
        if (settings == null)
        {
            settings = ScriptableObject.CreateInstance<CustomSettings>();
            settings.isVRMode = true;
            AssetDatabase.CreateAsset(settings, customSettingsPath);
            AssetDatabase.SaveAssets();
        }
        return settings;
    }

    internal static SerializedObject GetSerializedSettings()
    {
        return new SerializedObject(GetOrCreateSettings());
    }
}
