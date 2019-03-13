using UnityEngine;
using System.Collections;

// The GameObject is made to bounce using the space key.
// Also the GameOject can be moved forward/backward and left/right.
// Add a Quad to the scene so this GameObject can collider with a floor.

public class Movement : MonoBehaviour
{
    public float translateSpeed = 6.0f;
    public float rotateSpeed = 6.0f;
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