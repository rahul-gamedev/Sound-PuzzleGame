using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PickableObject : MonoBehaviour, IInteractable
{
    [SerializeField]
    private bool Picked;
    private Transform Holder;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Holder = PlayerReferences.instance.PickableHolder;
    }

    private void Update()
    {
        if (!Picked)
            return;

        if (Vector3.Distance(transform.position, Holder.position) > 0.1f)
        {
            Vector3 moveDirection = (transform.position - Holder.position).normalized;
            rb.AddForce(-moveDirection * 150f);
        }

        if (Vector3.Distance(transform.position, Holder.position) > 1f)
        {
            if (!Picked)
                return;

            OnInteract(null);
        }
    }

    public void OnInteract(Transform player)
    {
        if (Picked)
        {
            //Drop Object
            rb.useGravity = true;
            rb.drag = 1f;
            rb.constraints = RigidbodyConstraints.None;

            transform.parent = null;
        }
        else
        {
            //Pick Object
            rb.useGravity = false;
            rb.drag = 10f;
            rb.constraints = RigidbodyConstraints.FreezeRotation;

            transform.parent = Holder;
        }

        Picked = !Picked;
    }

    // private void OnCollisionEnter(Collision other)
    // {
    //     if (!Picked)
    //         return;

    //     OnInteract(null);
    // }
}
