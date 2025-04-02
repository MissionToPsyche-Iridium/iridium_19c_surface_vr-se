using UnityEngine;
using TMPro;  // Import TextMeshPro namespace
using System.Collections.Generic;

[System.Serializable]
public class InfoPoint
{
    public string pointName;
    public string infoText;
}

[System.Serializable]
public class SiteInfo
{
    public string siteName;
    public List<InfoPoint> infoPoints;
}

[System.Serializable]
public class SiteData
{
    public List<SiteInfo> sites;
}

public class TextReader : MonoBehaviour
{
    public string currentSiteName;
    public string currentPointName;
    public TMP_Text infoTextUI;

    private SiteData siteData;  // Store loaded data
    private string jsonFilePath = "TextData";

    void Start()
    {
        LoadSiteData();
        UpdateText();  // Ensure initial text is loaded
    }

    void LoadSiteData()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>(jsonFilePath);
        if (jsonFile == null)
        {
            Debug.LogError("TextData.json file not found in Resources!");
            return;
        }
        siteData = JsonUtility.FromJson<SiteData>(jsonFile.text);
    }

    public void UpdateText()
    {
        if (siteData == null)
        {
            Debug.LogError("Site data is not loaded!");
            return;
        }

        foreach (var site in siteData.sites)
        {
            if (site.siteName.Trim() == currentSiteName.Trim())
            {
                foreach (var point in site.infoPoints)
                {
                    if (point.pointName.Trim() == currentPointName.Trim())
                    {
                        infoTextUI.text = point.infoText;
                        return;
                    }
                }
            }
        }

        Debug.LogWarning($"No text found for site: {currentSiteName} or point: {currentPointName}");
    }

    // Call this method externally when you change the site or point
    public void SetInfo(string newSite, string newPoint)
    {
        currentSiteName = newSite;
        currentPointName = newPoint;
        UpdateText();  // Refresh the displayed text
    }
}

