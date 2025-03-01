using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JumpFunctionForUser : MonoBehaviour
{
    [SerializeField] private InputActionProperty buttonForJumping;
    [SerializeField] private float heightOfJump = 3f;
    [SerializeField] private CharacterController controllerForCharacter;
    [SerializeField] private LayerMask layersForGround;

    private float gravityForMars = -3.711f; // Mars gravity in m/s^2
    private Vector3 jumpMovement;
    private bool wasLanded;

    /// <summary>
    /// This function is used to check with CheckSphere if the player is touching any of the ground layers or not, to ensure proper landing.
    /// </summary>
    private bool isLanded()
    {
        Vector3 spherePosition = controllerForCharacter.bounds.center + Vector3.down * (controllerForCharacter.bounds.extents.y + 0.1f); // Adjust the position to the bottom of the CharacterController
        return Physics.CheckSphere(spherePosition, 0.3f, layersForGround); // Increase the radius to 0.3f
    }

    /// <summary>
    /// This function is used to calculate the jump movement for the player in VR. The default Jump height is at 3.
    /// </summary>
    private void JumpInVR()
    {
        jumpMovement.y = Mathf.Sqrt(heightOfJump * -3f * gravityForMars); // Calculating the jump movement.
    }

    // Start is called before the first frame update
    void Start()
    {
        // Ensure the jumpMovement is initialized
        jumpMovement = Vector3.zero;
        wasLanded = true;
    }

    // Update is called once per frame
    // My updated version of this Update() function is used to check if the player is landed or not,
    // and if the player is landed, then the player can jump.
    void Update()
    {
        bool Landed = isLanded();
        if (buttonForJumping.action.WasPressedThisFrame() && Landed)
        {
            JumpInVR();
        }

        if (Landed && !wasLanded)
        {
            // Reset the entire jumpMovement vector when the player is landed to avoid residual forces
            jumpMovement = Vector3.zero;
        }

        if (!Landed)
        {
            jumpMovement.y += gravityForMars * Time.deltaTime; // Calculating the gravity for the jump.
        }

        wasLanded = Landed;

        controllerForCharacter.Move(jumpMovement * Time.deltaTime); // Moving the player in the jumping motion.
    }
}