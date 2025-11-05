using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioPlayerHelper : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioMixer audioMixer;

    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFX", volume);
    }

    public void SetAmbienceVolume(float volume)
    {
        audioMixer.SetFloat("Ambience", volume);
    }
    public void Play()
    {
        audioSource.Play();
    }
}
