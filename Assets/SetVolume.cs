using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{

    public AudioMixer Mixer;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider AmbSlider;

    const string MIXER_MUSIC = "MusicVol";
    const string MIXER_AMBIENCE = "AmbVol";

    private void Awake()
    {
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        AmbSlider.onValueChanged.AddListener(SetAmbVolume);
    }

    private void SetMusicVolume (float value)
    {
        Mixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value) * 20);
    }

    private void SetAmbVolume(float value)
    {
        Mixer.SetFloat(MIXER_AMBIENCE, Mathf.Log10(value) * 20);
    }




    /*public void SetLevel (float sliderValue)
    {
        Mixer.("MusicVol", Mathf.Log10(sliderValue) * 20);
    } */
}
