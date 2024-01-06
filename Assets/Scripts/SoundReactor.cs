using UnityEngine;

public abstract class SoundReactor : MonoBehaviour
{
    protected Vector2 VolumeLimit;

    [field: SerializeField]
    public Vector2 PitchLimit { get; private set; }

    public void React(SoundEmitter soundEmitter)
    {
        float dist = Vector3.Distance(transform.position, soundEmitter.transform.position);

        VolumeLimit.x = dist / soundEmitter.Range;
        VolumeLimit.y = 1f;

        if (
            (soundEmitter.Pitch >= PitchLimit.x && soundEmitter.Pitch <= PitchLimit.y)
            && (soundEmitter.Volume >= VolumeLimit.x && soundEmitter.Volume <= VolumeLimit.y)
        )
            PositiveReact(soundEmitter);
        else
            NegativeReact(soundEmitter);
    }

    protected abstract void PositiveReact(SoundEmitter soundEmitter);
    protected abstract void NegativeReact(SoundEmitter soundEmitter);
}
