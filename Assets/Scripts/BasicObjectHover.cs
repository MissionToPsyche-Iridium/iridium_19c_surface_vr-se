using System;
using UnityEngine;

/// <summary>
/// Moves the attached gameObject up and down to emulate hovering.
/// </summary>
public class BasicObjectHover : MonoBehaviour
{
    public float range = 0.1f; // The range of going up and down
    public float speed = 0.5f; // The speed of the hovering
    private Vector3 _origin; // The original position of the gameObject

    void Start()
    {
        _origin = transform.position; // Gets the position of the object this script is attached too
    }

    private void Update()
    {
        float objectHeight = _origin.y + Mathf.Sin(Time.time * speed) * range;

        transform.position = new Vector3(_origin.x, objectHeight, _origin.z);
    }
}
