using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    public GameObject mainmenu;
    public GameObject options;
    public GameObject Controls;
    public GameObject Levels;

    public GameObject lvl1;
    public GameObject lvl2;

    private void Start()
    {
        options.SetActive(false);
        lvl1.SetActive(false);
        Levels.SetActive(false);
        Controls.SetActive(false);
        mainmenu.SetActive(true);
        lvl2.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void LevelsScreen()
    {
        Levels.SetActive(true);
        mainmenu.SetActive(false);
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
    public void BackToMain()
    {
        options.SetActive(false);
        Controls.SetActive(false);
        Levels.SetActive(false);
        mainmenu.SetActive(true);
    }
    public void LVL1()
    {
        lvl1.SetActive(true);
        Levels.SetActive(false);
        TypewriterUI.active = true;
    }
    public void LVL2()
    {
        lvl2.SetActive(true);
        Levels.SetActive(false);
        TypewriterUI.active = true;
    }
    public void BackToLevel()
    {
        lvl2.SetActive(false);
        lvl1.SetActive(false);
        Levels.SetActive(true);
    }
    public void Play1()
    {
        Debug.Log("Player lvl1");
        SceneManager.LoadScene(1);
    }
    public void Play2()
    {
        SceneManager.LoadScene(2);
    }
}