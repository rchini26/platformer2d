using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;
    void Start()
    {
        if (gameOverUI != null)
            gameOverUI.SetActive(false);
    }
    public void GameOver()
    {
        if (gameOverUI != null) 
        { 
            gameOverUI.SetActive(true);
        }
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
       SceneManager.LoadScene("SCN_Menu");
    }
}
