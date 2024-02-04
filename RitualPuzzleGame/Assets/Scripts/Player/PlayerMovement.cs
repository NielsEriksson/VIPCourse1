using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;

    private Vector3 movementInput;
    [SerializeField] private float moveSpeed;
    [SerializeField]private Vector3 movementVector;

    private float gravity = -9.81f;
    [SerializeField] private float gravityMultiplier = 3.0f;
    private float verticalVelocity;

    [SerializeField] private float jumpPower;
  
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        controller.detectCollisions = true;
    }

    void FixedUpdate()
    {

        ApplyMovement();
        ApplyGravity();

    }
    private void ApplyMovement ()
    {
        if (movementInput != Vector3.zero)
        {
            movementVector = transform.right * movementInput.x + transform.forward * movementInput.z;
        }
        movementVector = new Vector3(movementVector.x, verticalVelocity, movementVector.z);
        controller.Move(movementVector * Time.fixedDeltaTime * moveSpeed);
        movementVector = new Vector3(0, movementVector.y, 0);
    }
    private void ApplyGravity()
    {
        movementVector.y = verticalVelocity;
        if (IsGrounded() && verticalVelocity <0.0f)
        {
            verticalVelocity = -1f;
        }
        else
        {
          verticalVelocity += ( gravity * gravityMultiplier * Time.deltaTime);
        }
        
    }
    private void OnMove(InputValue value) //gets wasd input and transoforms it to a 3d vector
    {
        movementInput = new Vector3(value.Get<Vector2>().x, 0, value.Get<Vector2>().y);
        
    }
    private void OnJump(InputValue value)
    {
        if (!IsGrounded())
        {
            return;
        }
        Debug.Log("Jumping");
        verticalVelocity += jumpPower;
    }
    public bool IsGrounded()
    {
        return Physics.Raycast(controller.transform.position + Vector3.up * 0.1f, Vector3.down, 0.75f);
    }
}
