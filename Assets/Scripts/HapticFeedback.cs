using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HapticFeedback : MonoBehaviour
{
    public GameObject left; // The Left Controller GameObject
    public GameObject right; // The Right Controller GameObject
    private float _hapticIntensity = 0.5f; // Default intensity (0 to 1)
    private float _hapticDuration = 0.5f; // Default duration in seconds

    private XRBaseController _controllerLeft;
    private XRBaseController _controllerRight;
    private XRRayInteractor _rayInteractorLeft;
    private XRRayInteractor _rayInteractorRight;

    void Start()
    {
        // Load Haptic Feedback Settings
        CustomSettings settings = LoadCustomSettings();
        if (settings != null)
        {
            _hapticIntensity = settings.InteractionFeedback;
        }
        else
        {
            Debug.LogWarning("HapticFeedback: CustomSettings not found, using default intensity.");
        }

        // Gets the controller components on the left.
        if (left != null)
        {
            _controllerLeft = left.GetComponent<XRBaseController>();
            _rayInteractorLeft = left.GetComponent<XRRayInteractor>();

            if (_rayInteractorLeft != null)
            {
                _rayInteractorLeft.hoverEntered.AddListener(OnHoverEnterLeft);
            }
            else
            {
                Debug.LogWarning("HapticFeedback: No XRRayInteractor found on Left Controller.");
            }
        }
        else
        {
            Debug.LogError("HapticFeedback: Left GameObject is not assigned!");
        }

        // Gets the controller components on the right.
        if (right != null)
        {
            _controllerRight = right.GetComponent<XRBaseController>();
            _rayInteractorRight = right.GetComponent<XRRayInteractor>();

            if (_rayInteractorRight != null)
            {
                _rayInteractorRight.hoverEntered.AddListener(OnHoverEnterRight);
            }
            else
            {
                Debug.LogWarning("HapticFeedback: No XRRayInteractor found on Right Controller.");
            }
        }
        else
        {
            Debug.LogError("HapticFeedback: Right GameObject is not assigned!");
        }
    }

    /// <summary>
    /// Haptic Feedback event for the controller on the left.
    /// </summary>
    private void OnHoverEnterLeft(HoverEnterEventArgs args)
    {
        Debug.Log("Haptic triggered on Left Controller: " + args.interactableObject.transform.name);
        if (_controllerLeft != null)
        {
            _controllerLeft.SendHapticImpulse(_hapticIntensity, _hapticDuration);
        }
    }

    /// <summary>
    /// Haptic Feedback event for the controller on the right.
    /// </summary>
    private void OnHoverEnterRight(HoverEnterEventArgs args)
    {
        Debug.Log("Haptic triggered on Right Controller: " + args.interactableObject.transform.name);
        if (_controllerRight != null)
        {
            _controllerRight.SendHapticImpulse(_hapticIntensity, _hapticDuration);
        }
    }

    /// <summary>
    /// This methods retrieves config project settings
    /// </summary>
    /// <returns>CustomSettings</returns>
    private CustomSettings LoadCustomSettings()
    {
        CustomSettings settings = Resources.Load<CustomSettings>("CustomSettings");
        return settings;
    }
}
