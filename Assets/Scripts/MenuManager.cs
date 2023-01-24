using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject menu;
    public GameObject menuButton;
    public GameObject startButton;
    public GameObject quitButton;
    public GameObject restartButton;

    void Start()
    {
        menu.SetActive(true);
        Time.timeScale = 0;
        menuButton.SetActive(false);
    }   

    public void ClickStartButton()
    {   
        Time.timeScale = 1;
        menu.SetActive(false);
        menuButton.SetActive(true);
    }

    public void ClickMenuButton()
    {
        Time.timeScale = 0;
        menu.SetActive(true);
        menuButton.SetActive(false);
    }

    public void ClickRestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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