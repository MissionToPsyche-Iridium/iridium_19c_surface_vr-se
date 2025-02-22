using System;
using UnityEngine;

/// <summary>
/// Moves the attached gameObject up and down to emulate hovering.
/// </summary>
public class BasicObjectHover : MonoBehaviour
{
    public float range = 0.2f;
    public float speed = 1f;
    private Vector3 origin;

    void Start()
    {
        origin = transform.position;
    }

    private void Update()
    {
        float objectHeight = origin.y + Mathf.Sin(Time.time * speed) * range;

        transform.position = new Vector3(origin.x, objectHeight, origin.z);
    }
}
