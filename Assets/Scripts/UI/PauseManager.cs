using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    [Header("Menu")] 
    public GameObject pauseMenuUI;
    public Slider volumeSlider;
    private float previousTimeScale;

    void Start()
    {
        pauseMenuUI.SetActive(false);
        volumeSlider.onValueChanged.AddListener(SetVolume);
        volumeSlider.value = AudioListener.volume;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenuUI.activeSelf)
                Resume();
            else
                Pause();
        }
    }

    public void Pause()
    {
        previousTimeScale = Time.timeScale;
        Time.timeScale = 0f; // Pausa o jogo
        pauseMenuUI.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = previousTimeScale;
        pauseMenuUI.SetActive(false);
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }
}
