/*  ╔═════════════════════════════╡  Mech Defense Force 2019 ╞══════════════════╗            
    ║ Authors:  Donald Thatcher          Email: donald.thatcher@outlook.com     ║
    ╟───────────────────────────────────────────────────────────────────────────╢░ 
    ║ Purpose:  Relay control inputs to player characater                       ║░
    ║ Usage:    Player Characater                                               ║░
    ╚═══════════════════════════════════════════════════════════════════════════╝░
       ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
*/
using UnityEngine;
using System.Collections;


public class PlayerMovement : MonoBehaviour
{
    public float translateSpeed = 40.0f;
    public float rotateSpeed = 20.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    void Start()
    {

        controller = GetComponent<CharacterController>();
        
    }

    void Update() {
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(-Vector3.up * rotateSpeed * Time.deltaTime * 10);

        if (Input.GetKey(KeyCode.D))
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime * 10);


        if (controller.isGrounded)
        {

            moveDirection = new Vector3(0.0f, 0.0f, Input.GetAxis("Vertical"));  
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection = moveDirection * translateSpeed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        // Apply gravity
        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

        // Move the controller
        controller.Move(moveDirection * Time.deltaTime);
    }
}