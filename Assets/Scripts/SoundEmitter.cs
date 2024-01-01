using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(AudioSource))]
public class SoundEmitter : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    [Range(0f, 1f)]
    [SerializeField]
    private float volumeControl;

    [Range(-3f, 3f)]
    [SerializeField]
    private float pitchControl;

    [SerializeField]
    private float Range;

    [SerializeField]
    private LayerMask NotReactors;

    public float audibleRange { get; private set; }

    Collider[] reactors;

    private float volume;
    private float pitch;

    public float Volume
    {
        get { return volume; }
        set
        {
            if (value < 0)
                volume = 0;
            else if (value > 1)
                volume = 1;
            else
                volume = value;

            OnAmplify();
        }
    }

    public float Pitch
    {
        get { return pitch; }
        set
        {
            if (value < -3f)
                pitch = -3f;
            else if (value > 3f)
                pitch = 3f;
            else
                pitch = value;

            OnAmplify();
        }
    }

    public event Action<float, float> OnConfigChange;

    void OnValidate()
    {
        audioSource.volume = volumeControl;
        audioSource.pitch = pitchControl;
        audioSource.minDistance = Range;
        audibleRange = Range * Volume;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Volume = volumeControl;
        Pitch = pitchControl;   
    }

    public void OnAmplify()
    {
        audioSource.volume = Volume;
        audioSource.pitch = Pitch;

        audibleRange = Range * Volume;
        UpdateReactors();
        OnConfigChange?.Invoke(Volume, Pitch);
    }

    private void UpdateReactors()
    {
        reactors = Physics.OverlapSphere(transform.position, audibleRange, NotReactors);

        foreach (Collider reactor in reactors)
        {
            if (reactor.TryGetComponent<SoundReactor>(out var soundReactor))
                soundReactor.React(this);
        }
    }
}
