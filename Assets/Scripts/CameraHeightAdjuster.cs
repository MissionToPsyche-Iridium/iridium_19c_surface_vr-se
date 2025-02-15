using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CameraHeightAdjuster : MonoBehaviour
{
    public Transform xrCamera;
    public LayerMask groundLayer;
    public float heightOffset = 1.6f;
    public float checkDistance = 5f;

    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        if (xrCamera == null) return;  // Prevent NullReferenceException

        RaycastHit hit;
        // Limit raycast distance and ensure correct LayerMask usage
        if (Physics.Raycast(xrCamera.position, Vector3.down, out hit, checkDistance, groundLayer))
        {
            Vector3 newPosition = transform.position;
            newPosition.y = hit.point.y + heightOffset;

            // Only update if position actually changes
            if (transform.position.y != newPosition.y)
            {
                transform.position = newPosition;
            }
        }
    }
}
