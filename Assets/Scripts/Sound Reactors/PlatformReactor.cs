using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformReactor : SoundReactor
{
    bool canMove = false;

    [SerializeField]
    private float MoveSpeed;

    [SerializeField]
    private float WaitTime;

    [SerializeField]
    private Transform[] points;

    private int i = 0;
    private bool reverse;
    private int direction;

    private void OnValidate() { }

    void Start()
    {
        StartCoroutine(MovePlatform());
    }

    IEnumerator MovePlatform()
    {
        while (true)
        {
            if(canMove)
            {

                Vector3 target = points[i].position;
                while (transform.position != target)
                {
                    transform.position = Vector3.MoveTowards(
                        transform.position,
                        target,
                        MoveSpeed * Time.deltaTime
                    );

                    yield return null;
                }
            

            i += direction;

            if (i >= points.Length || i < 0)
            {
                if (reverse)
                {
                    direction *= -1;
                    i = Mathf.Clamp(i, 0, points.Length - 1);
                }
                else
                {
                    i = 0;
                }
            }
            yield return new WaitForSeconds(1f);
        }
        }
    }

    protected override void PositiveReact(SoundEmitter soundEmitter)
    {
        canMove = true;
    }

    protected override void NegativeReact(SoundEmitter soundEmitter)
    {
        canMove = false;
    }
}
