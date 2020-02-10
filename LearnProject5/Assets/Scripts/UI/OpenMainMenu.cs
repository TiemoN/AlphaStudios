using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenMainMenu : MonoBehaviour
{
    public AudioSource ScrollingSound;

    public void MainMenu()
    {
        ScrollingSound.Play();

        SceneManager.LoadScene(0);
    }
}
