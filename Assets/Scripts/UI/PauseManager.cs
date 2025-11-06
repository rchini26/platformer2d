using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    [Header("Menu")] 
    public GameObject pauseMenuUI;
    private float previousTimeScale;

    void Start()
    {
        pauseMenuUI.SetActive(false);
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
        Time.timeScale = 0f; 
        pauseMenuUI.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = previousTimeScale;
        pauseMenuUI.SetActive(false);
    }
}
