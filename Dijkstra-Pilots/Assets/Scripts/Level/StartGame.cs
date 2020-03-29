using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public AudioSource buttonSound;

    public void gameBegin()
    {
        buttonSound.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void exitGame()
    {
        buttonSound.Play();
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
