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
    void Update()
    {
        mouseX *= Time.deltaTime * sensx;
        mouseY *= Time.deltaTime * sensy;

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -85f, 85f);

        playerCamera.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        transform.rotation = Quaternion.Euler(0, yRotation, 0);

    }

    private void OnLook(InputValue value)
    {
        mouseX = value.Get<Vector2>().x;
        mouseY = value.Get<Vector2>().y;
    }
}
