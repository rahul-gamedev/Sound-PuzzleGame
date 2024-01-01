using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    InputManager inputManager;
    new Transform camera;

    [SerializeField] private float Range = 5f;

    void Start()
    {
        inputManager = InputManager.instance;
        camera = Camera.main.transform;
    }

    void Update()
    {
        if (inputManager.InteractInput())
        {
            if (Physics.Raycast(camera.position, camera.forward, out RaycastHit hit, Range))
            {
                if (hit.collider.TryGetComponent<IInteractable>(out var interactable))
                {
                    interactable.OnInteract(this.transform);
                }
            }
        }
    }
}
