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
    
    [SerializeField]
    private TextMeshProUGUI answerText; // Text component displaying the answer

    /// <summary>
    /// Sets the answer text displayed on the button.
    /// </summary>
    /// <param name="newText">The new text to display.</param>
    public void SetAnswerText(string newText)
    {
        answerText.text = newText;
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
        if (isCorrect)
        {
            Debug.Log("Correct answer");
        }
        else
        {
            Debug.Log("Wrong answer"); 
        }
    }

}
