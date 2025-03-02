using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VRJump : MonoBehaviour
{
    public InputActionProperty actionForJump;
    public CharacterController controllerForCharacter;

    public float jumpForce = 5f;
    private Vector3 velocityForJump;
    public float marsGravity = -1.5f;
    //public float maximumSpeedForFalling = -2.5f;
    // public float speedForMovement = 2f;
    // private Vector3 directionForMovement;
    // public InputActionProperty actionForLateralMovement; // Lateral movement for jumping.

    private bool isLanded;

    private void Update()
    {
        // Checking the ground with SphereCast based on the scale size of the terrain.
        isLanded = Physics.SphereCast(transform.position, 0.3f, Vector3.down, out RaycastHit hit, 1.2f);

        if (isLanded && velocityForJump.y < 0)
        {
            velocityForJump.y = -0.2f; // Resetting the velocity when the user is on the ground.
        }

        // Condition for handling the jumping action.
        if (actionForJump.action.WasPressedThisFrame() && isLanded)
        {
            velocityForJump.y = Mathf.Sqrt(jumpForce * -2f * marsGravity);
        }

        // Gravity for the user.
        velocityForJump.y += marsGravity * Time.deltaTime;

        // Moving the character up and down based on the velocity.
        Vector3 movementForJump = new Vector3(0, velocityForJump.y, 0) * Time.deltaTime;
        controllerForCharacter.Move(movementForJump);
    }
}
