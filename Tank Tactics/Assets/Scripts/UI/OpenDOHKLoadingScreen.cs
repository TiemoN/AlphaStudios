using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDOHKLoadingScreen : MonoBehaviour
{
    public AudioSource ScrollingSound;

    public void LoadLS()
    {
        ScrollingSound.Play();

        SceneManager.LoadScene(1);
    }
}