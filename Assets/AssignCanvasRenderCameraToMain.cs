using Unity.XR.CoreUtils;
using UnityEngine;
public class AssignCanvasRenderCameraToMain : MonoBehaviour
{
    [SerializeField]
    private Canvas m_Canvas;

    [SerializeField] private Camera m_Camera;
    
    private XROrigin m_XROrigin;
    void Update()
    {
        if (m_Canvas == null)
        {
            m_Canvas = GetComponent<Canvas>();
            if (m_Canvas == null)
            {
                Debug.LogError("AssignCanvasRenderCameraToMain on " + name + ": No Canvas component found.");
                return;
            }
        }

        // Is important for when changing scene so that the UI attaches to the new scene's main camera
        if (m_Canvas.worldCamera == null)
        {
            m_Canvas.worldCamera = Camera.main;
        }
    }

}
