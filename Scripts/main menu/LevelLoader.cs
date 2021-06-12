using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelLoader : MonoBehaviour {

    public GameObject levelLoader;
    public GameObject MainMenu;
    public Slider slider;
    public RectTransform panel;
    
    public void Loadlvl (string lvlname) {

        StartCoroutine(LoadAsynchronously(lvlname));
    }

    IEnumerator LoadAsynchronously (string lvlname) {

        AsyncOperation operation = SceneManager.LoadSceneAsync (lvlname);
        Destroy(MainMenu);
        levelLoader.SetActive(true);

        while (!operation.isDone) {

            float progress = Mathf.Clamp01 (operation.progress /0.9f);
            slider.value = progress;
            //Debug.Log (progress);

            yield return null;
        }
    }
}
