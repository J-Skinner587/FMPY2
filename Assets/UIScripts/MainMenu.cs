using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainmenu;
    public GameObject options;
    public GameObject Controls;

    private void Start()
    {
        options.SetActive(false);
        Controls.SetActive(false);
        mainmenu.SetActive(true);
    }
    public void Quit()
    {
        
    }

    public void Play()
    {
        
    }
    public void ControlsMenu()
    {
        mainmenu.SetActive(false);
        Controls.SetActive(true);
    }

    public void OptionsMenu()
    {
        mainmenu.SetActive(false);
        options.SetActive(true);
    }

    public void Back()
    {
        options.SetActive(false);
        Controls.SetActive(false);
        mainmenu.SetActive(true);
    }
}
