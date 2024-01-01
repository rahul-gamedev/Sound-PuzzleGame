using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformReactor : SoundReactor
{
    bool canMove = false;

    [SerializeField]
    private float MoveTime;

    [SerializeField]
    private Transform pointA;

    [SerializeField]
    private Transform pointB;

    [SerializeField]
    private Transform Platform;
    float value;

    private void OnValidate()
    {
        pointA = transform.Find("pointA");
        pointB = transform.Find("pointB");
        Platform = transform.Find("Platform");

        if (!pointA)
            pointA = new GameObject("pointA").transform;
        if (!pointB)
            pointB = new GameObject("pointB").transform;
    }

    void Start()
    {
        Platform.position = pointA.position;
    }

    void Update()
    {
        // if (!canMove)
        // {
        //     LeanTween.pause(Platform.gameObject);
        //     return;
        // }

        // LeanTween.resume(Platform.gameObject);

        Platform.position = Vector3.Lerp(pointA.position, pointB.position, value);

        // LeanTween.init(800);
        LeanTween
            .value(Platform.gameObject, 0, 1, MoveTime)
            .setLoopPingPong()
            .setOnUpdate(
                (float result) =>
                {
                    value = result;
                }
            );

        // LTSeq seq = LeanTween.sequence(true);

        // seq.append(LeanTween.move(Platform.gameObject, pointB, MoveTime));
        // seq.append(0.5f);
        // seq.append(LeanTween.move(Platform.gameObject, pointA, MoveTime));
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
