using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JumpFunctionForUser : MonoBehaviour
{

    [SerializeField] private InputActionProperty buttonForJumping;
    [SerializeField] private float heightOfJump = 4f;
    [SerializeField] private float controllerForCharacter;
    [SerializeField] private LayerMask layersForGround;

    private float gravityForMars = Physics.gravity.y; // To calculate how high we want to jump in Mars.

    /// <summary>
    /// This function is used to check with CheckSphere if the player is touching any of the ground layers or not, to ensure proper landing.
    /// </summary>
    private bool isLanded()
    {
        return Physics.CheckSphere(transform.position, 0.2f, layersForGround);
    } 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
