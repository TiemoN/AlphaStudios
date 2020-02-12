using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDeathmatch : MonoBehaviour
{
    public AudioSource ScrollingSound;

    public void PlayGame()
    {
        ScrollingSound.Play();

        SceneManager.LoadScene(6);
    }
}
