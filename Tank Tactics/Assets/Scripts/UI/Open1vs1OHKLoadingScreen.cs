using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Open1vs1OHKLoadingScreen : MonoBehaviour
{
    public AudioSource ScrollingSound;

    public void LoadLS()
    {
        ScrollingSound.Play();

        SceneManager.LoadScene(3);
    }
}
