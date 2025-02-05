using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Additional libraries for controller feedback.
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// This script is used to provide feedback to the user when they touch the Wrist UI Menu with the finger tips on the right VR hand.
/// </summary>

[SerializeField] 
public class FingerTipFeedback : MonoBehaviour
{

    [SerializeField, Range(0f, 1f)]
    private float m_VibrationIntensity = 0.5f;

    public float VibrationIntensity
    {
        get => m_VibrationIntensity;
        set => m_VibrationIntensity = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
