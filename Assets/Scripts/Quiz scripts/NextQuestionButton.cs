using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Manages next question button and try again button setup.
/// Scows the score canvas and resets the game. 
/// </summary>
public class NextQuestionButton : MonoBehaviour
{
    [SerializeField] private QuestionSetup questionSetup;
    [SerializeField] private GameObject gameCanvas; 
    [SerializeField] private GameObject scoreCanvas;

    public TextMeshProUGUI scoreText;

    private int questionsAnswered = 0;
    private int maxQuestions = 5;

    /// <summary>
    /// Handles the next question button click event.
    /// Loads a new question.
    /// </summary>
    public void onClick()
    {
        questionsAnswered++;
        if (questionsAnswered >= maxQuestions)
        {
            ShowScore();
            return;
        }

        if (questionSetup.questions.Count > 0)
        {
            questionSetup.Start();

        }
    }

    /// <summary>
    /// Resets the game and restarts the quiz.
    /// </summary>
    public void TryAgain()
    {
        // Reload the question list
        questionSetup.GetQuestionAssets();

        // Reset counters
        AnswerButton.correctAnswerCount = 0;
        questionsAnswered = 0;
        Debug.Log("Try Again pressed! Resetting values.");

        if (questionSetup.questions.Count > maxQuestions)
        {
            questionSetup.Start();
            gameCanvas.SetActive(true);
            scoreCanvas.SetActive(false);

        }
        else
        {
            scoreText.text = "Sorry! Not enough questions.";
        }
    }

    /// <summary>
    /// Displays the final score and message when the game ends.
    /// </summary>
    private void ShowScore()
    {
        int score = AnswerButton.correctAnswerCount;
        string message = "The End";
        float percentage = (float)score / maxQuestions * 100;
        if (percentage == 100)
        {
            message = "Perfect score! Amazing job!";
        }
        else if (percentage > 50)
        {
            message = "Good job! You know a lot!";
        }
        else if (percentage <= 50)
        {
            message = "Keep practicing!";
        }

        gameCanvas.SetActive(false);
        scoreCanvas.SetActive(true);
        scoreText.text = $"{message} \n Your Score: {score}/{maxQuestions}";
        Debug.Log("Game Over! Show Score Screen.");

        questionsAnswered = 0;
    }


}
