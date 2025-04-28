using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.Serialization;

public class AssignCanvasRenderCameraToMain : MonoBehaviour
{
    [FormerlySerializedAs("m_Canvas")] [SerializeField]
    private Canvas canvas;

    [FormerlySerializedAs("m_Camera")] [SerializeField]
    private Camera camera;

    private XROrigin m_XROrigin;

    private void Update()
    {
        if (canvas == null)
        {
            canvas = GetComponent<Canvas>();
            if (canvas == null)
            {
                Debug.LogError("AssignCanvasRenderCameraToMain on " + name + ": No Canvas component found.");
                return;
            }
        }

        // Is important for when changing scene so that the UI attaches to the new scene's main camera
        if (canvas.worldCamera == null) canvas.worldCamera = Camera.main;
    }
}