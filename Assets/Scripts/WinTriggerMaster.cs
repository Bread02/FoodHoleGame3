using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using GoogleMobileAds.Api;
using UnityEngine.Audio;

public class WinTriggerMaster : MonoBehaviour
{
    [Header("Game Data Manager")]
    private GameDataManager gameDataManager;

    [Header("Lists")]
    public List<GameObject> playerObjects = new List<GameObject>();

    [Header("Canvas")]
    private GameObject winCanvas;
    private TextMeshProUGUI itemsRemaining;

    [Header("Ints")]
    private int itemsRemainingInt;
    private int totalItemsInt;
    private int objectsTriggered;
    private int starsRewarded;

    [Header("Ending Screen Stars")]
    private GameObject starOne;
    private GameObject starTwo;
    private GameObject starThree;

    [Header("LevelUITop Stars")]
    private GameObject UIStarOne;
    private GameObject UIStarTwo;
    private GameObject UIStarThree;

    public bool levelComplete;
    public bool levelCompleteSaveProgress;

    public TimerMaster timerMaster;

    public GameObject newRecordText;

    [Header("Mobile Ads")]
    private InterstitialAd interstitial;

    [Header("SFX")]
    [SerializeField] private AudioClip winSoundEffect;

    // https://developers.google.com/admob/unity/interstitial
    // view this documentation on how to create an ad
    // Look at Ad Events next.
    private void RequestInterstitial()
    {
        // test ad IDs
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
        string adUnitId = "unexpected_platform";
#endif

        // REAL ad IDs DO NOT USE IN TEST
        /*
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-6859020072079255~1820319644";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-6859020072079255~9124094598";
#else
        string adUnitId = "unexpected_platform";
#endif
        */
        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);

        // Create empty ad request
        AdRequest request = new AdRequest.Builder().Build();

        // Load the interstitial with the request
        this.interstitial.LoadAd(request);

        // on IOS a NEW interstitial ad object needs to be created
        // each time an interstitial is used.
    }

    private void Awake()
    {
        starOne = GameObject.Find("WinStar1").gameObject;
        starTwo = GameObject.Find("WinStar2").gameObject;
        starThree = GameObject.Find("WinStar3").gameObject;

        UIStarOne = GameObject.Find("UIStar1").gameObject;
        UIStarTwo = GameObject.Find("UIStar2").gameObject;
        UIStarThree = GameObject.Find("UIStar3").gameObject;

        newRecordText = GameObject.Find("NewRecordText").gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameDataManager = GameObject.Find("GameDataManager").GetComponent<GameDataManager>();
        winCanvas = GameObject.Find("WinCanvas");
        itemsRemaining = GameObject.Find("ItemsRemainingText").GetComponent<TextMeshProUGUI>();
        winCanvas.SetActive(false);
        totalItemsInt = playerObjects.Count;
        ItemsRemaining();
        DisableAllStars();
        levelComplete = false;
        newRecordText.SetActive(false);
        timerMaster = GameObject.Find("TimerMaster").GetComponent<TimerMaster>();
    }

    public void ToggleAllUIStars()
    {
        UIStarOne.SetActive(true);
        UIStarTwo.SetActive(true);
        UIStarThree.SetActive(true);
    }

    public void CheckWinCondition()
    {
        if (objectsTriggered == totalItemsInt)
        {
            Invoke("WinTrigger", 0f);
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = winSoundEffect;
            audio.Play();
        }
    }

    public void DisableAllStars()
    {
        starOne.SetActive(false);
        starTwo.SetActive(false);
        starThree.SetActive(false);
    }

    public void ThreeStars()
    {
        starOne.SetActive(true);
        starTwo.SetActive(true);
        starThree.SetActive(true);
        starsRewarded = 3;
    }

    public void TwoStars()
    {
        starOne.SetActive(true);
        starTwo.SetActive(true);
        starsRewarded = 2;
    }

    public void OneStar()
    {
        starOne.SetActive(true);
        starsRewarded = 1;
    }

    public void CheckTimeScore(float timer, float threeStarTime, float twoStarTime)
    {
        if (timer <= threeStarTime)
        {
            ThreeStars();
            Debug.Log("Three Stars!");
        }
        else if (timer <= twoStarTime)
        {
            TwoStars();
            Debug.Log("Two Stars!");
        }
        else
        {
            OneStar();
            Debug.Log("One Star!");
        }
    }


    public void CheckTimeScoreLevel1(float timer)
    {
        float threeStarTime = 10f;
        float twoStarTime = 15f;

        StarCheck(timer, threeStarTime, twoStarTime);
        if (levelComplete && !levelCompleteSaveProgress)
        {
            levelCompleteSaveProgress = true;
            CheckTimeScore(timer, threeStarTime, twoStarTime);

            if (timer <= threeStarTime)
            {
                gameDataManager.SetLevel1Stars(3);
                return;
            }
            else if (timer <= twoStarTime)
            {
                gameDataManager.SetLevel1Stars(2);
                return;
            }
            else if (timer > twoStarTime)
            {
                gameDataManager.SetLevel1Stars(1);
            }
        }
    }

    public void CheckTimeScoreLevel2(float timer)
    {
        StarCheck(timer, 13f, 17f);
        if (levelComplete)
        {
            CheckTimeScore(timer, 13f, 17f);
        }
    }

    public void CheckTimeScoreLevel3(float timer)
    {
        StarCheck(timer, 13f, 17f);
        if (levelComplete)
        {
            CheckTimeScore(timer, 13f, 17f);
        }

    }

    public void CheckTimeScoreLevel4(float timer)
    {
        StarCheck(timer, 9f, 13f);
        if (levelComplete)
        {
            CheckTimeScore(timer, 9f, 13f);
        }
    }

    public void CheckTimeScoreLevel5(float timer)
    {
        StarCheck(timer, 7f, 14f);
        if (levelComplete)
        {
            CheckTimeScore(timer, 7f, 14f);
        }

    }

    public void CheckTimeScoreLevel6(float timer)
    {
        StarCheck(timer, 12f, 17f);
        if (levelComplete)
        {
            CheckTimeScore(timer, 12f, 17f);
        }
    }

    public void CheckTimeScoreLevel7(float timer)
    {StarCheck(timer, 13f, 18f);
        if (levelComplete)
        {
            CheckTimeScore(timer, 13f, 18f);
        }
    }

    public void CheckTimeScoreLevel8(float timer)
    {StarCheck(timer, 12f, 17f);
        if (levelComplete)
        {
            CheckTimeScore(timer, 12f, 17f);
        }
    }

    public void CheckTimeScoreLevel9(float timer)
    {StarCheck(timer, 12f, 17f);
        if (levelComplete)
        {
            CheckTimeScore(timer, 12f, 17f);
        }
    }

    public void CheckTimeScoreLevel10(float timer)
    {StarCheck(timer, 40f, 60f);
        if (levelComplete)
        {
            CheckTimeScore(timer, 40f, 60f);
        }

    }

    public void CheckTimeScoreLevel11(float timer)
    {StarCheck(timer, 15f, 22f);
        if (levelComplete)
        {
            CheckTimeScore(timer, 15f, 22f);
        }
    }

    public void CheckTimeScoreLevel12(float timer)
    {StarCheck(timer, 15f, 22f);
        if (levelComplete)
        {
            CheckTimeScore(timer, 15f, 22f);
        }

    }

    public void CheckTimeScoreLevel13(float timer)
    {StarCheck(timer, 10f, 18f);
        if (levelComplete)
        {
            CheckTimeScore(timer, 10f, 18f);
        }
    }

    public void CheckTimeScoreLevel14(float timer)
    {StarCheck(timer, 12f, 17f);
        if (levelComplete)
        {
            CheckTimeScore(timer, 12f, 17f);
        }
    }

    public void CheckTimeScoreLevel15(float timer)
    {StarCheck(timer, 9f, 13f);
        if (levelComplete)
        {
            CheckTimeScore(timer, 9f, 13f);
        }
    }

    public void CheckTimeScoreLevel16(float timer)
    {StarCheck(timer, 17f, 25f);
        if (levelComplete)
        {
            CheckTimeScore(timer, 17f, 25f);
        }
    }


    public void CheckTimeScoreLevel17(float timer)
    {StarCheck(timer, 30f, 40f);
        if (levelComplete)
        {
            CheckTimeScore(timer, 30f, 40f);
        }
    }

    public void CheckTimeScoreLevel18(float timer)
    {StarCheck(timer, 9f, 13f);
        if (levelComplete)
        {
            CheckTimeScore(timer, 9f, 13f);
        }
    }

    public void CheckTimeScoreLevel19(float timer)
    {StarCheck(timer, 6f, 10f);
        if (levelComplete)
        {
            CheckTimeScore(timer, 6f, 10f);
        }
    }


    public void CheckTimeScoreLevel20(float timer)
    {StarCheck(timer, 10f, 20f);
        if (levelComplete)
        {
            CheckTimeScore(timer, 10f, 20f);
        }
    }


    // star check must be done under an update method
    public void StarCheck(float timer, float threeStarTime, float twoStarTime)
    {
        if (timer >= threeStarTime)
        {
            UIStarThree.SetActive(false);
        }
        if (timer >= twoStarTime)
        {
            UIStarTwo.SetActive(false);
        }
    }

    public void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        switch (scene.name)
        {
            case "Level1":
                CheckTimeScoreLevel1(timerMaster.timerSimplified);
                break;
            case "Level2":
                CheckTimeScoreLevel2(timerMaster.timerSimplified);
                break;
            case "Level3":
                CheckTimeScoreLevel3(timerMaster.timerSimplified);
                break;
            case "Level4":
                CheckTimeScoreLevel4(timerMaster.timerSimplified);
                break;
            case "Level5":
                CheckTimeScoreLevel5(timerMaster.timerSimplified);
                break;
            case "Level6":
                CheckTimeScoreLevel6(timerMaster.timerSimplified);
                break;
            case "Level7":
                CheckTimeScoreLevel7(timerMaster.timerSimplified);
                break;
            case "Level8":
                CheckTimeScoreLevel8(timerMaster.timerSimplified);
                break;
            case "Level9":
                CheckTimeScoreLevel9(timerMaster.timerSimplified);
                break;
            case "Level10":
                CheckTimeScoreLevel10(timerMaster.timerSimplified);
                break;
            case "Level11":
                CheckTimeScoreLevel11(timerMaster.timerSimplified);
                break;
            case "Level12":
                CheckTimeScoreLevel12(timerMaster.timerSimplified);
                break;
            case "Level13":
                CheckTimeScoreLevel13(timerMaster.timerSimplified);
                break;
            case "Level14":
                CheckTimeScoreLevel14(timerMaster.timerSimplified);
                break;
            case "Level15":
                CheckTimeScoreLevel15(timerMaster.timerSimplified);
                break;
            case "Level16":
                CheckTimeScoreLevel16(timerMaster.timerSimplified);
                break;
            case "Level17":
                CheckTimeScoreLevel17(timerMaster.timerSimplified);
                break;
            case "Level18":
                CheckTimeScoreLevel18(timerMaster.timerSimplified);
                break;
            case "Level19":
                CheckTimeScoreLevel19(timerMaster.timerSimplified);
                break;
            case "Level20":
                CheckTimeScoreLevel20(timerMaster.timerSimplified);
                break;
        }
    }

    public void WinTrigger()
    {
        winCanvas.SetActive(true);
        Time.timeScale = 0;
        levelComplete = true;

        Scene scene = SceneManager.GetActiveScene();
        switch (scene.name)
        {
            case "Level1":
                gameDataManager.UnlockLevel2();

                CheckTimeScoreLevel1(timerMaster.timerSimplified);
                if (gameDataManager.ReturnLevel1Time() == 111111)
                {
                    gameDataManager.SetLevel1Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                if (gameDataManager.ReturnLevel1Time() != 111111 && (gameDataManager.ReturnLevel1Time() > timerMaster.timerSimplified))
                {
                    gameDataManager.SetLevel1Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                break;
            case "Level2":
                gameDataManager.UnlockLevel3();

                CheckTimeScoreLevel2(timerMaster.timerSimplified);
                if (gameDataManager.ReturnLevel2Time() == 111111)
                {
                    gameDataManager.SetLevel2Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                if (gameDataManager.ReturnLevel2Time() != 111111 && (gameDataManager.ReturnLevel2Time() > timerMaster.timerSimplified))
                {
                    gameDataManager.SetLevel2Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                break;
            case "Level3":
                gameDataManager.UnlockLevel4();

                CheckTimeScoreLevel3(timerMaster.timerSimplified);
                if (gameDataManager.ReturnLevel1Time() == 111111)
                {
                    gameDataManager.SetLevel3Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                if (gameDataManager.ReturnLevel3Time() != 111111 && (gameDataManager.ReturnLevel3Time() > timerMaster.timerSimplified))
                {
                    gameDataManager.SetLevel3Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                break;
            case "Level4":
                gameDataManager.UnlockLevel5();

                CheckTimeScoreLevel4(timerMaster.timerSimplified);
                if (gameDataManager.ReturnLevel4Time() == 111111)
                {
                    gameDataManager.SetLevel4Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                if (gameDataManager.ReturnLevel4Time() != 111111 && (gameDataManager.ReturnLevel4Time() > timerMaster.timerSimplified))
                {
                    gameDataManager.SetLevel4Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                break;
            case "Level5":
                gameDataManager.UnlockLevel6();

                CheckTimeScoreLevel5(timerMaster.timerSimplified);
                if (gameDataManager.ReturnLevel5Time() == 111111)
                {
                    gameDataManager.SetLevel5Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                if (gameDataManager.ReturnLevel5Time() != 111111 && (gameDataManager.ReturnLevel5Time() > timerMaster.timerSimplified))
                {
                    gameDataManager.SetLevel5Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                break;
            case "Level6":
                gameDataManager.UnlockLevel7();

                CheckTimeScoreLevel6(timerMaster.timerSimplified);
                if (gameDataManager.ReturnLevel6Time() == 111111)
                {
                    gameDataManager.SetLevel6Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                if (gameDataManager.ReturnLevel6Time() != 111111 && (gameDataManager.ReturnLevel6Time() > timerMaster.timerSimplified))
                {
                    gameDataManager.SetLevel6Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                break;
            case "Level7":
                gameDataManager.UnlockLevel8();

                CheckTimeScoreLevel7(timerMaster.timerSimplified);
                if (gameDataManager.ReturnLevel7Time() == 111111)
                {
                    gameDataManager.SetLevel7Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                if (gameDataManager.ReturnLevel7Time() != 111111 && (gameDataManager.ReturnLevel7Time() > timerMaster.timerSimplified))
                {
                    gameDataManager.SetLevel7Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                break;
            case "Level8":
                gameDataManager.UnlockLevel9();

                CheckTimeScoreLevel8(timerMaster.timerSimplified);
                if (gameDataManager.ReturnLevel8Time() == 111111)
                {
                    gameDataManager.SetLevel8Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                if (gameDataManager.ReturnLevel8Time() != 111111 && (gameDataManager.ReturnLevel8Time() > timerMaster.timerSimplified))
                {
                    gameDataManager.SetLevel8Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                break;
            case "Level9":
                gameDataManager.UnlockLevel10();

                CheckTimeScoreLevel9(timerMaster.timerSimplified);
                if (gameDataManager.ReturnLevel9Time() == 111111)
                {
                    gameDataManager.SetLevel9Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                if (gameDataManager.ReturnLevel9Time() != 111111 && (gameDataManager.ReturnLevel9Time() > timerMaster.timerSimplified))
                {
                    gameDataManager.SetLevel9Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                break;
            case "Level10":
                gameDataManager.UnlockLevel11();

                CheckTimeScoreLevel10(timerMaster.timerSimplified);
                if (gameDataManager.ReturnLevel10Time() == 111111)
                {
                    gameDataManager.SetLevel10Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                if (gameDataManager.ReturnLevel10Time() != 111111 && (gameDataManager.ReturnLevel10Time() > timerMaster.timerSimplified))
                {
                    gameDataManager.SetLevel10Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                break;
            case "Level11":
                gameDataManager.UnlockLevel12();

                CheckTimeScoreLevel11(timerMaster.timerSimplified);
                if (gameDataManager.ReturnLevel11Time() == 111111)
                {
                    gameDataManager.SetLevel11Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                if (gameDataManager.ReturnLevel11Time() != 111111 && (gameDataManager.ReturnLevel11Time() > timerMaster.timerSimplified))
                {
                    gameDataManager.SetLevel11Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                break;
            case "Level12":
                gameDataManager.UnlockLevel13();

                CheckTimeScoreLevel12(timerMaster.timerSimplified);
                if (gameDataManager.ReturnLevel12Time() == 111111)
                {
                    gameDataManager.SetLevel12Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                if (gameDataManager.ReturnLevel12Time() != 111111 && (gameDataManager.ReturnLevel12Time() > timerMaster.timerSimplified))
                {
                    gameDataManager.SetLevel12Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                break;
            case "Level13":
                gameDataManager.UnlockLevel14();

                CheckTimeScoreLevel13(timerMaster.timerSimplified);
                if (gameDataManager.ReturnLevel13Time() == 111111)
                {
                    gameDataManager.SetLevel13Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                if (gameDataManager.ReturnLevel13Time() != 111111 && (gameDataManager.ReturnLevel13Time() > timerMaster.timerSimplified))
                {
                    gameDataManager.SetLevel13Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                break;
            case "Level14":
                gameDataManager.UnlockLevel15();

                CheckTimeScoreLevel14(timerMaster.timerSimplified);
                if (gameDataManager.ReturnLevel1Time() == 111111)
                {
                    gameDataManager.SetLevel14Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                if (gameDataManager.ReturnLevel14Time() != 111111 && (gameDataManager.ReturnLevel14Time() > timerMaster.timerSimplified))
                {
                    gameDataManager.SetLevel14Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                break;
            case "Level15":
                gameDataManager.UnlockLevel16();

                CheckTimeScoreLevel15(timerMaster.timerSimplified);
                if (gameDataManager.ReturnLevel15Time() == 111111)
                {
                    gameDataManager.SetLevel15Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                if (gameDataManager.ReturnLevel15Time() != 111111 && (gameDataManager.ReturnLevel15Time() > timerMaster.timerSimplified))
                {
                    gameDataManager.SetLevel15Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                break;
            case "Level16":
                gameDataManager.UnlockLevel17();

                CheckTimeScoreLevel16(timerMaster.timerSimplified);
                if (gameDataManager.ReturnLevel16Time() == 111111)
                {
                    gameDataManager.SetLevel16Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                if (gameDataManager.ReturnLevel16Time() != 111111 && (gameDataManager.ReturnLevel16Time() > timerMaster.timerSimplified))
                {
                    gameDataManager.SetLevel16Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                break;
            case "Level17":
                gameDataManager.UnlockLevel18();

                CheckTimeScoreLevel17(timerMaster.timerSimplified);
                if (gameDataManager.ReturnLevel17Time() == 111111)
                {
                    gameDataManager.SetLevel17Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                if (gameDataManager.ReturnLevel17Time() != 111111 && (gameDataManager.ReturnLevel17Time() > timerMaster.timerSimplified))
                {
                    gameDataManager.SetLevel17Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                break;
            case "Level18":
                gameDataManager.UnlockLevel19();

                CheckTimeScoreLevel18(timerMaster.timerSimplified);
                if (gameDataManager.ReturnLevel18Time() == 111111)
                {
                    gameDataManager.SetLevel18Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                if (gameDataManager.ReturnLevel18Time() != 111111 && (gameDataManager.ReturnLevel18Time() > timerMaster.timerSimplified))
                {
                    gameDataManager.SetLevel18Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                break;
            case "Level19":
                gameDataManager.UnlockLevel20();

                CheckTimeScoreLevel19(timerMaster.timerSimplified);
                if (gameDataManager.ReturnLevel19Time() == 111111)
                {
                    gameDataManager.SetLevel19Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                if (gameDataManager.ReturnLevel19Time() != 111111 && (gameDataManager.ReturnLevel19Time() > timerMaster.timerSimplified))
                {
                    gameDataManager.SetLevel19Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                break;
            case "Level20":

                CheckTimeScoreLevel20(timerMaster.timerSimplified);
                if (gameDataManager.ReturnLevel20Time() == 111111)
                {
                    gameDataManager.SetLevel20Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                if (gameDataManager.ReturnLevel20Time() != 111111 && (gameDataManager.ReturnLevel20Time() > timerMaster.timerSimplified))
                {
                    gameDataManager.SetLevel20Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                break;

        }
    }

    public void ItemsRemaining()
    {
        itemsRemainingInt = totalItemsInt - objectsTriggered;
        itemsRemaining.text = itemsRemainingInt.ToString() + " / " + totalItemsInt.ToString() + " Items Remaining";
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach (GameObject obj in playerObjects)
        {
            if (other.gameObject == obj)
            {
                if (obj?.GetComponent<PlayerGuideObjects>().endTriggered == false)
                {
                    Debug.Log("Player object fell through hole");
                    objectsTriggered++;
                    obj.GetComponent<PlayerGuideObjects>().endTriggered = true;
                    Debug.Log(objectsTriggered);
                    Invoke("CheckWinCondition", 1f);
                    ItemsRemaining();
                }
            }
        }
    }
}
