#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEngine.UIElements;

internal class CustomSettingsProvider : SettingsProvider
{
    // Path to save the custom config settings
    private const string CustomSettingsPath = "Assets/Resources/CustomSettings.asset";
    private SerializedObject m_CustomSettings;

    private CustomSettingsProvider(string path, SettingsScope scope = SettingsScope.Project)
        : base(path, scope)
    {
    }

    public static bool IsSettingsAvailable()
    {
        return File.Exists(CustomSettingsPath);
    }

    public override void OnActivate(string searchContext, VisualElement rootElement)
    {
        m_CustomSettings = CustomSettings.GetSerializedSettings();
    }

    public override void OnGUI(string searchContext)
    {
        m_CustomSettings.Update();

        EditorGUILayout.PropertyField(m_CustomSettings.FindProperty("brightness"));
        EditorGUILayout.PropertyField(m_CustomSettings.FindProperty("volume"));
        EditorGUILayout.PropertyField(m_CustomSettings.FindProperty("interactionFeedback"));
        EditorGUILayout.PropertyField(m_CustomSettings.FindProperty("framesPerSecond"));

        m_CustomSettings.ApplyModifiedPropertiesWithoutUndo();
    }

    [SettingsProvider]
    public static SettingsProvider CreateMyCustomSettingsProvider()
    {
        return new CustomSettingsProvider("Project/Config");
    }
}

#endif