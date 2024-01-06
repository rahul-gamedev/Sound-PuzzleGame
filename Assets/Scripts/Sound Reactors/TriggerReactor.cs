using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerReactor : SoundReactor
{
    [SerializeField]
    private UnityEvent positiveEvent;

    [SerializeField]
    private UnityEvent negativeEvent;

    void Start() { }

    void Update() { }

    protected override void PositiveReact(SoundEmitter soundEmitter)
    {
        positiveEvent?.Invoke();
    }

    protected override void NegativeReact(SoundEmitter soundEmitter)
    {
        negativeEvent?.Invoke();
    }
}
