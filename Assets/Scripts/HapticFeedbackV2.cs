using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HapticFeedbackV2 : MonoBehaviour
{
    private float m_HapticIntensity = 0.5f; // Default intensity (0 to 1)
    private const float HapticDuration = 0.5f; // Default duration in seconds

    private XRRayInteractor[] m_RayInteractors;

    void Start()
    {
        // Load Haptic Feedback Settings
        CustomSettings settings = LoadCustomSettings();
        if (settings != null)
        {
            m_HapticIntensity = settings.InteractionFeedback;
        }
        else
        {
            Debug.LogWarning("HapticFeedback: CustomSettings not found, using default intensity.");
        }

        //Find CameraOffSet in player
        GameObject cameraOffSet = GameObject.FindGameObjectWithTag("CameraOffSet");
        if (cameraOffSet != null)
        {
            m_RayInteractors = cameraOffSet.GetComponentsInChildren<XRRayInteractor>();
            if (m_RayInteractors != null && m_RayInteractors.Length > 0)
            {
                foreach (var interactor in m_RayInteractors)
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
            Debug.LogWarning("HapticFeedback: Error no gameObject with CameraOffSet tag found.");
        }
    }

    /// <summary>
    /// Haptic Feedback event for a controller.
    /// </summary>
    private void OnHoverEnter(HoverEnterEventArgs args)
    {

        if (args.interactableObject.transform.gameObject.CompareTag("InfoPoint"))
        {
            Debug.Log("Haptic triggered on a Controller: " + args.interactableObject.transform.name + " with tag " + args.interactableObject.transform.tag);
            // Get the interactor that triggered the event
            XRBaseInteractor interactor = args.interactorObject as XRBaseInteractor;
            if (interactor is XRRayInteractor rayInteractor)
            {
                rayInteractor.SendHapticImpulse(m_HapticIntensity, HapticDuration);
            }
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
