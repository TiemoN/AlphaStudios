using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDeathmatchOHK : MonoBehaviour
{
    public AudioSource ScrollingSound;

    public void PlayGame()
    {
        ScrollingSound.Play();

        SceneManager.LoadScene(5);
    }
}
