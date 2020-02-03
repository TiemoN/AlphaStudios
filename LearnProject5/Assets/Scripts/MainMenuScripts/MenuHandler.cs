using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    public GameObject Modus, HowToPlay, Options, Credits;
    private void Start()
    {
        Modus.SetActive(true);
    }
    
    public void ModusMenu()
    {
        //MainMenu.SetActive(true);
        Modus.SetActive(true); 
        HowToPlay.SetActive(false);
        Options.SetActive(false);
        Credits.SetActive(false);
    }
   
    public void HowToPlayMenu()
    {
        Modus.SetActive(false);
        HowToPlay.SetActive(true);
        Options.SetActive(false);
        Credits.SetActive(false);
    }
    public void OptionsMenu()
    {
        Modus.SetActive(false);
        HowToPlay.SetActive(false);
        Options.SetActive(true);
        Credits.SetActive(false);
    }
    public void CreditsMenu()
    {
        Modus.SetActive(false);
        HowToPlay.SetActive(false);
        Options.SetActive(false);
        Credits.SetActive(true);
    }
}
