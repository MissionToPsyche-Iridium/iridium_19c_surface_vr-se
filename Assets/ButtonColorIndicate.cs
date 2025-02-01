using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


/// <summary>
/// This script is used to change the color of the button when the finger tip makes contact with the button,
/// which would make it easier to see if specific functionalities of certain buttons are being triggered and working as intended.
/// </summary>
public class ButtonColorIndicate : MonoBehaviour
{

    private Image imageOfButton;
    [Tooltip("The default button color")]
    public Color regularColor = Color.white;
    [Tooltip("Button color when the finger tip makes contact to button")]
    public Color colorHighlighting = Color.yellow;

    /// <summary>
    /// This awake function is used to get the image component of the button and set the color of the button to the regular color.
    /// </summary>
    void Awake()
    {
    imageOfButton = GetComponent<Image>();
        if (imageOfButton != null)
        imageOfButton.color = regularColor;
    }

    /// <summary>
    /// This function is used to change the color of the button when the finger tip makes contact with the button.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        // Checking that the collider is properly assigned to the "Finger" tag.
        if (other.CompareTag("Finger"))
        {
            if (imageOfButton != null)
            imageOfButton.color = colorHighlighting;
        }
    }

    /// <summary>
    /// This function for changing the color of the button back to the 
    /// original color when the finger tip is no longer in contact with the button.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Finger"))
        {
            if (imageOfButton != null)
            imageOfButton.color = regularColor;
        }
    }

    /// <summary>
    /// This function is used to simulate a click event when the finger tip is in contact with the button and the button is pressed.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Finger") && Input.GetButtonDown("Fire1"))
        {
            // This simulates a click event using Unity's Event System.
            ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
        }
    }
}
