using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;

[System.Serializable]
public class InfoPoint
{
    public string pointName;  // Name of the info point (e.g., "Point 1", "Point 2")
    public string infoText;   // Text for that info point
}

[System.Serializable]
public class SiteInfo
{
    public string siteName;   // Name of the site (e.g., "Gale Crater")
    public List<InfoPoint> infoPoints;  // List of info points for this site
}

[System.Serializable]
public class SiteData
{
    public List<SiteInfo> sites;  // List of all sites with their info points
}

public class TextReader : MonoBehaviour
{
    public string currentSiteName;  // Set this in Unity Inspector for each Info Point
    public string currentPointName; // Set this in Unity Inspector for each specific point
    public Text infoTextUI;  // Assign this to the UI Text component

    private string jsonFilePath = "TextData";  // JSON file located in Resources folder

    void Start()
    {
        LoadTextForSite();
    }

    void LoadTextForSite()
    {
        // Load the JSON file from Resources
        TextAsset jsonFile = Resources.Load<TextAsset>(jsonFilePath);

        if (jsonFile == null)
        {
            Debug.LogError("TextData.json file not found in Resources!");
            return;
        }

        // Parse JSON
        SiteData siteData = JsonUtility.FromJson<SiteData>(jsonFile.text);

        // Find the correct site and point
        foreach (var site in siteData.sites)
        {
            if (site.siteName == currentSiteName)
            {
                // Search for the correct point within the site
                foreach (var point in site.infoPoints)
                {
                    if (point.pointName == currentPointName)
                    {
                        infoTextUI.text = point.infoText;  // Update UI with the correct text
                        return;
                    }
                }
            }
        }

        Debug.LogWarning($"No text found for site: {currentSiteName} or point: {currentPointName}");
    }
}

