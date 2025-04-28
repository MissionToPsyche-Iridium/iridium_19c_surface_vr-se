using System;
using UnityEngine;

public class CameraHeightAdjuster : MonoBehaviour
{
    public Transform xrCamera;
    public LayerMask groundLayer;
    public float heightOffset = 1.6f;
    public float checkDistance = 5f;

    // Start is called before the first frame update
    private void Start()
    {
        if (xrCamera == null)
            if (Camera.main != null)
                xrCamera = Camera.main.transform; // Automatically assign the Main Camera

        if (xrCamera == null) Debug.LogError("XR Camera not found. Please assign it manually.");
    }

    // Update is called once per frame
    private void Update()
    {
        if (xrCamera == null) return; // Prevent NullReferenceException

        // Limit ray cast distance and ensure correct LayerMask usage
        if (Physics.Raycast(xrCamera.position, Vector3.down, out RaycastHit hit, checkDistance, groundLayer))
        {
            Vector3 newPosition = transform.position;
            newPosition.y = hit.point.y + heightOffset;

            // Only update if position actually changes
            if (Math.Abs(transform.position.y - newPosition.y) > 0.1f) transform.position = newPosition;
        }
    }
}