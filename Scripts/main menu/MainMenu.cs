using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MainMenu : MonoBehaviour {
    
    public GameObject _cross;
    public GameObject blackscreen;
    public GameObject controlsMenuImage;
    
    public void PlayGame () {
        SceneManager.LoadScene("Game-Play");
    }

    public void QuitGame () {
        Debug.Log("QUIT");
        Application.Quit();
    }
    
    public void _controls() {
        _cross.SetActive(true);
        controlsMenuImage.SetActive(true);
        blackscreen.SetActive(true);
    }
    
    public void cross() {
        _cross.SetActive(false);
        controlsMenuImage.SetActive(false);
        blackscreen.SetActive(false);
    }
}
