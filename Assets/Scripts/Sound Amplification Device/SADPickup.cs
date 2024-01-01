using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SADPickup : MonoBehaviour, IInteractable
{
    private Transform holder;
    private Transform[] transforms;

    private void Start()
    {
        holder = PlayerReferences.instance.SadHolder;
        transforms = GetComponentsInChildren<Transform>();
    }

    public void OnInteract(Transform player)
    {
        SoundAmplificationDevice SAD = GetComponent<SoundAmplificationDevice>();
        transform.SetParent(holder);

        foreach (Transform t in transforms)
        {
            t.gameObject.layer = LayerMask.NameToLayer("Overlay");
        }

        LeanTween.moveLocal(gameObject, Vector3.zero, 0.3f).setEaseOutCubic();
        LeanTween.rotateLocal(gameObject, Vector3.zero, 0.3f).setEaseOutCubic();
        SAD.enabled = true;
        Destroy(this);
    }
}
