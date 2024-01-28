using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 movement;
    [SerializeField] private float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        if (controller.isGrounded == false)
        {
            controller.Move(new Vector3(0, -1, 0)); //used to add gravity when the player is not grounded 
        }
        Vector3 horizontalVelocity = transform.right * movement.x + transform.forward * movement.z;
        if (movement != Vector3.zero)
        {
            controller.Move(horizontalVelocity * Time.fixedDeltaTime * moveSpeed);
        }

    }
    private void OnMove(InputValue value) //gets wasd input and transoforms it to a 3d vector
    {
        movement = new Vector3(value.Get<Vector2>().x, 0, value.Get<Vector2>().y);
    }
}
