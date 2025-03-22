using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class CustomSettings : ScriptableObject
{
    // Path to save the custom config settings
    private const string CustomSettingsPath = "Assets/Resources/CustomSettings.asset";

#if UNITY_EDITOR
    private static CustomSettings GetOrCreateSettings()
    {
        var settings = AssetDatabase.LoadAssetAtPath<CustomSettings>(CustomSettingsPath);
        if (settings != null) return settings;
        // Default variables and their initial values
        settings = ScriptableObject.CreateInstance<CustomSettings>();
        settings.brightness = 0.5f;
        settings.volume = 0.5f;
        settings.interactionFeedback = 0.5f;
        AssetDatabase.CreateAsset(settings, CustomSettingsPath);
        AssetDatabase.SaveAssets();
        return settings;
    }

    internal static SerializedObject GetSerializedSettings()
    {
        return new SerializedObject(GetOrCreateSettings());
    }
#endif

    [SerializeField, Range(0, 1)] private float brightness;
    public float Brighntness
    {
        get => brightness;
        set
        {
            if (Mathf.Approximately(brightness, value)) return;
            brightness = value;
            Save();
        }
    }

    [SerializeField, Range(0, 1)] private float volume;
    public float Volume
    {
        get => volume;
        set
        {
            if (Mathf.Approximately(volume, value)) return;
            volume = value;
            Save();
        }
    }

    [SerializeField, Range(0, 1)] private float interactionFeedback;
    public float InteractionFeedback
    {
        get => interactionFeedback;
        set
        {
            if (Mathf.Approximately(interactionFeedback, value)) return;
            interactionFeedback = value;
            Save();
        }
    }

    private void Save()
    {
        #if UNITY_EDITOR
                EditorUtility.SetDirty(this);
                AssetDatabase.SaveAssets();
        #endif
    }
}
