using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FeedbackFromHands : MonoBehaviour
{
    [SerializeField] private Renderer handRenderer; // This is a reference to the renderer of the hand
    [SerializeField] private Color colorForGrabbing = Color.green; // Color to change when grabbing
    [SerializeField] private Color defaultColor = Color.white; // The default color of the hands
    [SerializeField] private Vector3 grabScale = new Vector3(1.2f, 1.2f, 1.2f); // Scale for grab
    private Vector3 originalScale; // Vector variable for storing the original scale

    private void Start()
    {
        // Adds the original scale
        originalScale = transform.localScale;

        // Sets the default color initially
        if (handRenderer != null)
        {
            handRenderer.material.color = defaultColor;
        }
    }

    // Called when grabbing starts
    public void OnGrabStart()
    {
        // Changes the color and scale when grabbing
        if (handRenderer != null)
        {
            handRenderer.material.color = colorForGrabbing;
        }
        transform.localScale = grabScale;
    }

    // This gets called when the grabbing ends or stops.
    public void OnGrabEnd()
    {
        // Changes the color and scale back to original
        if (handRenderer != null)
        {
            handRenderer.material.color = defaultColor;
        }
        transform.localScale = originalScale;
    }
}
