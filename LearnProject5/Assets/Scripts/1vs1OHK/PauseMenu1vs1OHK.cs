using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu1vs1OHK : MonoBehaviour
{
    public AudioSource ScrollingSound;

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI, settingsMenuUI;

    private void Start()
    {
        pauseMenuUI.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }


    public void Resume()
    {
        ScrollingSound.Play();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        ScrollingSound.Play();
        Debug.Log("Pause...");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

        settingsMenuUI.SetActive(false);
    }

    public void SettingsMenu()
    {
        ScrollingSound.Play();
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Restart()
    {
        ScrollingSound.Play();
        SceneManager.LoadScene(7);
        Time.timeScale = 1f;
    }

    public void LoadMenu()
    {
        ScrollingSound.Play();
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        ScrollingSound.Play();
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
