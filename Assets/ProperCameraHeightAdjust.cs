using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ProperCameraHeightAdjust : MonoBehaviour
{
    public CharacterController characterController;
    public Transform vrCam;

    void Update()
    {
        Vector3 center = vrCam.localPosition;
        characterController.height = center.y;
        characterController.center = new Vector3(center.x, characterController.height / 2, center.z);
    }
}
