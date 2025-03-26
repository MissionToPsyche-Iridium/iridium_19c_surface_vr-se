using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json;

public class TextReader : MonoBehaviour
{
    [System.Serializable]
    public class TextData
    {
        public string introText;
        public string descriptionText;
    }

    public Text introTextUI;  // Drag the UI Text component for intro text here
    public Text descriptionTextUI;  // Drag the UI Text component for description text here

    private string jsonFilePath = "Assets/Resources/TextData.json";  // Path to your JSON file

    void Start()
    {
        // Check if the file exists
        if (File.Exists(jsonFilePath))
        {
            string json = File.ReadAllText(jsonFilePath);
            TextData textData = JsonConvert.DeserializeObject<TextData>(json);

            // Assign the read text to UI elements
            introTextUI.text = textData.introText;
            descriptionTextUI.text = textData.descriptionText;
        }
        else
        {
            Debug.LogError("TextData.json file not found!");
        }
    }
}
