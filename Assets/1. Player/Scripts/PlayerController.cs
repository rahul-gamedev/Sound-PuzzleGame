using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InputManager inputManager;
    private CharacterController controller;
    private Camera cam;

    bool Grounded;

    Vector3 MovementVector;
    Vector3 yVelocity;

    private float currentSpeed;
    [SerializeField]
    private float walkSpeed = 3f;
    [SerializeField]
    private float sprintSpeed = 6f;
    [SerializeField]
    private float crouchSpeed = 2f;

    [SerializeField]
    private float jumpHeight = 2f;
    [SerializeField]
    private float gravity = -9f;


    void Start()
    {
        cam = Camera.main;
        inputManager = InputManager.instance;

        controller = GetComponent<CharacterController>();
    }

    void Update() 
    {
        Grounded = controller.isGrounded;

        if (Grounded && yVelocity.y < 0f)
            yVelocity.y = 0f;
            

        if (inputManager.CrouchInput())
        {
            controller.height = 1;
            controller.center = new Vector3(0, 0.5f, 0);
            LeanTween.cancel(cam.transform.parent.gameObject);
            LeanTween.moveLocalY(cam.transform.parent.gameObject, 0.5f, 0.15f).setEaseOutCubic();
        }
        else
        {
            controller.height = 2;
            controller.center = new Vector3(0, 1f, 0);
            LeanTween.cancel(cam.transform.parent.gameObject);
            LeanTween.moveLocalY(cam.transform.parent.gameObject, 1.5f, 0.15f).setEaseOutCubic();
        }

        currentSpeed = inputManager.CrouchInput() ? crouchSpeed : (inputManager.SprintInput() ? sprintSpeed : walkSpeed);

        MovementVector = cam.transform.right * inputManager.MoveInput().x + cam.transform.parent.forward * inputManager.MoveInput().y;
        MovementVector *= currentSpeed;
        controller.Move(MovementVector * Time.deltaTime);

        if (Grounded && inputManager.JumpInput())
            yVelocity.y += Mathf.Sqrt(jumpHeight * -3f * gravity);
        
        yVelocity.y += gravity * Time.deltaTime;
        controller.Move(yVelocity * Time.deltaTime);
    }


}
