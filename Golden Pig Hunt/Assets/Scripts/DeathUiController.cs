using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathUiController : MonoBehaviour {

    public void RestartScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void HomeScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Home");
        
    }
}
