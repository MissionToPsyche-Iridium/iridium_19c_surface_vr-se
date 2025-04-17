using UnityEngine;
using UnityEditor;
using System.IO;

/// <summary>
/// Utility class for converting a TSV (Tab-Separated Values) file into 
/// ScriptableObject assets for storing quiz questions (Resources/Questions folder). 
/// </summary>
public class TSVtoSO 
{
    private static string questionsTSVPath = "/Editor/TSVs/Questions.tsv";
    private static string questionsPath = "Assets/Resources/Questions/";
    private static int numberOfAnswers = 4;

    [MenuItem("Utilities/Generate Questions")]

    /// <summary>
    /// Generates question assets from a TSV file and stores them as ScriptableObjects.
    /// </summary>
    public static void GenerateQuestions()
    {
        // Read all lines from the TSV file
        string[] allLines = File.ReadAllLines(Application.dataPath + questionsTSVPath);
        int questionNumber = 1;

        foreach (string s in allLines)
        {
            string[] splitData = s.Split('\t');

            // TSV (TAB SEPARATED VALUE) DATA FORMAT:
            // COLUMN 1: QUESTION
            // COLUMN 2: CORRECT ANSWER
            // COLUMN 3-5: WRONG ANSWERS

            // Create a new QuestionData ScriptableObject instance
            QuestionData questionData = ScriptableObject.CreateInstance<QuestionData>();
            
            // Assign question text from the TSV data
            questionData.question = splitData[0]; 

            // Initialize the array of answers
            questionData.answers = new string[4];

            // Ensure the target directory exists before saving assets
            if (!Directory.Exists(questionsPath))
            {
                Directory.CreateDirectory(questionsPath);
            }

            // Assign answers from the TSV file
            for (int i = 0; i < numberOfAnswers; i++)
            {
                questionData.answers[i] = splitData[1 + i];
            }

            // Create file name
            questionData.name = "Question" + questionNumber;
            questionNumber++;

            // Save the ScriptableObject as an asset
            AssetDatabase.CreateAsset(questionData, $"{questionsPath}/{questionData.name}.asset");
        }

        // Save all created assets to the Unity database
        AssetDatabase.SaveAssets();

        Debug.Log("Questions generated");
    }
}
