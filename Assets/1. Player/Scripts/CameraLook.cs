using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    InputManager inputManager;

    [SerializeField]
    private float MouseSensitivity = 25f;
    [SerializeField]
    private Transform body;

    private float xRotation;


    void Start()
    {
        inputManager = InputManager.instance;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = inputManager.LookInput().x * MouseSensitivity * Time.deltaTime;
        float mouseY = inputManager.LookInput().y * MouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        body.Rotate(Vector3.up * mouseX);

    }
}
