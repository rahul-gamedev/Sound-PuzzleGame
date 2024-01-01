using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundAmplificationDevice : MonoBehaviour
{
    InputManager inputManager;

    [SerializeField]
    private SoundEmitter SelectedEmitter;

    [SerializeField]
    private float Range = 15f;
    int SelectedField = 0;
    new Transform camera;

    public static event Action<float, float, int> OnModify;
    public static event Action<bool> OnSelectingEmiitter;

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
                if (hit.collider.TryGetComponent<SoundEmitter>(out var emitter))
                {
                    SelectedEmitter = emitter;
                    OnSelectingEmiitter?.Invoke(SelectedEmitter);
                }
                else
                {
                    SelectedEmitter = null;
                    OnSelectingEmiitter?.Invoke(SelectedEmitter);
                }
            }
        }

        if (
            SelectedEmitter
            && (
                Vector3.Dot(
                    (SelectedEmitter.transform.position - camera.position).normalized,
                    camera.forward
                ) <= 0.95f
                || Vector3.Distance(transform.position, SelectedEmitter.transform.position) > Range
            )
        )
        {
            SelectedEmitter = null;
            OnSelectingEmiitter?.Invoke(SelectedEmitter);
        }

        if (SelectedEmitter)
        {
            LeanTween.cancel(gameObject);
            LeanTween
                .moveLocal(transform.parent.gameObject, new Vector3(0.2f, -0.22f, 0.4f), 0.3f)
                .setEaseOutCubic();
            LeanTween
                .rotateLocal(transform.parent.gameObject, new Vector3(15f, 45f, 0f), 0.3f)
                .setEaseOutCubic();
        }
        else
        {
            LeanTween
                .moveLocal(transform.parent.gameObject, new Vector3(0.5f, -0.45f, 0.75f), 0.3f)
                .setEaseOutCubic();
            LeanTween
                .rotateLocal(transform.parent.gameObject, new Vector3(5f, 80f, 0f), 0.3f)
                .setEaseOutCubic();
        }

        Modify();
    }

    void Modify()
    {
        if (SelectedEmitter == null)
            return;

        if (inputManager.SwitchInput() && SelectedField == 0)
            SelectedField = 1;
        else if (inputManager.SwitchInput() && SelectedField == 1)
            SelectedField = 0;

        if (SelectedField == 0)
        {
            if (inputManager.ModifyInput() > 0)
                SelectedEmitter.Volume += 0.1f;
            else if (inputManager.ModifyInput() < 0)
                SelectedEmitter.Volume -= 0.1f;
        }
        else if (SelectedField == 1)
        {
            if (inputManager.ModifyInput() > 0)
                SelectedEmitter.Pitch += 0.3f;
            else if (inputManager.ModifyInput() < 0)
                SelectedEmitter.Pitch -= 0.3f;
        }

        OnModify?.Invoke(SelectedEmitter.Volume, SelectedEmitter.Pitch, SelectedField);
    }
}
