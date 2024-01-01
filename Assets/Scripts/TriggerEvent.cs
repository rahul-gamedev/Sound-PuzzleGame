using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    [SerializeField]
    private UnityEvent TriggerEnter;

    [SerializeField]
    private UnityEvent TriggerExit;

    private void OnTriggerEnter(Collider other)
    {
        TriggerEnter?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        TriggerExit?.Invoke();
    }
}
