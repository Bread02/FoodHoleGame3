using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
// using GoogleMobileAds.Api;
using UnityEngine.Audio;

public class WinTriggerMaster : MonoBehaviour
{
    [Header("Other Scripts")]
    private GameDataManager gameDataManager;
    private TimerMaster timerMaster;
    private CubeTiltController cubeTiltController;

    [Header("Lists")]
    public List<GameObject> playerObjects = new List<GameObject>();

    [Header("Canvas")]
    private GameObject winCanvas;
    private TextMeshProUGUI itemsRemaining;
    private GameObject newRecordText;

    public GameObject restartButton;

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

    [Header("Bools")]
    public bool levelComplete;
    public bool levelCompleteSaveProgress;
    public bool timeScoreChecked;

    [Header("Mobile Ads")]
  //  private InterstitialAd interstitial;

    [Header("Sound Effects")]
    [SerializeField] private AudioClip oneStarWinSoundEffect;
    [SerializeField] private AudioClip twoStarWinSoundEffect;
    [SerializeField] private AudioClip threeStarWinSoundEffect;
    [SerializeField] private AudioClip finalHoledObject;


    [Header("Special Effects")]
    public GameObject winSFX;
    public GameObject explosionSFX;

    [Header("Fruit Salad")]
    public FruitSaladController fruitSaladController;


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

        winSFX = GameObject.Find("ToonConfettiRain").gameObject;

        newRecordText = GameObject.Find("NewRecordText").gameObject;
        explosionSFX = GameObject.Find("RealExplosion").gameObject;

        explosionSFX.SetActive(false);
        winSFX.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        FindItems();
        timeScoreChecked = false;
        winCanvas.SetActive(false);
        totalItemsInt = playerObjects.Count;
        ItemsRemaining();
        DisableAllStars();
        levelComplete = false;
        newRecordText.SetActive(false);
        explosionSFX.SetActive(false);

    }

    public void FindItems()
    {
        restartButton = GameObject.Find("RestartBG");
        gameDataManager = GameObject.Find("GameDataManager").GetComponent<GameDataManager>();
        winCanvas = GameObject.Find("WinCanvas");
        itemsRemaining = GameObject.Find("ItemsRemainingText").GetComponent<TextMeshProUGUI>();
        timerMaster = GameObject.Find("TimerMaster").GetComponent<TimerMaster>();
        fruitSaladController = GameObject.Find("LevelCompleteCanvas").GetComponent<FruitSaladController>();
        cubeTiltController = GameObject.Find("CubeMaster").GetComponent<CubeTiltController>();
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
            // winCanvas.SetActive(true);
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = finalHoledObject;
            audio.Play();
            timerMaster.timeTriggerCheck = true;
            explosionSFX.SetActive(true);
            fruitSaladController.fruitSaladTrigger = true;
            cubeTiltController.DisableController();
            restartButton.SetActive(false);
            cubeTiltController.winTrigger = true;

         //   Time.timeScale = 0;
         //     levelComplete = true;
            StartCoroutine(TriggerWinTrigger());
         //   Invoke("WinTrigger", 0f);
        }
    }

    IEnumerator TriggerWinTrigger()
    {
        yield return new WaitForSeconds(1.5f);
        WinTrigger();
    }

    #region Win Star Toggle
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

    #endregion

    public void CheckTimeScore(float timer, float threeStarTime, float twoStarTime)
    {
        if (!timeScoreChecked)
        {
            Debug.Log("Time score checked is true");
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

    #region Check Time Score Levels
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
        float threeStarTime = 15f;
        float twoStarTime = 22f;

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
        float threeStarTime = 25f;
        float twoStarTime = 33f;

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
        float threeStarTime = 22f;
        float twoStarTime = 30f;

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
        float threeStarTime = 17f;
        float twoStarTime = 25f;

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

    public void CheckTimeScoreLevel21(float timer)
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
                gameDataManager.SetLevel21Stars(3);
                return;
            }
            else if (timer <= twoStarTime)
            {
                gameDataManager.SetLevel21Stars(2);
                return;
            }
            else if (timer > twoStarTime)
            {
                gameDataManager.SetLevel21Stars(1);
            }
        }
    }

    public void CheckTimeScoreLevel22(float timer)
    {
        float threeStarTime = 18f;
        float twoStarTime = 25f;

        StarCheck(timer, threeStarTime, twoStarTime);
        if (levelComplete && !levelCompleteSaveProgress)
        {
            CheckTimeScore(timer, threeStarTime, twoStarTime);

            levelCompleteSaveProgress = true;

            if (timer <= threeStarTime)
            {
                gameDataManager.SetLevel22Stars(3);
                return;
            }
            else if (timer <= twoStarTime)
            {
                gameDataManager.SetLevel22Stars(2);
                return;
            }
            else if (timer > twoStarTime)
            {
                gameDataManager.SetLevel22Stars(1);
            }
        }
    }

    public void CheckTimeScoreLevel23(float timer)
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
                gameDataManager.SetLevel23Stars(3);
                return;
            }
            else if (timer <= twoStarTime)
            {
                gameDataManager.SetLevel23Stars(2);
                return;
            }
            else if (timer > twoStarTime)
            {
                gameDataManager.SetLevel23Stars(1);
            }
        }
    }

    public void CheckTimeScoreLevel24(float timer)
    {
        float threeStarTime = 8f;
        float twoStarTime = 12f;

        StarCheck(timer, threeStarTime, twoStarTime);
        if (levelComplete && !levelCompleteSaveProgress)
        {
            CheckTimeScore(timer, threeStarTime, twoStarTime);

            levelCompleteSaveProgress = true;

            if (timer <= threeStarTime)
            {
                gameDataManager.SetLevel24Stars(3);
                return;
            }
            else if (timer <= twoStarTime)
            {
                gameDataManager.SetLevel24Stars(2);
                return;
            }
            else if (timer > twoStarTime)
            {
                gameDataManager.SetLevel24Stars(1);
            }
        }
    }

    public void CheckTimeScoreLevel25(float timer)
    {
        float threeStarTime = 25f;
        float twoStarTime = 35f;

        StarCheck(timer, threeStarTime, twoStarTime);
        if (levelComplete && !levelCompleteSaveProgress)
        {
            CheckTimeScore(timer, threeStarTime, twoStarTime);

            levelCompleteSaveProgress = true;

            if (timer <= threeStarTime)
            {
                gameDataManager.SetLevel25Stars(3);
                return;
            }
            else if (timer <= twoStarTime)
            {
                gameDataManager.SetLevel25Stars(2);
                return;
            }
            else if (timer > twoStarTime)
            {
                gameDataManager.SetLevel25Stars(1);
            }
        }
    }

    public void CheckTimeScoreLevel26(float timer)
    {
        float threeStarTime = 20f;
        float twoStarTime = 26f;

        StarCheck(timer, threeStarTime, twoStarTime);
        if (levelComplete && !levelCompleteSaveProgress)
        {
            CheckTimeScore(timer, threeStarTime, twoStarTime);

            levelCompleteSaveProgress = true;

            if (timer <= threeStarTime)
            {
                gameDataManager.SetLevel26Stars(3);
                return;
            }
            else if (timer <= twoStarTime)
            {
                gameDataManager.SetLevel26Stars(2);
                return;
            }
            else if (timer > twoStarTime)
            {
                gameDataManager.SetLevel26Stars(1);
            }
        }
    }

    public void CheckTimeScoreLevel27(float timer)
    {
        float threeStarTime = 8f;
        float twoStarTime = 16f;

        StarCheck(timer, threeStarTime, twoStarTime);
        if (levelComplete && !levelCompleteSaveProgress)
        {
            CheckTimeScore(timer, threeStarTime, twoStarTime);

            levelCompleteSaveProgress = true;

            if (timer <= threeStarTime)
            {
                gameDataManager.SetLevel27Stars(3);
                return;
            }
            else if (timer <= twoStarTime)
            {
                gameDataManager.SetLevel27Stars(2);
                return;
            }
            else if (timer > twoStarTime)
            {
                gameDataManager.SetLevel27Stars(1);
            }
        }
    }

    public void CheckTimeScoreLevel28(float timer)
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
                gameDataManager.SetLevel28Stars(3);
                return;
            }
            else if (timer <= twoStarTime)
            {
                gameDataManager.SetLevel28Stars(2);
                return;
            }
            else if (timer > twoStarTime)
            {
                gameDataManager.SetLevel28Stars(1);
            }
        }
    }

    public void CheckTimeScoreLevel29(float timer)
    {
        float threeStarTime = 25f;
        float twoStarTime = 35f;

        StarCheck(timer, threeStarTime, twoStarTime);
        if (levelComplete && !levelCompleteSaveProgress)
        {
            CheckTimeScore(timer, threeStarTime, twoStarTime);

            levelCompleteSaveProgress = true;

            if (timer <= threeStarTime)
            {
                gameDataManager.SetLevel29Stars(3);
                return;
            }
            else if (timer <= twoStarTime)
            {
                gameDataManager.SetLevel29Stars(2);
                return;
            }
            else if (timer > twoStarTime)
            {
                gameDataManager.SetLevel29Stars(1);
            }
        }
    }

    public void CheckTimeScoreLevel30(float timer)
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
                gameDataManager.SetLevel30Stars(3);
                return;
            }
            else if (timer <= twoStarTime)
            {
                gameDataManager.SetLevel30Stars(2);
                return;
            }
            else if (timer > twoStarTime)
            {
                gameDataManager.SetLevel30Stars(1);
            }
        }
    }

    public void CheckTimeScoreLevel31(float timer)
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
                gameDataManager.SetLevel31Stars(3);
                return;
            }
            else if (timer <= twoStarTime)
            {
                gameDataManager.SetLevel31Stars(2);
                return;
            }
            else if (timer > twoStarTime)
            {
                gameDataManager.SetLevel31Stars(1);
            }
        }
    }

    public void CheckTimeScoreLevel32(float timer)
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
                gameDataManager.SetLevel32Stars(3);
                return;
            }
            else if (timer <= twoStarTime)
            {
                gameDataManager.SetLevel32Stars(2);
                return;
            }
            else if (timer > twoStarTime)
            {
                gameDataManager.SetLevel32Stars(1);
            }
        }
    }

    public void CheckTimeScoreLevel33(float timer)
    {
        float threeStarTime = 22f;
        float twoStarTime = 30f;

        StarCheck(timer, threeStarTime, twoStarTime);
        if (levelComplete && !levelCompleteSaveProgress)
        {
            CheckTimeScore(timer, threeStarTime, twoStarTime);

            levelCompleteSaveProgress = true;

            if (timer <= threeStarTime)
            {
                gameDataManager.SetLevel33Stars(3);
                return;
            }
            else if (timer <= twoStarTime)
            {
                gameDataManager.SetLevel33Stars(2);
                return;
            }
            else if (timer > twoStarTime)
            {
                gameDataManager.SetLevel33Stars(1);
            }
        }
    }

    public void CheckTimeScoreLevel34(float timer)
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
                gameDataManager.SetLevel34Stars(3);
                return;
            }
            else if (timer <= twoStarTime)
            {
                gameDataManager.SetLevel34Stars(2);
                return;
            }
            else if (timer > twoStarTime)
            {
                gameDataManager.SetLevel34Stars(1);
            }
        }
    }

    public void CheckTimeScoreLevel35(float timer)
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
                gameDataManager.SetLevel35Stars(3);
                return;
            }
            else if (timer <= twoStarTime)
            {
                gameDataManager.SetLevel35Stars(2);
                return;
            }
            else if (timer > twoStarTime)
            {
                gameDataManager.SetLevel35Stars(1);
            }
        }
    }

    public void CheckTimeScoreLevel36(float timer)
    {
        float threeStarTime = 20f;
        float twoStarTime = 30f;

        StarCheck(timer, threeStarTime, twoStarTime);
        if (levelComplete && !levelCompleteSaveProgress)
        {
            CheckTimeScore(timer, threeStarTime, twoStarTime);

            levelCompleteSaveProgress = true;

            if (timer <= threeStarTime)
            {
                gameDataManager.SetLevel36Stars(3);
                return;
            }
            else if (timer <= twoStarTime)
            {
                gameDataManager.SetLevel36Stars(2);
                return;
            }
            else if (timer > twoStarTime)
            {
                gameDataManager.SetLevel36Stars(1);
            }
        }
    }

    public void CheckTimeScoreLevel37(float timer)
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
                gameDataManager.SetLevel37Stars(3);
                return;
            }
            else if (timer <= twoStarTime)
            {
                gameDataManager.SetLevel37Stars(2);
                return;
            }
            else if (timer > twoStarTime)
            {
                gameDataManager.SetLevel37Stars(1);
            }
        }
    }

    public void CheckTimeScoreLevel38(float timer)
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
                gameDataManager.SetLevel38Stars(3);
                return;
            }
            else if (timer <= twoStarTime)
            {
                gameDataManager.SetLevel38Stars(2);
                return;
            }
            else if (timer > twoStarTime)
            {
                gameDataManager.SetLevel38Stars(1);
            }
        }
    }

    public void CheckTimeScoreLevel39(float timer)
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
                gameDataManager.SetLevel39Stars(3);
                return;
            }
            else if (timer <= twoStarTime)
            {
                gameDataManager.SetLevel39Stars(2);
                return;
            }
            else if (timer > twoStarTime)
            {
                gameDataManager.SetLevel39Stars(1);
            }
        }
    }

    public void CheckTimeScoreLevel40(float timer)
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
                gameDataManager.SetLevel40Stars(3);
                return;
            }
            else if (timer <= twoStarTime)
            {
                gameDataManager.SetLevel40Stars(2);
                return;
            }
            else if (timer > twoStarTime)
            {
                gameDataManager.SetLevel40Stars(1);
            }
        }
    }

    public void CheckTimeScoreLevel41(float timer)
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
                gameDataManager.SetLevel41Stars(3);
                return;
            }
            else if (timer <= twoStarTime)
            {
                gameDataManager.SetLevel41Stars(2);
                return;
            }
            else if (timer > twoStarTime)
            {
                gameDataManager.SetLevel41Stars(1);
            }
        }
    }

    public void CheckTimeScoreLevel42(float timer)
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
                gameDataManager.SetLevel42Stars(3);
                return;
            }
            else if (timer <= twoStarTime)
            {
                gameDataManager.SetLevel42Stars(2);
                return;
            }
            else if (timer > twoStarTime)
            {
                gameDataManager.SetLevel42Stars(1);
            }
        }
    }

    public void CheckTimeScoreLevel43(float timer)
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
                gameDataManager.SetLevel43Stars(3);
                return;
            }
            else if (timer <= twoStarTime)
            {
                gameDataManager.SetLevel43Stars(2);
                return;
            }
            else if (timer > twoStarTime)
            {
                gameDataManager.SetLevel43Stars(1);
            }
        }
    }

    public void CheckTimeScoreLevel44(float timer)
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
                gameDataManager.SetLevel44Stars(3);
                return;
            }
            else if (timer <= twoStarTime)
            {
                gameDataManager.SetLevel44Stars(2);
                return;
            }
            else if (timer > twoStarTime)
            {
                gameDataManager.SetLevel44Stars(1);
            }
        }
    }

    public void CheckTimeScoreLevel45(float timer)
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
                gameDataManager.SetLevel45Stars(3);
                return;
            }
            else if (timer <= twoStarTime)
            {
                gameDataManager.SetLevel45Stars(2);
                return;
            }
            else if (timer > twoStarTime)
            {
                gameDataManager.SetLevel45Stars(1);
            }
        }
    }

    public void CheckTimeScoreLevel46(float timer)
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
                gameDataManager.SetLevel46Stars(3);
                return;
            }
            else if (timer <= twoStarTime)
            {
                gameDataManager.SetLevel46Stars(2);
                return;
            }
            else if (timer > twoStarTime)
            {
                gameDataManager.SetLevel46Stars(1);
            }
        }
    }

    public void CheckTimeScoreLevel47(float timer)
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
                gameDataManager.SetLevel47Stars(3);
                return;
            }
            else if (timer <= twoStarTime)
            {
                gameDataManager.SetLevel47Stars(2);
                return;
            }
            else if (timer > twoStarTime)
            {
                gameDataManager.SetLevel47Stars(1);
            }
        }
    }

    public void CheckTimeScoreLevel48(float timer)
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
                gameDataManager.SetLevel48Stars(3);
                return;
            }
            else if (timer <= twoStarTime)
            {
                gameDataManager.SetLevel48Stars(2);
                return;
            }
            else if (timer > twoStarTime)
            {
                gameDataManager.SetLevel48Stars(1);
            }
        }
    }

    public void CheckTimeScoreLevel49(float timer)
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
                gameDataManager.SetLevel49Stars(3);
                return;
            }
            else if (timer <= twoStarTime)
            {
                gameDataManager.SetLevel49Stars(2);
                return;
            }
            else if (timer > twoStarTime)
            {
                gameDataManager.SetLevel49Stars(1);
            }
        }
    }

    public void CheckTimeScoreLevel50(float timer)
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
                gameDataManager.SetLevel50Stars(3);
                return;
            }
            else if (timer <= twoStarTime)
            {
                gameDataManager.SetLevel50Stars(2);
                return;
            }
            else if (timer > twoStarTime)
            {
                gameDataManager.SetLevel50Stars(1);
            }
        }
    }
    #endregion

    // star check must be done under an update method
    public void StarCheck(float timer, float threeStarTime, float twoStarTime)
    {
        if (timer >= threeStarTime)
        {
        //    Debug.Log("Disabling Star 3");
         //   Debug.Log("Timer is: " + timer);
         //   Debug.Log("3 star time is: " + threeStarTime);
            UIStarThree.SetActive(false);
        }
        if (timer >= twoStarTime)
        {
            UIStarTwo.SetActive(false);
        //    Debug.Log("Two star time is" + twoStarTime);
        }
    }

    public void Update()
    {
        CheckTimeScoreScene();
    }

    public void CheckTimeScoreScene()
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
            case "Level21":
                CheckTimeScoreLevel21(timerMaster.timerSimplified);
                break;
            case "Level22":
                CheckTimeScoreLevel22(timerMaster.timerSimplified);
                break;
            case "Level23":
                CheckTimeScoreLevel23(timerMaster.timerSimplified);
                break;
            case "Level24":
                CheckTimeScoreLevel24(timerMaster.timerSimplified);
                break;
            case "Level25":
                CheckTimeScoreLevel25(timerMaster.timerSimplified);
                break;
            case "Level26":
                CheckTimeScoreLevel26(timerMaster.timerSimplified);
                break;
            case "Level27":
                CheckTimeScoreLevel27(timerMaster.timerSimplified);
                break;
            case "Level28":
                CheckTimeScoreLevel28(timerMaster.timerSimplified);
                break;
            case "Level29":
                CheckTimeScoreLevel29(timerMaster.timerSimplified);
                break;
            case "Level30":
                CheckTimeScoreLevel30(timerMaster.timerSimplified);
                break;
            case "Level31":
                CheckTimeScoreLevel31(timerMaster.timerSimplified);
                break;
            case "Level32":
                CheckTimeScoreLevel32(timerMaster.timerSimplified);
                break;
            case "Level33":
                CheckTimeScoreLevel33(timerMaster.timerSimplified);
                break;
            case "Level34":
                CheckTimeScoreLevel34(timerMaster.timerSimplified);
                break;
            case "Level35":
                CheckTimeScoreLevel35(timerMaster.timerSimplified);
                break;
            case "Level36":
                CheckTimeScoreLevel36(timerMaster.timerSimplified);
                break;
            case "Level37":
                CheckTimeScoreLevel37(timerMaster.timerSimplified);
                break;
            case "Level38":
                CheckTimeScoreLevel38(timerMaster.timerSimplified);
                break;
            case "Level39":
                CheckTimeScoreLevel39(timerMaster.timerSimplified);
                break;
            case "Level40":
                CheckTimeScoreLevel40(timerMaster.timerSimplified);
                break;
            case "Level41":
                CheckTimeScoreLevel41(timerMaster.timerSimplified);
                break;
            case "Level42":
                CheckTimeScoreLevel42(timerMaster.timerSimplified);
                break;
            case "Level43":
                CheckTimeScoreLevel43(timerMaster.timerSimplified);
                break;
            case "Level44":
                CheckTimeScoreLevel44(timerMaster.timerSimplified);
                break;
            case "Level45":
                CheckTimeScoreLevel45(timerMaster.timerSimplified);
                break;
            case "Level46":
                CheckTimeScoreLevel46(timerMaster.timerSimplified);
                break;
            case "Level47":
                CheckTimeScoreLevel47(timerMaster.timerSimplified);
                break;
            case "Level48":
                CheckTimeScoreLevel48(timerMaster.timerSimplified);
                break;
            case "Level49":
                CheckTimeScoreLevel49(timerMaster.timerSimplified);
                break;
            case "Level50":
                CheckTimeScoreLevel50(timerMaster.timerSimplified);
                break;
        }
    }

    public void WinTrigger()
    {
        winCanvas.SetActive(true);
       // Time.timeScale = 0;
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

            case "Level21":
                CheckTimeScoreLevel21(timerMaster.timerSimplified);
                if (gameDataManager.ReturnLevel21Time() == 111111)
                {
                    gameDataManager.SetLevel21Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                if (gameDataManager.ReturnLevel21Time() != 111111 && (gameDataManager.ReturnLevel21Time() > timerMaster.timerSimplified))
                {
                    gameDataManager.SetLevel21Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                break;

            case "Level22":
                CheckTimeScoreLevel22(timerMaster.timerSimplified);
                if (gameDataManager.ReturnLevel22Time() == 111111)
                {
                    gameDataManager.SetLevel22Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                if (gameDataManager.ReturnLevel22Time() != 111111 && (gameDataManager.ReturnLevel22Time() > timerMaster.timerSimplified))
                {
                    gameDataManager.SetLevel22Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                break;

            case "Level23":
                CheckTimeScoreLevel20(timerMaster.timerSimplified);
                if (gameDataManager.ReturnLevel23Time() == 111111)
                {
                    gameDataManager.SetLevel23Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                if (gameDataManager.ReturnLevel23Time() != 111111 && (gameDataManager.ReturnLevel23Time() > timerMaster.timerSimplified))
                {
                    gameDataManager.SetLevel23Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                break;

            case "Level24":
                CheckTimeScoreLevel24(timerMaster.timerSimplified);
                if (gameDataManager.ReturnLevel24Time() == 111111)
                {
                    gameDataManager.SetLevel24Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                if (gameDataManager.ReturnLevel24Time() != 111111 && (gameDataManager.ReturnLevel24Time() > timerMaster.timerSimplified))
                {
                    gameDataManager.SetLevel24Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                break;

            case "Level25":
                CheckTimeScoreLevel25(timerMaster.timerSimplified);
                if (gameDataManager.ReturnLevel25Time() == 111111)
                {
                    gameDataManager.SetLevel25Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                if (gameDataManager.ReturnLevel25Time() != 111111 && (gameDataManager.ReturnLevel25Time() > timerMaster.timerSimplified))
                {
                    gameDataManager.SetLevel25Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                break;

            case "Level26":
                CheckTimeScoreLevel26(timerMaster.timerSimplified);
                if (gameDataManager.ReturnLevel26Time() == 111111)
                {
                    gameDataManager.SetLevel26Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                if (gameDataManager.ReturnLevel26Time() != 111111 && (gameDataManager.ReturnLevel26Time() > timerMaster.timerSimplified))
                {
                    gameDataManager.SetLevel20Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                break;

            case "Level27":
                CheckTimeScoreLevel27(timerMaster.timerSimplified);
                if (gameDataManager.ReturnLevel27Time() == 111111)
                {
                    gameDataManager.SetLevel27Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                if (gameDataManager.ReturnLevel27Time() != 111111 && (gameDataManager.ReturnLevel27Time() > timerMaster.timerSimplified))
                {
                    gameDataManager.SetLevel27Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                break;

            case "Level28":
                CheckTimeScoreLevel28(timerMaster.timerSimplified);
                if (gameDataManager.ReturnLevel28Time() == 111111)
                {
                    gameDataManager.SetLevel28Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                if (gameDataManager.ReturnLevel28Time() != 111111 && (gameDataManager.ReturnLevel28Time() > timerMaster.timerSimplified))
                {
                    gameDataManager.SetLevel28Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                break;

            case "Level29":
                CheckTimeScoreLevel29(timerMaster.timerSimplified);
                if (gameDataManager.ReturnLevel29Time() == 111111)
                {
                    gameDataManager.SetLevel29Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                if (gameDataManager.ReturnLevel29Time() != 111111 && (gameDataManager.ReturnLevel29Time() > timerMaster.timerSimplified))
                {
                    gameDataManager.SetLevel29Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                break;

            case "Level30":
                CheckTimeScoreLevel30(timerMaster.timerSimplified);
                if (gameDataManager.ReturnLevel30Time() == 111111)
                {
                    gameDataManager.SetLevel30Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                if (gameDataManager.ReturnLevel30Time() != 111111 && (gameDataManager.ReturnLevel30Time() > timerMaster.timerSimplified))
                {
                    gameDataManager.SetLevel30Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                break;

            case "Level31":
                CheckTimeScoreLevel31(timerMaster.timerSimplified);
                if (gameDataManager.ReturnLevel31Time() == 111111)
                {
                    gameDataManager.SetLevel31Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                if (gameDataManager.ReturnLevel31Time() != 111111 && (gameDataManager.ReturnLevel31Time() > timerMaster.timerSimplified))
                {
                    gameDataManager.SetLevel31Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                break;

            case "Level32":
                CheckTimeScoreLevel32(timerMaster.timerSimplified);
                if (gameDataManager.ReturnLevel32Time() == 111111)
                {
                    gameDataManager.SetLevel32Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                if (gameDataManager.ReturnLevel32Time() != 111111 && (gameDataManager.ReturnLevel32Time() > timerMaster.timerSimplified))
                {
                    gameDataManager.SetLevel32Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                break;

            case "Level33":
                CheckTimeScoreLevel33(timerMaster.timerSimplified);
                if (gameDataManager.ReturnLevel33Time() == 111111)
                {
                    gameDataManager.SetLevel33Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                if (gameDataManager.ReturnLevel33Time() != 111111 && (gameDataManager.ReturnLevel33Time() > timerMaster.timerSimplified))
                {
                    gameDataManager.SetLevel33Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                break;

            case "Level34":
                CheckTimeScoreLevel34(timerMaster.timerSimplified);
                if (gameDataManager.ReturnLevel34Time() == 111111)
                {
                    gameDataManager.SetLevel34Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                if (gameDataManager.ReturnLevel34Time() != 111111 && (gameDataManager.ReturnLevel34Time() > timerMaster.timerSimplified))
                {
                    gameDataManager.SetLevel34Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                break;

            case "Level35":
                CheckTimeScoreLevel35(timerMaster.timerSimplified);
                if (gameDataManager.ReturnLevel35Time() == 111111)
                {
                    gameDataManager.SetLevel35Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                if (gameDataManager.ReturnLevel35Time() != 111111 && (gameDataManager.ReturnLevel35Time() > timerMaster.timerSimplified))
                {
                    gameDataManager.SetLevel35Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                break;

            case "Level36":
                CheckTimeScoreLevel36(timerMaster.timerSimplified);
                if (gameDataManager.ReturnLevel36Time() == 111111)
                {
                    gameDataManager.SetLevel36Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                if (gameDataManager.ReturnLevel36Time() != 111111 && (gameDataManager.ReturnLevel36Time() > timerMaster.timerSimplified))
                {
                    gameDataManager.SetLevel36Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                break;

            case "Level37":
                CheckTimeScoreLevel37(timerMaster.timerSimplified);
                if (gameDataManager.ReturnLevel37Time() == 111111)
                {
                    gameDataManager.SetLevel37Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                if (gameDataManager.ReturnLevel37Time() != 111111 && (gameDataManager.ReturnLevel37Time() > timerMaster.timerSimplified))
                {
                    gameDataManager.SetLevel37Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                break;

            case "Level38":
                CheckTimeScoreLevel38(timerMaster.timerSimplified);
                if (gameDataManager.ReturnLevel38Time() == 111111)
                {
                    gameDataManager.SetLevel38Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                if (gameDataManager.ReturnLevel38Time() != 111111 && (gameDataManager.ReturnLevel38Time() > timerMaster.timerSimplified))
                {
                    gameDataManager.SetLevel38Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                break;

            case "Level39":
                CheckTimeScoreLevel39(timerMaster.timerSimplified);
                if (gameDataManager.ReturnLevel39Time() == 111111)
                {
                    gameDataManager.SetLevel39Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                if (gameDataManager.ReturnLevel39Time() != 111111 && (gameDataManager.ReturnLevel39Time() > timerMaster.timerSimplified))
                {
                    gameDataManager.SetLevel39Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                break;

            case "Level40":
                CheckTimeScoreLevel40(timerMaster.timerSimplified);
                if (gameDataManager.ReturnLevel40Time() == 111111)
                {
                    gameDataManager.SetLevel40Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                if (gameDataManager.ReturnLevel40Time() != 111111 && (gameDataManager.ReturnLevel40Time() > timerMaster.timerSimplified))
                {
                    gameDataManager.SetLevel40Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                break;

            case "Level41":
                CheckTimeScoreLevel41(timerMaster.timerSimplified);
                if (gameDataManager.ReturnLevel41Time() == 111111)
                {
                    gameDataManager.SetLevel41Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                if (gameDataManager.ReturnLevel41Time() != 111111 && (gameDataManager.ReturnLevel41Time() > timerMaster.timerSimplified))
                {
                    gameDataManager.SetLevel41Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                break;

            case "Level42":
                CheckTimeScoreLevel42(timerMaster.timerSimplified);
                if (gameDataManager.ReturnLevel42Time() == 111111)
                {
                    gameDataManager.SetLevel42Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                if (gameDataManager.ReturnLevel42Time() != 111111 && (gameDataManager.ReturnLevel42Time() > timerMaster.timerSimplified))
                {
                    gameDataManager.SetLevel42Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                break;

            case "Level43":
                CheckTimeScoreLevel43(timerMaster.timerSimplified);
                if (gameDataManager.ReturnLevel43Time() == 111111)
                {
                    gameDataManager.SetLevel43Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                if (gameDataManager.ReturnLevel43Time() != 111111 && (gameDataManager.ReturnLevel43Time() > timerMaster.timerSimplified))
                {
                    gameDataManager.SetLevel43Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                break;

            case "Level44":
                CheckTimeScoreLevel44(timerMaster.timerSimplified);
                if (gameDataManager.ReturnLevel44Time() == 111111)
                {
                    gameDataManager.SetLevel44Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                if (gameDataManager.ReturnLevel44Time() != 111111 && (gameDataManager.ReturnLevel44Time() > timerMaster.timerSimplified))
                {
                    gameDataManager.SetLevel44Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                break;

            case "Level45":
                CheckTimeScoreLevel45(timerMaster.timerSimplified);
                if (gameDataManager.ReturnLevel45Time() == 111111)
                {
                    gameDataManager.SetLevel45Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                if (gameDataManager.ReturnLevel45Time() != 111111 && (gameDataManager.ReturnLevel45Time() > timerMaster.timerSimplified))
                {
                    gameDataManager.SetLevel45Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                break;

            case "Level46":
                CheckTimeScoreLevel46(timerMaster.timerSimplified);
                if (gameDataManager.ReturnLevel46Time() == 111111)
                {
                    gameDataManager.SetLevel46Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                if (gameDataManager.ReturnLevel46Time() != 111111 && (gameDataManager.ReturnLevel46Time() > timerMaster.timerSimplified))
                {
                    gameDataManager.SetLevel46Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                break;

            case "Level47":
                CheckTimeScoreLevel47(timerMaster.timerSimplified);
                if (gameDataManager.ReturnLevel47Time() == 111111)
                {
                    gameDataManager.SetLevel47Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                if (gameDataManager.ReturnLevel47Time() != 111111 && (gameDataManager.ReturnLevel47Time() > timerMaster.timerSimplified))
                {
                    gameDataManager.SetLevel47Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                break;

            case "Level48":
                CheckTimeScoreLevel48(timerMaster.timerSimplified);
                if (gameDataManager.ReturnLevel48Time() == 111111)
                {
                    gameDataManager.SetLevel48Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                if (gameDataManager.ReturnLevel48Time() != 111111 && (gameDataManager.ReturnLevel48Time() > timerMaster.timerSimplified))
                {
                    gameDataManager.SetLevel48Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                break;

            case "Level49":
                CheckTimeScoreLevel49(timerMaster.timerSimplified);
                if (gameDataManager.ReturnLevel49Time() == 111111)
                {
                    gameDataManager.SetLevel49Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                if (gameDataManager.ReturnLevel49Time() != 111111 && (gameDataManager.ReturnLevel49Time() > timerMaster.timerSimplified))
                {
                    gameDataManager.SetLevel49Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                break;

            case "Level50":
                CheckTimeScoreLevel50(timerMaster.timerSimplified);
                if (gameDataManager.ReturnLevel50Time() == 111111)
                {
                    gameDataManager.SetLevel50Time(timerMaster.timerSimplified);
                    newRecordText.SetActive(true);
                }
                if (gameDataManager.ReturnLevel50Time() != 111111 && (gameDataManager.ReturnLevel50Time() > timerMaster.timerSimplified))
                {
                    gameDataManager.SetLevel50Time(timerMaster.timerSimplified);
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
                    Invoke("CheckWinCondition", 0f);
                    ItemsRemaining();
                }
            }
        }
    }
}
