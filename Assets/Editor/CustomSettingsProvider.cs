using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
class CustomSettingsProvider : SettingsProvider
{
    private SerializedObject m_CustomSettings;
    

    const string customSettingsPath = "Assets/Resources/CustomSettings.asset";
    public CustomSettingsProvider(string path, SettingsScope scope = SettingsScope.Project)
        : base(path, scope) {}

    public static bool IsSettingsAvailable()
    {
        return File.Exists(customSettingsPath);
    }

    public override void OnActivate(string searchContext, VisualElement rootElement)
    {
        // This function is called when the user clicks on the MyCustom element in the Settings window.
        m_CustomSettings = CustomSettings.GetSerializedSettings();
    }

    public override void OnGUI(string searchContext)
    {
        // Use IMGUI to display UI:
        EditorGUILayout.PropertyField(m_CustomSettings.FindProperty("isVRMode"));
        m_CustomSettings.ApplyModifiedPropertiesWithoutUndo();
    }

    // Register the SettingsProvider
    [SettingsProvider]
    public static SettingsProvider CreateMyCustomSettingsProvider()
    {
        return new CustomSettingsProvider("Project/Config", SettingsScope.Project);;
    }
}
