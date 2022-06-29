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

    [Header("Stars")]
    private GameObject starOne;
    private GameObject starTwo;
    private GameObject starThree;

    public bool levelComplete;

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

    public void CheckTimeScore(string levelNumber)
    {
        
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

    public void CheckTimeScoreLevel1(float timer)
    {
        if (timer <= 10f)
        {
            ThreeStars();
            Debug.Log("Three Stars!");
        }
        else if (timer <= 15f)
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

    public void WinTrigger()
    {
        winCanvas.SetActive(true);
        Debug.Log("Win condition achieved");
        Time.timeScale = 0;
        levelComplete = true;

        Scene scene = SceneManager.GetActiveScene();
        switch (scene.name)
        {
            case "Level1":
                gameDataManager.UnlockLevel2();
                
                Debug.Log("Unlocking level 2");

                break;
            case "Level2":
                gameDataManager.UnlockLevel3();
                break;
            case "Level3":
                gameDataManager.UnlockLevel4();

                if (this.interstitial.IsLoaded())
                {
                    this.interstitial.Show();
                }
                break;
            case "Level4":
                gameDataManager.UnlockLevel5();
                break;
            case "Level5":
                gameDataManager.UnlockLevel6();
                break;
            case "Level6":
                gameDataManager.UnlockLevel7();

                if (this.interstitial.IsLoaded())
                {
                    this.interstitial.Show();
                }
                break;
            case "Level7":
                gameDataManager.UnlockLevel8();
                break;
            case "Level8":
                gameDataManager.UnlockLevel9();
                break;
            case "Level9":
                gameDataManager.UnlockLevel10();

                if (this.interstitial.IsLoaded())
                {
                    this.interstitial.Show();
                }
                break;
            case "Level10":
                gameDataManager.UnlockLevel11();
                break;
            case "Level11":
                gameDataManager.UnlockLevel12();
                break;
            case "Level12":
                gameDataManager.UnlockLevel13();

                if (this.interstitial.IsLoaded())
                {
                    this.interstitial.Show();
                }
                break;
            case "Level13":
                gameDataManager.UnlockLevel14();
                break;
            case "Level14":
                gameDataManager.UnlockLevel15();
                break;
            case "Level15":
                gameDataManager.UnlockLevel16();

                if (this.interstitial.IsLoaded())
                {
                    this.interstitial.Show();
                }
                break;
            case "Level16":
                gameDataManager.UnlockLevel17();
                break;
            case "Level17":
                gameDataManager.UnlockLevel18();
                break;
            case "Level18":
                gameDataManager.UnlockLevel19();

                if (this.interstitial.IsLoaded())
                {
                    this.interstitial.Show();
                }
                break;
            case "Level19":
                gameDataManager.UnlockLevel20();
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
