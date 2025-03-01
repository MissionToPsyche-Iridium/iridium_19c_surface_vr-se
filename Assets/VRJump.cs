using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VRJump : MonoBehaviour
{
    public InputActionProperty actionForJump;
    public CharacterController controllerForCharacter;

    public float jumpForce = 2f;
    private Vector3 velocityForJump;
    public float marsGravity = -1.5f;
    public float maximumSpeedForFalling = -7f;
    public float speedForMovement = 2f;
    private Vector3 directionForMovement;
    public InputActionProperty actionForLateralMovement; // Lateral movement for jumping.
    private bool isLanded;

    private void Update()
    {
        // Checking the ground with SphereCast based on the scale size of the terrain.
        isLanded = Physics.SphereCast(transform.position, 0.3f, Vector3.down, out RaycastHit hit, 1.5f);

        if (isLanded && velocityForJump.y < 0)
        {
            velocityForJump.y = -0.2f; // Resetting the velocity when the player is on the ground.
        }

        // Declaring the lateral movement for the player.
        Vector2 inputAction = actionForLateralMovement.action.ReadValue<Vector2>();
        directionForMovement = new Vector3(inputAction.x, 0, inputAction.y);
        directionForMovement = transform.TransformDirection(directionForMovement) * speedForMovement;

        // Condition for handling the jumping action.
        if (actionForJump.action.WasPressedThisFrame() && isLanded)
        {
            velocityForJump.y = Mathf.Sqrt(jumpForce * -2f * marsGravity);
        }

        // Applying the gravity when the player is not on the ground.
        if (!isLanded)
          {
            velocityForJump.y += marsGravity * Time.deltaTime;
            velocityForJump.y = Mathf.Max(velocityForJump.y, maximumSpeedForFalling);
        }   

        // Applying the final movement where the lateral and vertical movement is combined.
        Vector3 lastMove = (directionForMovement + velocityForJump) * Time.deltaTime;
        controllerForCharacter.Move(lastMove);
    }
}
