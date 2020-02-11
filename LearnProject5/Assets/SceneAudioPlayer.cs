using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneAudioPlayer : MonoBehaviour
{
    public static SceneAudioPlayer instance;

    public AudioSource mySource;

    private void Awake()
    {
        instance = this;
    }

    public static void Play(AudioClip clip)
    {
        instance.mySource.PlayOneShot(clip);
    }
}
