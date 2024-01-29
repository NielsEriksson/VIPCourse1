using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook: MonoBehaviour
{
    public int sensx, sensy;

    public Transform playerCamera;

    float xRotation, yRotation;
    private float mouseX;
    private float mouseY;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mouseX *= Time.deltaTime * sensx;
        mouseY *= Time.deltaTime * sensy;

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -85f, 85f); //limits rotation upwards and downwords

        playerCamera.rotation = Quaternion.Euler(xRotation, yRotation, 0); //rotates camera , used for up and downrotation
        transform.rotation = Quaternion.Euler(0, yRotation, 0); // rotates player, used for left and right rotation

    }

    private void OnLook(InputValue value) //gets mouse input 
    {
        mouseX = value.Get<Vector2>().x;
        mouseY = value.Get<Vector2>().y;
    }
}
