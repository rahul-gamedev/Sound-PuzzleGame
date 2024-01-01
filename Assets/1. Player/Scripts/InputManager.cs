using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    private void Awake()
    {
        instance = this;
    }

    private PlayerInput playerInput;

    private InputAction moveAction;
    private InputAction sprintAction;
    private InputAction jumpAction;
    private InputAction crouchAction;
    private InputAction lookAction;
    private InputAction interactAction;
    private InputAction modifyAction;
    private InputAction switchAction;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();

        moveAction = playerInput.actions.FindAction("Move");
        sprintAction = playerInput.actions.FindAction("Sprint");
        jumpAction = playerInput.actions.FindAction("Jump");
        crouchAction = playerInput.actions.FindAction("Crouch");
        lookAction = playerInput.actions.FindAction("Look");
        interactAction = playerInput.actions.FindAction("Interact");
        modifyAction = playerInput.actions.FindAction("Modify");
        switchAction = playerInput.actions.FindAction("SwitchField");
    }

    public Vector2 MoveInput()
    {
        return moveAction.ReadValue<Vector2>();
    }

    public Vector2 LookInput()
    {
        return lookAction.ReadValue<Vector2>();
    }

    public bool SprintInput()
    {
        return sprintAction.IsPressed();
    }

    public bool JumpInput()
    {
        return jumpAction.triggered;
    }

    public bool CrouchInput()
    {
        return crouchAction.IsPressed();
    }

    public bool InteractInput()
    {
        return interactAction.triggered;
    }

    public bool SwitchInput()
    {
        return switchAction.triggered;
    }
    public float ModifyInput()
    {
        return modifyAction.ReadValue<Vector2>().y;
    }


}
