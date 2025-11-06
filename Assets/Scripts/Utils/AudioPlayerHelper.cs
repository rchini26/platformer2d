using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioPlayerHelper : MonoBehaviour
{
    public AudioSource audioSource;
    public KeyCode keyCode = KeyCode.P;

    void Update()
    {
        if (Input.GetKeyDown(keyCode))
        {
            Play();
        }
    }
    public void Play()
    {
        audioSource.Play();
    }
}
