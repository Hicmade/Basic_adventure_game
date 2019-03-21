using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{
    public GameController gameController;
    public GameObject pausePanel;
    public GameObject loosePanel;
    public GameObject hud;
    public GameObject winPanel;

    public void GoToMain()
    {
        SceneManager.LoadScene("Menu");
    }

    public void OpenPause()
    {
        pausePanel.SetActive(true);
        gameController.isPaused = true;
        Time.timeScale = 0;
    }

    public void ClosePause()
    {
        pausePanel.SetActive(false);
        gameController.isPaused = false;
        Time.timeScale = 1;
    }

    public void UpdateLife()
    {
        hud.GetComponent<Image>().fillAmount = (float)gameController.GetCurrentLife() / 100.0f;
 
    }

    public void LoosePanel()
    {
        loosePanel.SetActive(true);
        gameController.isEnd = true;
        Time.timeScale = 0;
    }

    public void WinPanel()
    {
        winPanel.SetActive(true);
        gameController.isEnd = true;
        Time.timeScale = 0;
    }

    public void SaveGame() {
        gameController.SaveGame();
    }

    public void LoadGame() {
        gameController.LoadGame();
    }
}
