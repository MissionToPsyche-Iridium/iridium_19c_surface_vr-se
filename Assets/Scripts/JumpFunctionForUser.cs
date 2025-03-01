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

    private float gravityForMars = Physics.gravity.y; // To calculate how high we want to jump in Mars.
    private Vector3 jumpMovement;

    /// <summary>
    /// This function is used to check with CheckSphere if the player is touching any of the ground layers or not, to ensure proper landing.
    /// </summary>
    private bool isLanded()
    {
        return Physics.CheckSphere(transform.position, 0.2f, layersForGround);
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
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonForJumping.action.WasPressedThisFrame() && isLanded())
        {
            JumpInVR();
        }

        jumpMovement.y += gravityForMars * Time.deltaTime; // Calculating the gravity for the jump.
        controllerForCharacter.Move(jumpMovement * Time.deltaTime); // Moving the player in the jumping motion.
    }
}