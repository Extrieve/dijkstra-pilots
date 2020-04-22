using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuInterface;
    [SerializeField] private bool isPaused;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        if (isPaused)
        {
            ActivatePause();
        }

        else
        {
            ResumeGame();
        }
    }

    private void ActivatePause()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        pauseMenuInterface.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        pauseMenuInterface.SetActive(false);
        isPaused = false;
    }

    public void QuitApplicaition()
    {
        Application.Quit();
        Debug.Log("QUIT");
    }
}
