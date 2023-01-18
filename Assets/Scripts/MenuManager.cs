using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject menu;
    public GameObject menuButton;
    public GameObject startButton;
    public GameObject quitButton;
    public GameObject restartButton;
    private bool _paused = true;

    void Start()
    {
        menu.SetActive(true);
        Time.timeScale = 0;
        restartButton.SetActive(false);
    }   

    public void ClickStartButton()
    {   
        Time.timeScale = 1;
        menu.SetActive(false);
        _paused = false;
    }

    public void ClickMenuButton()
    {
        Time.timeScale = 0;
        menu.SetActive(true);
        _paused = true;
    }

    public void ClickRestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        menu.SetActive(false);
        _paused = false;
    }
    
    public void ClickQuitButton()
    {
        Application.Quit();
    }
    
    public void OnWin()
    {
        Time.timeScale = 0;
        menu.SetActive(true);
        restartButton.SetActive(true);
        //deactivate all buttons except restart
        startButton.SetActive(false);
        menuButton.SetActive(false);
    }
}