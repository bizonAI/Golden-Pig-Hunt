using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject pausePanel;


    public void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void HomeScene()
    {
        SceneManager.LoadScene("Home");
    }
}
