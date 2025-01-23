// This script adjusts the height of the GameObject based on the ground below it.
// It uses a raycast to detect the height of the terrain or ground
// under the XR Camera and adjusts the GameObject's Y position accordingly.

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CameraHeightAdjuster : MonoBehaviour
{
    // The XR Camera used as the reference point for height adjustment.
    public Transform xrCamera;
    // The layer(s) considered as the ground for the raycast detection.
    public LayerMask groundLayer;
    // The offset added to the detected ground height to position the GameObject (eye level).
    public float heightOffset = 1.6f;
    // The maximum distance for the raycast to check for the ground.
    public float checkDistance = 5f;

    // Start method is called before the first frame update.
    // It initializes the XR Camera if it has not been manually assigned.
    void Start()
    {
        if (xrCamera == null)
        {
            xrCamera = Camera.main.transform;  // Automatically assign the Main Camera
        }

        if (xrCamera == null)
        {
            UnityEngine.Debug.LogError("XR Camera not found. Please assign it manually.");
        }
    }

    // Update method, called once per frame.
    // Continuously checks the height of the ground below the XR Camera
    // and adjusts the GameObject's position accordingly.
    void Update()
    {
        if (xrCamera == null) return;  

        RaycastHit hit;
        // Limit raycast distance and ensure correct LayerMask usage
        if (Physics.Raycast(xrCamera.position, Vector3.down, out hit, checkDistance, groundLayer))
        {
            Vector3 newPosition = transform.position;
            newPosition.y = hit.point.y + heightOffset;

            // Update if position actually changes
            if (transform.position.y != newPosition.y)
            {
                transform.position = newPosition;
            }
        }
    }
}
