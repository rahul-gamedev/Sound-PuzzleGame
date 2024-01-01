using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SadUI : MonoBehaviour
{

    [SerializeField] private GameObject LogoScreen;
    [SerializeField] private Slider VolumeSlider;
    [SerializeField] private Slider PitchSlider;


    private void OnEnable()
    {
        SoundAmplificationDevice.OnModify += ModifyUI;
        SoundAmplificationDevice.OnSelectingEmiitter += SelectingEmitter;
    }
    private void OnDisable()
    {
        SoundAmplificationDevice.OnModify -= ModifyUI;
        SoundAmplificationDevice.OnSelectingEmiitter -= SelectingEmitter;
    }
    private void SelectingEmitter(bool emitter)
    {
        if (emitter)
            LogoScreen.SetActive(false);
        else
            LogoScreen.SetActive(true);
    }

    

    private void ModifyUI(float volume, float pitch, int selectedField)
    {
        VolumeSlider.value = volume;
        PitchSlider.value = pitch;
    }
}
