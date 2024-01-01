using UnityEngine;

public abstract class SoundReactor : MonoBehaviour
{
    [field: SerializeField]
    public Vector2 PitchLimit { get; private set; }

    public void React(SoundEmitter soundEmitter)
    {
        if (soundEmitter.Pitch >= PitchLimit.x && soundEmitter.Pitch <= PitchLimit.y)
            PositiveReact(soundEmitter);
        else
            NegativeReact(soundEmitter);
    }

    protected abstract void PositiveReact(SoundEmitter soundEmitter);
    protected abstract void NegativeReact(SoundEmitter soundEmitter);
}
