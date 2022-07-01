using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LoadingMaster : MonoBehaviour
{
    [Header("Loading")]
    protected GameObject loadingCanvas;
    public Slider slider;
    //   [SerializeField] private TextMeshProUGUI loadingPercentage;

    // loading bar
    //Note: The progress may look like it goes straight to 100% if your Scene doesn’t have a lot to load.

    public virtual void Awake()
    {
        loadingCanvas = GameObject.Find("LoadingCanvas");
        loadingCanvas?.SetActive(false);
        Time.timeScale = 1;
    }

    public void ClickNextLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        int sceneIndex = scene.buildIndex;
        StartCoroutine(LoadAsynchronously(sceneIndex + 1));
    }

    public void ClickMenu()
    {
        StartCoroutine(LoadAsynchronously("MainMenu"));
    }

    public void RetryLevelClick()
    {
        Scene scene = SceneManager.GetActiveScene();
        StartCoroutine(LoadAsynchronously(scene.name));
    }

    protected IEnumerator LoadAsynchronously(string scene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene);
            loadingCanvas?.SetActive(true);

            while (!operation.isDone)
            {
                float progress = Mathf.Clamp01(operation.progress / 0.9f);
                slider.value = progress;
                yield return null;
            }
        }

    protected IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingCanvas?.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            //        loadingPercentage.text = (operation.progress * 100).ToString() + "%";
            slider.value = progress;
            yield return null;
        }
    }
}
