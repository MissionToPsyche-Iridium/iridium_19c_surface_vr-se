using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defines a question structure using ScriptableObjects.
/// Holds a question string and a list of possible answers.
/// </summary>
[CreateAssetMenu(fileName = "Question", menuName = "ScriptableObjects/Question", order = 1)]
public class QuestionData : ScriptableObject
{
    public string question; // question text
    [Tooltip("Always place the correct answer first, they are mixed later")]
    public string[] answers; // list of answers

}
