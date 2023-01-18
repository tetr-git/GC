using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject menu;
    private bool _paused = true;

    void Start()
    {
        menu.SetActive(true);
        Time.timeScale = 0;
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
    
    public void OnWin(Boolean winner)
    {
        Debug.Log(winner);
    }
}