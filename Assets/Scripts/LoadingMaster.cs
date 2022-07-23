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


    [Header("Mobile Ads")]
    public AdMaster adMaster;

    public virtual void Awake()
    {
        gameDataManager = GameObject.Find("GameDataManager").GetComponent<GameDataManager>();
        loadingCanvas = GameObject.Find("LoadingCanvas");
        loadingCanvas?.SetActive(false);
        Time.timeScale = 1;
        adMaster = GameObject.Find("InterstitalAd").GetComponent<AdMaster>();
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
            case "Level20":
                gameDataManager.UnlockLevel21();
                break;
            case "Level21":
                gameDataManager.UnlockLevel22();
                break;

            case "Level22":
                gameDataManager.UnlockLevel23();
                break;

            case "Level23":
                gameDataManager.UnlockLevel24();
                break;

            case "Level24":
                gameDataManager.UnlockLevel25();
                break;
            case "Level25":
                gameDataManager.UnlockLevel26();
                break;
            case "Level26":
                gameDataManager.UnlockLevel27();
                break;
            case "Level27":
                gameDataManager.UnlockLevel28();
                break;
            case "Level28":
                gameDataManager.UnlockLevel29();
                break;
            case "Level29":
                gameDataManager.UnlockLevel30();
                break;
            case "Level30":
                gameDataManager.UnlockLevel31();
                break;
            case "Level31":
                gameDataManager.UnlockLevel32();
                break;
            case "Level32":
                gameDataManager.UnlockLevel33();
                break;
            case "Level33":
                gameDataManager.UnlockLevel34();
                break;
            case "Level34":
                gameDataManager.UnlockLevel35();
                break;
            case "Level35":
                gameDataManager.UnlockLevel36();
                break;
            case "Level36":
                gameDataManager.UnlockLevel37();
                break;
            case "Level37":
                gameDataManager.UnlockLevel38();
                break;
            case "Level38":
                gameDataManager.UnlockLevel39();
                break;
            case "Level39":
                gameDataManager.UnlockLevel40();
                break;
            case "Level40":
                gameDataManager.UnlockLevel41();
                break;
            case "Level41":
                gameDataManager.UnlockLevel42();
                break;
            case "Level42":
                gameDataManager.UnlockLevel43();
                break;

            case "Level43":
                gameDataManager.UnlockLevel44();
                break;

            case "Level44":
                gameDataManager.UnlockLevel45();
                break;

            case "Level45":
                gameDataManager.UnlockLevel46();
                break;

            case "Level46":
                gameDataManager.UnlockLevel47();
                break;

            case "Level47":
                gameDataManager.UnlockLevel48();
                break;

            case "Level48":
                gameDataManager.UnlockLevel49();
                break;

            case "Level49":
                gameDataManager.UnlockLevel50();
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
