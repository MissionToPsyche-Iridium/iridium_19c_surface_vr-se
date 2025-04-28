using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HapticFeedback : MonoBehaviour
{
    private const float HapticDuration = 0.5f; // Default duration in seconds
    public GameObject left; // The Left Controller GameObject
    public GameObject right; // The Right Controller GameObject

    private XRBaseController m_ControllerLeft;
    private XRBaseController m_ControllerRight;
    private float m_HapticIntensity = 0.5f; // Default intensity (0 to 1)
    private XRRayInteractor m_RayInteractorLeft;
    private XRRayInteractor m_RayInteractorRight;

    private void Start()
    {
        // Load Haptic Feedback Settings
        CustomSettings settings = LoadCustomSettings();
        if (settings != null)
            m_HapticIntensity = settings.InteractionFeedback;
        else
            Debug.LogWarning("HapticFeedback: CustomSettings not found, using default intensity.");

        // Gets the controller components on the left.
        if (left != null)
        {
            m_ControllerLeft = left.GetComponent<XRBaseController>();
            m_RayInteractorLeft = left.GetComponent<XRRayInteractor>();

            if (m_RayInteractorLeft != null)
                m_RayInteractorLeft.hoverEntered.AddListener(OnHoverEnterLeft);
            else
                Debug.LogWarning("HapticFeedback: No XRRayInteractor found on Left Controller.");
        }
        else
        {
            Debug.LogError("HapticFeedback: Left GameObject is not assigned!");
        }

        // Gets the controller components on the right.
        if (right != null)
        {
            m_ControllerRight = right.GetComponent<XRBaseController>();
            m_RayInteractorRight = right.GetComponent<XRRayInteractor>();

            if (m_RayInteractorRight != null)
                m_RayInteractorRight.hoverEntered.AddListener(OnHoverEnterRight);
            else
                Debug.LogWarning("HapticFeedback: No XRRayInteractor found on Right Controller.");
        }
        else
        {
            Debug.LogError("HapticFeedback: Right GameObject is not assigned!");
        }
    }

    /// <summary>
    ///     Haptic Feedback event for the controller on the left.
    /// </summary>
    private void OnHoverEnterLeft(HoverEnterEventArgs args)
    {
        Debug.Log("Haptic triggered on Left Controller: " + args.interactableObject.transform.name);
        if (m_ControllerLeft != null) m_ControllerLeft.SendHapticImpulse(m_HapticIntensity, HapticDuration);
    }

    /// <summary>
    ///     Haptic Feedback event for the controller on the right.
    /// </summary>
    private void OnHoverEnterRight(HoverEnterEventArgs args)
    {
        Debug.Log("Haptic triggered on Right Controller: " + args.interactableObject.transform.name);
        if (m_ControllerRight != null) m_ControllerRight.SendHapticImpulse(m_HapticIntensity, HapticDuration);
    }

    /// <summary>
    ///     This methods retrieves config project settings
    /// </summary>
    /// <returns>CustomSettings</returns>
    private CustomSettings LoadCustomSettings()
    {
        CustomSettings settings = Resources.Load<CustomSettings>("CustomSettings");
        return settings;
    }
}