using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class environmentController : MonoBehaviour
{
    public bool cameraRotationOn = true;
    public bool skyBoxRotateOn = true;

    // Camera to rotate
    public Camera focusCamera;

    // Camera rotate speed
    public float cameraRotateSpeed = 1f;

    // Sun rotate speed
    public float sunRotateSpeed = 0f;

    // Light gameObject
    public Light sunLight;
  
    // Update is called once per frame
    void Update()
    {
        if(cameraRotationOn)
            focusCamera.transform.Rotate(new Vector3(0, -cameraRotateSpeed * Time.deltaTime, 0));
        if (skyBoxRotateOn)
        {
            sunLight.transform.Rotate(new Vector3(-sunRotateSpeed * Time.deltaTime, 0, 0));
        }
    }
}
