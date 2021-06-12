using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour {
    
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    void Update() {
        if (Input.GetKeyDown(KeyCode.P)) {
            if (GameIsPaused) {

                Resume();
            }
            else {
                Pause();
            }
        }
    }

    public void Resume () {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }

    public void Pause () {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void Quit () {
        Application.Quit();
    }
}
