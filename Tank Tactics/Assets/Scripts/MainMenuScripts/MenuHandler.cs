using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    public GameObject Modus, Map, Map2, Map3, HowToPlay, Options, Credits, StartButton, MainMenu;
    private void Start()
    {
        StartButton.SetActive(true);
    }
    public void mainMenu()
    {
        StartButton.SetActive(false);
        MainMenu.SetActive(true);
        Modus.SetActive(true);
        Map.SetActive(false);
        Map2.SetActive(false);
        Map3.SetActive(false);
        HowToPlay.SetActive(false);
        Options.SetActive(false);
        Credits.SetActive(false);
    }
    public void ModusMenu()
    {
        MainMenu.SetActive(true);
        Modus.SetActive(true);
        Map.SetActive(false);
        Map2.SetActive(false);
        Map3.SetActive(false);    
        HowToPlay.SetActive(false);
        Options.SetActive(false);
        Credits.SetActive(false);
    }
    public void MapMenu()
    {
        MainMenu.SetActive(false);
        Modus.SetActive(false);
        Map.SetActive(true);
        Map2.SetActive(false);
        Map3.SetActive(false);
        HowToPlay.SetActive(false);
        Options.SetActive(false);
        Credits.SetActive(false);
    }
    public void Map2Menu()
    {
        MainMenu.SetActive(false);
        Modus.SetActive(false);
        Map.SetActive(false);
        Map2.SetActive(true);
        Map3.SetActive(false);
        HowToPlay.SetActive(false);
        Options.SetActive(false);
        Credits.SetActive(false);
    }
    public void Map3Menu()
    {
        MainMenu.SetActive(false);
        Modus.SetActive(false);
        Map.SetActive(false);
        Map2.SetActive(false);
        Map3.SetActive(true);
        HowToPlay.SetActive(false);
        Options.SetActive(false);
        Credits.SetActive(false);
    }

    public void HowToPlayMenu()
    {
        Modus.SetActive(false);
        Map.SetActive(false);
        Map2.SetActive(false);
        Map3.SetActive(false);
        HowToPlay.SetActive(true);
        Options.SetActive(false);
        Credits.SetActive(false);
    }
    public void OptionsMenu()
    {
        Modus.SetActive(false);
        Map.SetActive(false);
        Map2.SetActive(false);
        Map3.SetActive(false);
        HowToPlay.SetActive(false);
        Options.SetActive(true);
        Credits.SetActive(false);
    }
    public void CreditsMenu()
    {
        Modus.SetActive(false);
        Map.SetActive(false);
        Map2.SetActive(false);
        Map3.SetActive(false);
        HowToPlay.SetActive(false);
        Options.SetActive(false);
        Credits.SetActive(true);
    }
}
