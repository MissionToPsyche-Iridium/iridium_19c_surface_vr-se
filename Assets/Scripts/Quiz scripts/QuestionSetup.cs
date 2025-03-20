using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Manages quiz questions and answer button setup.
/// Randomly selects a question, assigns answers to buttons, and ensures correct answer placement.
/// </summary>
public class QuestionSetup : MonoBehaviour
{
    [SerializeField]
    public List<QuestionData> questions; 
    private QuestionData currentQuestion;

    [SerializeField]
    private TextMeshProUGUI questionText; // UI component displaying the question
    
    [SerializeField]
    private AnswerButton[] answerButtons;

    [SerializeField]
    private int correctAnswerChoice; 

    private void Awake()
    {
        // Load all question assets when the scene starts
        GetQuestionAssets();
    }

    /// <summary>
    /// Initializes the quiz by selecting and displaying a new question.
    /// </summary>
    public void Start()
    {
        SelectNewQuestion();
        SetQuestionValues();
        SetAnswerValues();
    }

    /// <summary>
    /// Loads all question assets from the "Resources/Questions" folder.
    /// </summary>
    private void GetQuestionAssets()
    {
        questions = new List<QuestionData>(Resources.LoadAll<QuestionData>("Questions"));
    }

    /// <summary>
    /// Selects a random question from the list and removes it to prevent repetition.
    /// </summary>
    private void SelectNewQuestion()
    {
        int randomQuestionIndex = Random.Range(0, questions.Count);
        currentQuestion = questions[randomQuestionIndex];
        questions.RemoveAt(randomQuestionIndex);
    }

    /// <summary>
    /// Sets the UI text to display the selected question.
    /// </summary>
    private void SetQuestionValues()
    {
        questionText.text = currentQuestion.question;
    }

    /// <summary>
    /// Assigns randomized answer choices to the buttons.
    /// </summary>
    private void SetAnswerValues()
    {
        List<string> answers = RandomizeAnswers(new List<string>(currentQuestion.answers));

        for (int i = 0; i < answerButtons.Length; i++)
        {
            bool isCorrect = false;

            if (i == correctAnswerChoice) // ensure only one button set as correct
            {
                isCorrect = true;
            }

            answerButtons[i].SetIsCorrect(isCorrect);
            answerButtons[i].SetAnswerButton(answers[i]);
        }
    }

    /// <summary>
    /// Randomizes the order of answer choices while ensuring one is correctly assigned.
    /// </summary>
    /// <param name="originalList">The original list of answers.</param>
    /// <returns>A new list of randomized answers.</returns>
    private List<string> RandomizeAnswers(List<string> originalList)
    {
        bool correctAnswerChosen = false;

        List<string> newList = new List<string>();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            int random = Random.Range(0, originalList.Count);

            if (random == 0 && !correctAnswerChosen) // ensure correct answer assigned only once
            {
                correctAnswerChoice = i;
                correctAnswerChosen = true;
            }

            newList.Add(originalList[random]);
            originalList.RemoveAt(random); // remove used answer
        }


        return newList;
    }
}
