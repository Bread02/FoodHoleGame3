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

    public GameDataManager gameDataManager;
    //   [SerializeField] private TextMeshProUGUI loadingPercentage;

    // loading bar
    //Note: The progress may look like it goes straight to 100% if your Scene doesn’t have a lot to load.

    public virtual void Awake()
    {
        gameDataManager = GameObject.Find("GameDataManager").GetComponent<GameDataManager>();
        loadingCanvas = GameObject.Find("LoadingCanvas");
        loadingCanvas?.SetActive(false);
        Time.timeScale = 1;
    }

    public void ClickNextLevel()
    {



        Scene scene = SceneManager.GetActiveScene();
        switch (scene.name)
        {
            case "Level1":
                gameDataManager.UnlockLevel2();
                break;
            case "Level2":
                gameDataManager.UnlockLevel3();
                break;
            case "Level3":
                gameDataManager.UnlockLevel4();
                break;
            case "Level4":
                gameDataManager.UnlockLevel5();
                break;
            case "Level5":
                gameDataManager.UnlockLevel6();
                break;
            case "Level6":
                gameDataManager.UnlockLevel7();
                break;
            case "Level7":
                gameDataManager.UnlockLevel8();
                break;
            case "Level8":
                gameDataManager.UnlockLevel9();
                break;
            case "Level9":
                gameDataManager.UnlockLevel10();
                break;
            case "Level10":
                gameDataManager.UnlockLevel11();
                break;
            case "Level11":
                gameDataManager.UnlockLevel12();
                break;
            case "Level12":
                gameDataManager.UnlockLevel13();
                break;
            case "Level13":
                gameDataManager.UnlockLevel14();
                break;
            case "Level14":
                gameDataManager.UnlockLevel15();
                break;
            case "Level15":
                gameDataManager.UnlockLevel16();
                break;
            case "Level16":
                gameDataManager.UnlockLevel17();
                break;
            case "Level17":
                gameDataManager.UnlockLevel18();
                break;
            case "Level18":
                gameDataManager.UnlockLevel19();
                break;
            case "Level19":
                gameDataManager.UnlockLevel20();
                break;
            default: break;
        }

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
