using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class TextReader : MonoBehaviour
{
    // classes for the JSON structure
    [System.Serializable]
    public class InfoPoint
    {
        public string pointName;
        public string infoText;
    }

    [System.Serializable]
    public class Site
    {
        public string siteName;
        public List<InfoPoint> infoPoints;
    }

    [System.Serializable]
    public class SiteData
    {
        public List<Site> sites;
    }

    // current site name to be set in Unity Inspector
    public string currentSiteName = "Mars Site 3";

    // reference to the TextMeshProUGUI component
    public TextMeshProUGUI infoTextUI;

    // instance of SiteData to hold parsed JSON data
    private SiteData siteData;

    void Start()
    {
        LoadSiteData();
        UpdateText();
    }

    void Update()
    {
        // press R to reload JSON and update the text
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("🔄 R key pressed. Reloading JSON data...");
            LoadSiteData();
            UpdateText();
        }
    }

    // method to load the JSON file and parse it into siteData
    void LoadSiteData()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "TextData.json");

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            siteData = JsonUtility.FromJson<SiteData>(json);
            Debug.Log("✅ JSON loaded successfully.");
        }
        else
        {
            Debug.LogError("❌ JSON file not found at: " + filePath);
        }
    }

    // method to update the UI text based on currentSiteName and GameObject name
    public void UpdateText()
    {
        if (siteData == null)
        {
            Debug.LogError("⚠️ Site data is null. Make sure JSON is loaded properly.");
            return;
        }

        // use the GameObject name as the pointName
        string currentPointName = gameObject.name;

        Debug.Log($"🔍 Searching for site: {currentSiteName}, info point: {currentPointName}");

        foreach (var site in siteData.sites)
        {
            Debug.Log($"📍 Found site: {site.siteName}");

            if (site.siteName == currentSiteName)
            {
                foreach (var point in site.infoPoints)
                {
                    Debug.Log($"   ↪ Checking point: {point.pointName}");

                    if (point.pointName == currentPointName)
                    {
                        if (infoTextUI != null)
                        {
                            infoTextUI.text = point.infoText;
                            Debug.Log($"✅ Text set for '{currentPointName}': {point.infoText}");
                        }
                        else
                        {
                            Debug.LogError("❌ infoTextUI is not assigned in the Inspector.");
                        }
                        return;
                    }
                }

                Debug.LogWarning($"⚠️ Info point '{currentPointName}' not found in site '{currentSiteName}'.");
                return;
            }
        }

        Debug.LogWarning($"⚠️ Site '{currentSiteName}' not found in the JSON.");
    }
}


