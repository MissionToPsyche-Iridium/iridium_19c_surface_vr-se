using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.IO;

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

    private SiteData siteData;
    private string jsonFileName = "TextData.json";

    void Start()
    {
        LoadSiteData();
        UpdateText();  // Initial update
    }

    void LoadSiteData()
    {
        string fullPath = Path.Combine(Application.streamingAssetsPath, jsonFileName);

        if (!File.Exists(fullPath))
        {
            Debug.LogError("TextData.json file not found in StreamingAssets!");
            return;
        }

        string jsonText = File.ReadAllText(fullPath);
        siteData = JsonUtility.FromJson<SiteData>(jsonText);
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

    public void SetInfo(string newSite, string newPoint)
    {
        currentSiteName = newSite;
        currentPointName = newPoint;
        UpdateText();
    }
}

