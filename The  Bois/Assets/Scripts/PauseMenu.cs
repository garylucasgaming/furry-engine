using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuDisplay;

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    if (!gameIsPaused)
        //    {
        //        PauseGame();
        //    }
        //    else
        //    {
        //        ResumeGame();
        //    }
        //}
    }

    public void ResumeGame()
    {
        pauseMenuDisplay.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void PauseGame()
    {
        pauseMenuDisplay.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
