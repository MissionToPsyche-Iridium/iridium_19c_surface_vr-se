using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextQuestionButton : MonoBehaviour
{
    [SerializeField] private QuestionSetup questionSetup;

    /// <summary>
    /// Handles the next question button click event.
    /// Loads a new question.
    /// </summary>
    public void onClick()
    {
        if (questionSetup.questions.Count > 0)
        {
            questionSetup.Start();
        }
    }
}
