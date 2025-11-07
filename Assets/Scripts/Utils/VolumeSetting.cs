using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSetting : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumeSlider;
    void Start()
    {
        volumeSlider.onValueChanged.AddListener(SetVolume);
        volumeSlider.value = AudioListener.volume;
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("AmbienceVolume", Mathf.Log10(volume) * 20);
    }
}
