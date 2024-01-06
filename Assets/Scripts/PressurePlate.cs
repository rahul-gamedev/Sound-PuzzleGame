using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    private Vector3 notPressedPosition;

    private void Start()
    {
        notPressedPosition = transform.position;
    }

    public void Pressed()
    {
        LeanTween.moveY(this.gameObject, notPressedPosition.y - 0.2f, 0.3f);
    }

    public void NotPressed()
    {
        LeanTween.moveY(this.gameObject, notPressedPosition.y, 0.3f);
    }
}
