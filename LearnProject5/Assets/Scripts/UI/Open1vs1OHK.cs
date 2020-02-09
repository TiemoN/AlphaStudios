﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Open1vs1OHK : MonoBehaviour
{
    public AudioSource ScrollingSound;

    public void PlayGame()
    {
        ScrollingSound.Play();

        SceneManager.LoadScene(7);
    }
}
