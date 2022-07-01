using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
// using GoogleMobileAds.Api;
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

    public bool timeScoreChecked;

    [Header("Mobile Ads")]
  //  private InterstitialAd interstitial;

    [Header("SFX")]
    [SerializeField] private AudioClip oneStarWinSoundEffect;
    [SerializeField] private AudioClip twoStarWinSoundEffect;
    [SerializeField] private AudioClip threeStarWinSoundEffect;

    public GameObject winSFX;


    // https://developers.google.com/admob/unity/interstitial
    // view this documentation on how to create an ad
    // Look at Ad Events next.
    /*
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
    //    this.interstitial = new InterstitialAd(adUnitId);

    // Create empty ad request
    //    AdRequest request = new AdRequest.Builder().Build();

    // Load the interstitial with the request
    //    this.interstitial.LoadAd(request);

    // on IOS a NEW interstitial ad object needs to be created
    // each time an interstitial is used.
    // }


    private void Awake()
    {
        starOne = GameObject.Find("WinStar1").gameObject;
        starTwo = GameObject.Find("WinStar2").gameObject;
        starThree = GameObject.Find("WinStar3").gameObject;

        UIStarOne = GameObject.Find("UIStar1").gameObject;
        UIStarTwo = GameObject.Find("UIStar2").gameObject;
        UIStarThree = GameObject.Find("UIStar3").gameObject;

        winSFX = GameObject.Find("WinParticles").gameObject;

        newRecordText = GameObject.Find("NewRecordText").gameObject;

        winSFX.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        timeScoreChecked = false;
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
    }

    public void TwoStars()
    {
        starOne.SetActive(true);
        starTwo.SetActive(true);
    }

    public void OneStar()
    {
        starOne.SetActive(true);
    }

    public void CheckTimeScore(float timer, float threeStarTime, float twoStarTime)
    {
        if (!timeScoreChecked)
        {
            timeScoreChecked = true;

            if (timer <= threeStarTime)
            {
                ThreeStars();
                AudioSource audio = GetComponent<AudioSource>();
                audio.clip = threeStarWinSoundEffect;
                audio.Play();
                Debug.Log("Three Stars!");
                winSFX.SetActive(true);
            }
            else if (timer <= twoStarTime)
            {
                TwoStars();
                AudioSource audio = GetComponent<AudioSource>();
                audio.clip = twoStarWinSoundEffect;
                audio.Play();
                Debug.Log("Two Stars!");
            }
            else
            {
                OneStar();
                AudioSource audio = GetComponent<AudioSource>();
                audio.clip = oneStarWinSoundEffect;
                audio.Play();
                Debug.Log("One Star!");
            }
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
        float threeStarTime = 13f;
        float twoStarTime = 17f;

        StarCheck(timer, threeStarTime, twoStarTime);
        if (levelComplete && !levelCompleteSaveProgress)
        {
            CheckTimeScore(timer, threeStarTime, twoStarTime);

            levelCompleteSaveProgress = true;

            if (timer <= threeStarTime)
            {
                gameDataManager.SetLevel2Stars(3);
                return;
            }
            else if (timer <= twoStarTime)
            {
                gameDataManager.SetLevel2Stars(2);
                return;
            }
            else if (timer > twoStarTime)
            {
                gameDataManager.SetLevel2Stars(1);
            }
        }
    }

    public void CheckTimeScoreLevel3(float timer)
    {
        float threeStarTime = 13f;
        float twoStarTime = 17f;

        StarCheck(timer, threeStarTime, twoStarTime);
        if (levelComplete && !levelCompleteSaveProgress)
        {
            CheckTimeScore(timer, threeStarTime, twoStarTime);

            levelCompleteSaveProgress = true;

            if (timer <= threeStarTime)
            {
                gameDataManager.SetLevel3Stars(3);
                return;
            }
            else if (timer <= twoStarTime)
            {
                gameDataManager.SetLevel3Stars(2);
                return;
            }
            else if (timer > twoStarTime)
            {
                gameDataManager.SetLevel3Stars(1);
            }
        }


    }

    public void CheckTimeScoreLevel4(float timer)
    {
        float threeStarTime = 9f;
        float twoStarTime = 13f;

        StarCheck(timer, threeStarTime, twoStarTime);
        if (levelComplete && !levelCompleteSaveProgress)
        {
            CheckTimeScore(timer, threeStarTime, twoStarTime);

            levelCompleteSaveProgress = true;

            if (timer <= threeStarTime)
            {
                gameDataManager.SetLevel4Stars(3);
                return;
            }
            else if (timer <= twoStarTime)
            {
                gameDataManager.SetLevel4Stars(2);
                return;
            }
            else if (timer > twoStarTime)
            {
                gameDataManager.SetLevel4Stars(1);
            }
        }
    }

    public void CheckTimeScoreLevel5(float timer)
    {
        float threeStarTime = 7f;
        float twoStarTime = 14f;

        StarCheck(timer, threeStarTime, twoStarTime);
        if (levelComplete && !levelCompleteSaveProgress)
        {
            CheckTimeScore(timer, threeStarTime, twoStarTime);

            levelCompleteSaveProgress = true;

            if (timer <= threeStarTime)
            {
                gameDataManager.SetLevel5Stars(3);
                return;
            }
            else if (timer <= twoStarTime)
            {
                gameDataManager.SetLevel5Stars(2);
                return;
            }
            else if (timer > twoStarTime)
            {
                gameDataManager.SetLevel5Stars(1);
            }
        }

    }

    public void CheckTimeScoreLevel6(float timer)
    {
        float threeStarTime = 12f;
        float twoStarTime = 17f;

        StarCheck(timer, threeStarTime, twoStarTime);
        if (levelComplete && !levelCompleteSaveProgress)
        {
            CheckTimeScore(timer, threeStarTime, twoStarTime);

            levelCompleteSaveProgress = true;

            if (timer <= threeStarTime)
            {
                gameDataManager.SetLevel6Stars(3);
                return;
            }
            else if (timer <= twoStarTime)
            {
                gameDataManager.SetLevel6Stars(2);
                return;
            }
            else if (timer > twoStarTime)
            {
                gameDataManager.SetLevel6Stars(1);
            }
        }
    }

    public void CheckTimeScoreLevel7(float timer)
    {
        float threeStarTime = 13f;
        float twoStarTime = 18f;

        StarCheck(timer, threeStarTime, twoStarTime);
        if (levelComplete && !levelCompleteSaveProgress)
        {
            CheckTimeScore(timer, threeStarTime, twoStarTime);

            levelCompleteSaveProgress = true;

            if (timer <= threeStarTime)
            {
                gameDataManager.SetLevel7Stars(3);
                return;
            }
            else if (timer <= twoStarTime)
            {
                gameDataManager.SetLevel7Stars(2);
                return;
            }
            else if (timer > twoStarTime)
            {
                gameDataManager.SetLevel7Stars(1);
            }
        }
    }

    public void CheckTimeScoreLevel8(float timer)
    {

        float threeStarTime = 12f;
        float twoStarTime = 17f;

        StarCheck(timer, threeStarTime, twoStarTime);
        if (levelComplete && !levelCompleteSaveProgress)
        {
            CheckTimeScore(timer, threeStarTime, twoStarTime);

            levelCompleteSaveProgress = true;

            if (timer <= threeStarTime)
            {
                gameDataManager.SetLevel8Stars(3);
                return;
            }
            else if (timer <= twoStarTime)
            {
                gameDataManager.SetLevel8Stars(2);
                return;
            }
            else if (timer > twoStarTime)
            {
                gameDataManager.SetLevel8Stars(1);
            }
        }
    }

    public void CheckTimeScoreLevel9(float timer)
    {

        float threeStarTime = 25f;
        float twoStarTime = 40f;

        StarCheck(timer, threeStarTime, twoStarTime);
        if (levelComplete && !levelCompleteSaveProgress)
        {
            CheckTimeScore(timer, threeStarTime, twoStarTime);

            levelCompleteSaveProgress = true;

            if (timer <= threeStarTime)
            {
                gameDataManager.SetLevel9Stars(3);
                return;
            }
            else if (timer <= twoStarTime)
            {
                gameDataManager.SetLevel9Stars(2);
                return;
            }
            else if (timer > twoStarTime)
            {
                gameDataManager.SetLevel9Stars(1);
            }
        }
    }

    public void CheckTimeScoreLevel10(float timer)
    {

        float threeStarTime = 40f;
        float twoStarTime = 60f;

        StarCheck(timer, threeStarTime, twoStarTime);
        if (levelComplete && !levelCompleteSaveProgress)
        {
            CheckTimeScore(timer, threeStarTime, twoStarTime);

            levelCompleteSaveProgress = true;

            if (timer <= threeStarTime)
            {
                gameDataManager.SetLevel10Stars(3);
                return;
            }
            else if (timer <= twoStarTime)
            {
                gameDataManager.SetLevel10Stars(2);
                return;
            }
            else if (timer > twoStarTime)
            {
                gameDataManager.SetLevel10Stars(1);
            }
        }

    }

    public void CheckTimeScoreLevel11(float timer)
    {

        float threeStarTime = 15f;
        float twoStarTime = 22f;

        StarCheck(timer, threeStarTime, twoStarTime);
        if (levelComplete && !levelCompleteSaveProgress)
        {
            CheckTimeScore(timer, threeStarTime, twoStarTime);

            levelCompleteSaveProgress = true;

            if (timer <= threeStarTime)
            {
                gameDataManager.SetLevel11Stars(3);
                return;
            }
            else if (timer <= twoStarTime)
            {
                gameDataManager.SetLevel11Stars(2);
                return;
            }
            else if (timer > twoStarTime)
            {
                gameDataManager.SetLevel11Stars(1);
            }
        }
    }

    public void CheckTimeScoreLevel12(float timer)
    {
        float threeStarTime = 15f;
        float twoStarTime = 22f;

        StarCheck(timer, threeStarTime, twoStarTime);
        if (levelComplete && !levelCompleteSaveProgress)
        {
            CheckTimeScore(timer, threeStarTime, twoStarTime);

            levelCompleteSaveProgress = true;

            if (timer <= threeStarTime)
            {
                gameDataManager.SetLevel12Stars(3);
                return;
            }
            else if (timer <= twoStarTime)
            {
                gameDataManager.SetLevel12Stars(2);
                return;
            }
            else if (timer > twoStarTime)
            {
                gameDataManager.SetLevel12Stars(1);
            }
        }

    }

    public void CheckTimeScoreLevel13(float timer)
    {
        float threeStarTime = 10f;
        float twoStarTime = 18f;

        StarCheck(timer, threeStarTime, twoStarTime);
        if (levelComplete && !levelCompleteSaveProgress)
        {
            CheckTimeScore(timer, threeStarTime, twoStarTime);

            levelCompleteSaveProgress = true;

            if (timer <= threeStarTime)
            {
                gameDataManager.SetLevel13Stars(3);
                return;
            }
            else if (timer <= twoStarTime)
            {
                gameDataManager.SetLevel13Stars(2);
                return;
            }
            else if (timer > twoStarTime)
            {
                gameDataManager.SetLevel13Stars(1);
            }
        }
    }

    public void CheckTimeScoreLevel14(float timer)
    {

        float threeStarTime = 12f;
        float twoStarTime = 17f;

        StarCheck(timer, threeStarTime, twoStarTime);
        if (levelComplete && !levelCompleteSaveProgress)
        {
            CheckTimeScore(timer, threeStarTime, twoStarTime);

            levelCompleteSaveProgress = true;

            if (timer <= threeStarTime)
            {
                gameDataManager.SetLevel14Stars(3);
                return;
            }
            else if (timer <= twoStarTime)
            {
                gameDataManager.SetLevel14Stars(2);
                return;
            }
            else if (timer > twoStarTime)
            {
                gameDataManager.SetLevel14Stars(1);
            }
        }
    }

    public void CheckTimeScoreLevel15(float timer)
    {

        float threeStarTime = 9f;
        float twoStarTime = 13f;

        StarCheck(timer, threeStarTime, twoStarTime);
        if (levelComplete && !levelCompleteSaveProgress)
        {
            CheckTimeScore(timer, threeStarTime, twoStarTime);

            levelCompleteSaveProgress = true;

            if (timer <= threeStarTime)
            {
                gameDataManager.SetLevel15Stars(3);
                return;
            }
            else if (timer <= twoStarTime)
            {
                gameDataManager.SetLevel15Stars(2);
                return;
            }
            else if (timer > twoStarTime)
            {
                gameDataManager.SetLevel15Stars(1);
            }
        }
    }

    public void CheckTimeScoreLevel16(float timer)
    {

        float threeStarTime = 17f;
        float twoStarTime = 25f;

        StarCheck(timer, threeStarTime, twoStarTime);
        if (levelComplete && !levelCompleteSaveProgress)
        {
            CheckTimeScore(timer, threeStarTime, twoStarTime);

            levelCompleteSaveProgress = true;

            if (timer <= threeStarTime)
            {
                gameDataManager.SetLevel16Stars(3);
                return;
            }
            else if (timer <= twoStarTime)
            {
                gameDataManager.SetLevel16Stars(2);
                return;
            }
            else if (timer > twoStarTime)
            {
                gameDataManager.SetLevel16Stars(1);
            }
        }
    }


    public void CheckTimeScoreLevel17(float timer)
    {

        float threeStarTime = 30f;
        float twoStarTime = 40f;

        StarCheck(timer, threeStarTime, twoStarTime);
        if (levelComplete && !levelCompleteSaveProgress)
        {
            CheckTimeScore(timer, threeStarTime, twoStarTime);

            levelCompleteSaveProgress = true;

            if (timer <= threeStarTime)
            {
                gameDataManager.SetLevel17Stars(3);
                return;
            }
            else if (timer <= twoStarTime)
            {
                gameDataManager.SetLevel17Stars(2);
                return;
            }
            else if (timer > twoStarTime)
            {
                gameDataManager.SetLevel17Stars(1);
            }
        }
    }

    public void CheckTimeScoreLevel18(float timer)
    {

        float threeStarTime = 9f;
        float twoStarTime = 13f;

        StarCheck(timer, threeStarTime, twoStarTime);
        if (levelComplete && !levelCompleteSaveProgress)
        {
            CheckTimeScore(timer, threeStarTime, twoStarTime);

            levelCompleteSaveProgress = true;

            if (timer <= threeStarTime)
            {
                gameDataManager.SetLevel18Stars(3);
                return;
            }
            else if (timer <= twoStarTime)
            {
                gameDataManager.SetLevel18Stars(2);
                return;
            }
            else if (timer > twoStarTime)
            {
                gameDataManager.SetLevel18Stars(1);
            }
        }
    }

    public void CheckTimeScoreLevel19(float timer)
    {

        float threeStarTime = 6f;
        float twoStarTime = 10f;

        StarCheck(timer, threeStarTime, twoStarTime);
        if (levelComplete && !levelCompleteSaveProgress)
        {
            CheckTimeScore(timer, threeStarTime, twoStarTime);

            levelCompleteSaveProgress = true;

            if (timer <= threeStarTime)
            {
                gameDataManager.SetLevel19Stars(3);
                return;
            }
            else if (timer <= twoStarTime)
            {
                gameDataManager.SetLevel19Stars(2);
                return;
            }
            else if (timer > twoStarTime)
            {
                gameDataManager.SetLevel19Stars(1);
            }
        }
    }


    public void CheckTimeScoreLevel20(float timer)
    {
        float threeStarTime = 10f;
        float twoStarTime = 20f;

        StarCheck(timer, threeStarTime, twoStarTime);
        if (levelComplete && !levelCompleteSaveProgress)
        {
            CheckTimeScore(timer, threeStarTime, twoStarTime);

            levelCompleteSaveProgress = true;

            if (timer <= threeStarTime)
            {
                gameDataManager.SetLevel20Stars(3);
                return;
            }
            else if (timer <= twoStarTime)
            {
                gameDataManager.SetLevel20Stars(2);
                return;
            }
            else if (timer > twoStarTime)
            {
                gameDataManager.SetLevel20Stars(1);
            }
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
                if (gameDataManager.ReturnLevel3Time() == 111111)
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
           //         Debug.Log("Player object fell through hole");
                    objectsTriggered++;
                    obj.GetComponent<PlayerGuideObjects>().endTriggered = true;
//                    Debug.Log(objectsTriggered);
                    Invoke("CheckWinCondition", 1f);
                    ItemsRemaining();
                }
            }
        }
    }
}
