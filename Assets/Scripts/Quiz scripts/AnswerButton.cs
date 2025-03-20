using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Handles the behavior of answer buttons in a quiz game.
/// Manages button text and determines if the selected answer is correct.
/// </summary>
public class AnswerButton : MonoBehaviour
{
    private bool isCorrect;
    private static bool hasBeenClicked; // Ensures answer is counted only once
    private static int correctAnswerCount = 0; // Static counter shared across all buttons

    [SerializeField]
    private TextMeshProUGUI answerText; // Text component displaying the answer

    [SerializeField]
    private UnityEngine.UI.Image buttonImage; // Button's image component

    /// <summary>
    /// Sets the answer text displayed on the button. And resets button color to gray.
    /// </summary>
    /// <param name="newText">The new text to display.</param>
    public void SetAnswerButton(string newText)
    {
        answerText.text = newText;
        buttonImage = GetComponent<UnityEngine.UI.Image>();
        buttonImage.color = new Color32(132, 126, 122, 106); // gray
        hasBeenClicked = false;

    }

    /// <summary>
    /// Sets whether this button is the correct answer.
    /// </summary>
    /// <param name="newBool">True if the answer is correct, false otherwise.</param>
    public void SetIsCorrect(bool newBool)
    {
        isCorrect = newBool;
    }

    /// <summary>
    /// Handles the button click event.
    /// Displays a debug message indicating whether the answer is correct.
    /// </summary>
    public void OnClick()
    {
        // Check if one of the answer buttons was clicked before
        if (hasBeenClicked)
        {
            return;
        }

            hasBeenClicked = true;

            if (isCorrect)
            {
                correctAnswerCount++;
                Debug.Log("Correct answer");
                Debug.Log($"Total correct answers: {correctAnswerCount}");
                buttonImage.color = new Color32(79, 185, 127, 255); // green 
            }
            else
            {
                Debug.Log("Wrong answer");
                Debug.Log($"Total correct answers: {correctAnswerCount}");
                buttonImage.color = new Color32(183, 33, 9, 255); // red

            }

        
    }

    /// <summary>
    /// Gets the total number of correct answers.
    /// </summary>
    /// <returns>The number of correct answers recorded.</returns>
    public static int GetCorrectAnswerCount()
    {
        return correctAnswerCount;
    }

    /// <summary>
    /// Resets the correct answer counter (useful for restarting the quiz).
    /// </summary>
    public static void ResetCorrectAnswerCount()
    {
        correctAnswerCount = 0;
    }

}
