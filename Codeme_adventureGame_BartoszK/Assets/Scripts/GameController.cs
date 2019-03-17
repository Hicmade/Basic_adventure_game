using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameData gameData;
    public GameObject pausePanel;
    public GameObject loosePanel;
    public bool isPaused = false;
    public bool isEnd = false;
    public bool freezeControls = false;

    public UImanager uimanager;
    public GameObject boom;
    public GameObject player;

    public void Awake()
    {
        Time.timeScale = 1;
    }

    public void GetDamage(int dam) {
        gameData.playerLife -= dam;
        uimanager.UpdateLife();
        if (gameData.playerLife <= 0) {

        }
        Debug.Log("life: " + gameData.playerLife);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isPaused == false)
            {
                uimanager.OpenPause();
            }
            else if (isPaused == true) {
                uimanager.ClosePause();
            }

        }

        if (isEnd) {
            if (Input.anyKeyDown) {
                uimanager.GoToMain();
            }
        }
    }

    public int GetCurrentLife() {
        return gameData.playerLife;
    }

    IEnumerator WaitForPanel() {
        yield return new WaitForSeconds(3.0f);
        uimanager.LoosePanel();
    }

    IEnumerator WaitForPanelWin()
    {
        yield return new WaitForSeconds(3.0f);
        uimanager.WinPanel();
    }

    public void SetKeySlot(int slot) {
        gameData.keyNumber[slot] = true;
    }

    public bool GetKeySlot(int slot) {
        return gameData.keyNumber[slot];
    }

    public void LooseGame() {
        freezeControls = true;
        Vector3 vec = player.transform.position;
        Instantiate(boom, vec, Quaternion.identity);
        StartCoroutine(WaitForPanel());
    }

    public void WinGame() {
        freezeControls = true;
        Vector3 vec = player.transform.position;
        Instantiate(boom, vec, Quaternion.identity);
        StartCoroutine(WaitForPanelWin());
    }
}
