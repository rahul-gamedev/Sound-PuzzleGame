using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorReactor : SoundReactor, IInteractable
{
    [SerializeField]
    private bool Locked;
    bool opened;

    public void OnInteract(Transform player)
    {
        if (Locked)
        {
            Debug.Log("Door is Locked..");
        }
        else
        {
            LeanTween.cancel(gameObject);
            if (opened)
                LeanTween.rotateY(gameObject, 0f, 0.5f).setEaseOutCubic();
            else
                LeanTween.rotateY(gameObject, -105f, 0.5f).setEaseOutCubic();

            opened = !opened;
        }
    }

    protected override void NegativeReact(SoundEmitter soundEmitter)
    {
        Locked = true;
    }

    protected override void PositiveReact(SoundEmitter soundEmitter)
    {
        Locked = false;
    }
}
