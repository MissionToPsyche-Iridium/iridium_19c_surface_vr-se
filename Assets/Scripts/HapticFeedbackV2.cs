using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HapticFeedbackV2 : MonoBehaviour
{
    private float _hapticIntensity = 0.5f; // Default intensity (0 to 1)
    private float _hapticDuration = 0.5f; // Default duration in seconds

    private XRRayInteractor[] _rayInteractors;

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

        //Find CameraOffSet in player
        GameObject CameraOffSet = GameObject.FindGameObjectWithTag("CameraOffSet");
        if (CameraOffSet != null)
        {
            _rayInteractors = CameraOffSet.GetComponentsInChildren<XRRayInteractor>();
            if (_rayInteractors != null && _rayInteractors.Length > 0)
            {
                foreach (var interactor in _rayInteractors)
                {
                    interactor.hoverEntered.AddListener(OnHoverEnter);
                }
            }
            else
            {
                Debug.LogWarning("HapticFeedback: No XRRayInteractors found on Player.");
            }
        }
        else
        {
            Debug.LogWarning("HapticFeedback: Error no gameObject with Player tag found.");
        }
    }

    /// <summary>
    /// Haptic Feedback event for a controller.
    /// </summary>
    private void OnHoverEnter(HoverEnterEventArgs args)
    {
        Debug.Log("Haptic triggered on a Controller: " + args.interactableObject.transform.name);
        
        // Get the interactor that triggered the event
        XRBaseInteractor interactor = args.interactorObject as XRBaseInteractor;
        if (interactor is XRRayInteractor rayInteractor)
        {
            rayInteractor.SendHapticImpulse(_hapticIntensity, _hapticDuration);
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
