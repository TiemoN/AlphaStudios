using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    public AudioSource ScrollingSound;

    public GameObject Modus, HowToPlay, Options, Credits, Menu, Background;

    private void Start()
    {
        Modus.SetActive(true);
    }
    
    public void ModusMenu()
    {
        ScrollingSound.Play();
        Menu.SetActive(true);
        Modus.SetActive(true); 
        HowToPlay.SetActive(false);
        Options.SetActive(false);
        Credits.SetActive(false);
        Background.SetActive(true);
    }
   
    public void HowToPlayMenu()
    {
        ScrollingSound.Play();
        Menu.SetActive(false);
        Modus.SetActive(false);
        HowToPlay.SetActive(true);
        Options.SetActive(false);
        Credits.SetActive(false);
        Background.SetActive(false);
    }
    public void OptionsMenu()
    {
        ScrollingSound.Play();
        Menu.SetActive(true);
        Modus.SetActive(false);
        HowToPlay.SetActive(false);
        Options.SetActive(true);
        Credits.SetActive(false);
        Background.SetActive(true);
    }
    public void CreditsMenu()
    {
        ScrollingSound.Play();
        Menu.SetActive(true);
        Modus.SetActive(false);
        HowToPlay.SetActive(false);
        Options.SetActive(false);
        Credits.SetActive(true);
        Background.SetActive(true);
    }
}
