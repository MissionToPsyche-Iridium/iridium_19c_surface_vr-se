using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VRJump : MonoBehaviour
{
    public InputActionProperty actionForJump;
    public CharacterController controllerForCharacter;

    public float jumpForce = 5f;
    private Vector3 m_VelocityForJump;
    public float marsGravity = -1.5f;

    private bool m_IsLanded;

    private void Update()
    {
        // Checking the ground with SphereCast based on the scale size of the terrain.
        m_IsLanded = Physics.SphereCast(transform.position, 0.3f, Vector3.down, out RaycastHit hit, 1.2f);

        if (m_IsLanded && m_VelocityForJump.y < 0)
        {
            m_VelocityForJump.y = -0.2f; // Resetting the velocity when the user is on the ground.
        }

        // Condition for handling the jumping action.
        if (actionForJump.action.WasPressedThisFrame() && m_IsLanded)
        {
            m_VelocityForJump.y = Mathf.Sqrt(jumpForce * -2f * marsGravity);
        }

        // Gravity for the user.
        m_VelocityForJump.y += marsGravity * Time.deltaTime;

        // Moving the character up and down based on the velocity.
        Vector3 movementForJump = new Vector3(0, m_VelocityForJump.y, 0) * Time.deltaTime;
        controllerForCharacter.Move(movementForJump);
    }
}
