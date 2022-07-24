using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class RewardedAdButton : LoadingMaster, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] Button _showAdButton;
    [SerializeField] string _androidAdUnitId = "Rewarded_Android";
    [SerializeField] string _iOSAdUnitId = "Rewarded_iOS";
    string _adUnitId = null; // This will remain null for unsupported platforms

    private LoadingMaster loadingMaster;

    public GameObject internetRequiredToSkip;

    // button icons
    public GameObject adIcon;
    public GameObject skipLevelIcon;

    public override void Awake()
    {
        gameDataManager = GameObject.Find("GameDataManager").GetComponent<GameDataManager>();
        loadingCanvas = GameObject.Find("LoadingCanvas");
        loadingCanvas?.SetActive(false);
        Time.timeScale = 1;
        adMaster = GameObject.Find("InterstitalAd").GetComponent<AdMaster>();

        loadingMaster = GameObject.Find("LoadingMaster").GetComponent<LoadingMaster>();
        adIcon = GameObject.Find("AdIcon");
        skipLevelIcon = GameObject.Find("SkipLevelIcon");
        CheckIfNextLevelUnlocked();
        // Get the Ad Unit ID for the current platform:
#if UNITY_IOS
        _adUnitId = _iOSAdUnitId;
#elif UNITY_ANDROID
        _adUnitId = _androidAdUnitId;
#endif

        //Disable the button until the ad is ready to show:
        _showAdButton.interactable = false;
        internetRequiredToSkip.SetActive(true);

    }

    public void Start()
    {
        LoadAd();
    }

    // Load content to the Ad Unit:
    public void LoadAd()
    {
        // IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
        Debug.Log("Loading Ad: " + _adUnitId);
        Advertisement.Load(_adUnitId, this);
    }

    // If the ad successfully loads, add a listener to the button and enable it:
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log("Ad Loaded: " + adUnitId);

        if (adUnitId.Equals(_adUnitId))
        {
            // Configure the button to call the ShowAd() method when clicked:
            _showAdButton.onClick.AddListener(ShowAd);
            // Enable the button for users to click:
            _showAdButton.interactable = true;
            internetRequiredToSkip.SetActive(false);
        }
        else
        {
            internetRequiredToSkip.SetActive(true);
        }
    }

    public void CheckIfNextLevelUnlocked()
    {
        Scene scene = SceneManager.GetActiveScene();
        switch (scene.name)
        {
            case "Level1":
                if (!gameDataManager.Level2UnlockedCheck())
                {
                    adIcon.SetActive(true);
                    skipLevelIcon.SetActive(false);
                }
                else
                {
                    adIcon.SetActive(false);
                    skipLevelIcon.SetActive(true);
                }
                break;
            case "Level2":
                if (!gameDataManager.Level3UnlockedCheck())
                {
                    adIcon.SetActive(true);
                    skipLevelIcon.SetActive(false);
                }
                else
                {
                    adIcon.SetActive(false);
                    skipLevelIcon.SetActive(true);
                }
                break;
            case "Level3":
                if (!gameDataManager.Level4UnlockedCheck())
                {
                    adIcon.SetActive(true);
                    skipLevelIcon.SetActive(false);
                }
                else
                {
                    adIcon.SetActive(false);
                    skipLevelIcon.SetActive(true);
                }
                break;
            case "Level4":
                if (!gameDataManager.Level5UnlockedCheck())
                {
                    adIcon.SetActive(true);
                    skipLevelIcon.SetActive(false);
                }
                else
                {
                    adIcon.SetActive(false);
                    skipLevelIcon.SetActive(true);
                }
                break;
            case "Level5":
                if (!gameDataManager.Level6UnlockedCheck())
                {
                    adIcon.SetActive(true);
                    skipLevelIcon.SetActive(false);
                }
                else
                {
                    adIcon.SetActive(false);
                    skipLevelIcon.SetActive(true);
                }
                break;
            case "Level6":
                if (!gameDataManager.Level7UnlockedCheck())
                {
                    adIcon.SetActive(true);
                    skipLevelIcon.SetActive(false);
                }
                else
                {
                    adIcon.SetActive(false);
                    skipLevelIcon.SetActive(true);
                }
                break;
            case "Level7":
                if (!gameDataManager.Level8UnlockedCheck())
                {
                    adIcon.SetActive(true);
                    skipLevelIcon.SetActive(false);
                }
                else
                {
                    adIcon.SetActive(false);
                    skipLevelIcon.SetActive(true);
                }
                break;
            case "Level8":
                if (!gameDataManager.Level9UnlockedCheck())
                {
                    adIcon.SetActive(true);
                    skipLevelIcon.SetActive(false);
                }
                else
                {
                    adIcon.SetActive(false);
                    skipLevelIcon.SetActive(true);
                }
                break;
            case "Level9":
                if (!gameDataManager.Level10UnlockedCheck())
                {
                    adIcon.SetActive(true);
                    skipLevelIcon.SetActive(false);
                }
                else
                {
                    adIcon.SetActive(false);
                    skipLevelIcon.SetActive(true);
                }
                break;
            case "Level10":
                if (!gameDataManager.Level11UnlockedCheck())
                {
                    adIcon.SetActive(true);
                    skipLevelIcon.SetActive(false);
                }
                else
                {
                    adIcon.SetActive(false);
                    skipLevelIcon.SetActive(true);
                }
                break;
            case "Level11":
                if (!gameDataManager.Level12UnlockedCheck())
                {
                    adIcon.SetActive(true);
                    skipLevelIcon.SetActive(false);
                }
                else
                {
                    adIcon.SetActive(false);
                    skipLevelIcon.SetActive(true);
                }
                break;
            case "Level12":
                if (!gameDataManager.Level13UnlockedCheck())
                {
                    adIcon.SetActive(true);
                    skipLevelIcon.SetActive(false);
                }
                else
                {
                    adIcon.SetActive(false);
                    skipLevelIcon.SetActive(true);
                }
                break;
            case "Level13":
                if (!gameDataManager.Level14UnlockedCheck())
                {
                    adIcon.SetActive(true);
                    skipLevelIcon.SetActive(false);
                }
                else
                {
                    adIcon.SetActive(false);
                    skipLevelIcon.SetActive(true);
                }
                break;
            case "Level14":
                if (!gameDataManager.Level15UnlockedCheck())
                {
                    adIcon.SetActive(true);
                    skipLevelIcon.SetActive(false);
                }
                else
                {
                    adIcon.SetActive(false);
                    skipLevelIcon.SetActive(true);
                }
                break;
            case "Level15":
                if (!gameDataManager.Level16UnlockedCheck())
                {
                    adIcon.SetActive(true);
                    skipLevelIcon.SetActive(false);
                }
                else
                {
                    adIcon.SetActive(false);
                    skipLevelIcon.SetActive(true);
                }
                break;
            case "Level16":
                if (!gameDataManager.Level17UnlockedCheck())
                {
                    adIcon.SetActive(true);
                    skipLevelIcon.SetActive(false);
                }
                else
                {
                    adIcon.SetActive(false);
                    skipLevelIcon.SetActive(true);
                }

                break;
            case "Level17":
                if (!gameDataManager.Level18UnlockedCheck())
                {
                    adIcon.SetActive(true);
                    skipLevelIcon.SetActive(false);
                }
                else
                {
                    adIcon.SetActive(false);
                    skipLevelIcon.SetActive(true);
                }
                break;
            case "Level18":
                if (!gameDataManager.Level19UnlockedCheck())
                {
                    adIcon.SetActive(true);
                    skipLevelIcon.SetActive(false);
                }
                else
                {
                    adIcon.SetActive(false);
                    skipLevelIcon.SetActive(true);
                }
                break;
            case "Level19":
                if (!gameDataManager.Level20UnlockedCheck())
                {
                    adIcon.SetActive(true);
                    skipLevelIcon.SetActive(false);
                }
                else
                {
                    adIcon.SetActive(false);
                    skipLevelIcon.SetActive(true);
                }
                break;
            case "Level20":
                if (!gameDataManager.Level21UnlockedCheck())
                {
                    adIcon.SetActive(true);
                    skipLevelIcon.SetActive(false);
                }
                else
                {
                    adIcon.SetActive(false);
                    skipLevelIcon.SetActive(true);
                }
                break;
            case "Level21":
                if (!gameDataManager.Level22UnlockedCheck())
                {
                    adIcon.SetActive(true);
                    skipLevelIcon.SetActive(false);
                }
                else
                {
                    adIcon.SetActive(false);
                    skipLevelIcon.SetActive(true);
                }
                    break;

            case "Level22":
                if (!gameDataManager.Level23UnlockedCheck())
                {
                    adIcon.SetActive(true);
                    skipLevelIcon.SetActive(false);
                }
                else
                {
                    adIcon.SetActive(false);
                    skipLevelIcon.SetActive(true);
                }
                break;

            case "Level23":
                if (!gameDataManager.Level24UnlockedCheck())
                {
                    adIcon.SetActive(true);
                    skipLevelIcon.SetActive(false);
                }
                else
                {
                    adIcon.SetActive(false);
                    skipLevelIcon.SetActive(true);
                }
                break;

            case "Level24":
                if (!gameDataManager.Level25UnlockedCheck())
                {
                    adIcon.SetActive(true);
                    skipLevelIcon.SetActive(false);
                }
                else
                {
                    adIcon.SetActive(false);
                    skipLevelIcon.SetActive(true);
                }
                break;
            case "Level25":
                if (!gameDataManager.Level26UnlockedCheck())
                {
                    adIcon.SetActive(true);
                    skipLevelIcon.SetActive(false);
                }
                else
                {
                    adIcon.SetActive(false);
                    skipLevelIcon.SetActive(true);
                }
                break;
            case "Level26":
                if (!gameDataManager.Level27UnlockedCheck())
                {
                    adIcon.SetActive(true);
                    skipLevelIcon.SetActive(false);
                }
                else
                {
                    adIcon.SetActive(false);
                    skipLevelIcon.SetActive(true);
                }
                break;
            case "Level27":
                if (!gameDataManager.Level28UnlockedCheck())
                {
                    adIcon.SetActive(true);
                    skipLevelIcon.SetActive(false);
                }
                else
                {
                    adIcon.SetActive(false);
                    skipLevelIcon.SetActive(true);
                }
                break;
            case "Level28":
                if (!gameDataManager.Level29UnlockedCheck())
                {
                    adIcon.SetActive(true);
                    skipLevelIcon.SetActive(false);
                }
                else
                {
                    adIcon.SetActive(false);
                    skipLevelIcon.SetActive(true);
                }
                break;
            case "Level29":
                if (!gameDataManager.Level30UnlockedCheck())
                {
                    adIcon.SetActive(true);
                    skipLevelIcon.SetActive(false);
                }
                else
                {
                    adIcon.SetActive(false);
                    skipLevelIcon.SetActive(true);
                }
                break;
            case "Level30":
                if (!gameDataManager.Level31UnlockedCheck())
                {
                    adIcon.SetActive(true);
                    skipLevelIcon.SetActive(false);
                }
                else
                {
                    adIcon.SetActive(false);
                    skipLevelIcon.SetActive(true);
                }
                break;
            case "Level31":
                if (!gameDataManager.Level32UnlockedCheck())
                {
                    adIcon.SetActive(true);
                    skipLevelIcon.SetActive(false);
                }
                else
                {
                    adIcon.SetActive(false);
                    skipLevelIcon.SetActive(true);
                }
                break;
            case "Level32":
                if (!gameDataManager.Level33UnlockedCheck())
                {
                    adIcon.SetActive(true);
                    skipLevelIcon.SetActive(false);
                }
                else
                {
                    adIcon.SetActive(false);
                    skipLevelIcon.SetActive(true);
                }
                break;
            case "Level33":
                if (!gameDataManager.Level34UnlockedCheck())
                {
                    adIcon.SetActive(true);
                    skipLevelIcon.SetActive(false);
                }
                else
                {
                    adIcon.SetActive(false);
                    skipLevelIcon.SetActive(true);
                }
                break;
            case "Level34":
                if (!gameDataManager.Level35UnlockedCheck())
                {
                    adIcon.SetActive(true);
                    skipLevelIcon.SetActive(false);
                }
                else
                {
                    adIcon.SetActive(false);
                    skipLevelIcon.SetActive(true);
                }
                break;
            case "Level35":
                if (!gameDataManager.Level36UnlockedCheck())
                {
                    adIcon.SetActive(true);
                    skipLevelIcon.SetActive(false);
                }
                else
                {
                    adIcon.SetActive(false);
                    skipLevelIcon.SetActive(true);
                }
                break;
            case "Level36":
                if (!gameDataManager.Level37UnlockedCheck())
                {
                    adIcon.SetActive(true);
                    skipLevelIcon.SetActive(false);
                }
                else
                {
                    adIcon.SetActive(false);
                    skipLevelIcon.SetActive(true);
                }
                break;
            case "Level37":
                if (!gameDataManager.Level38UnlockedCheck())
                {
                    adIcon.SetActive(true);
                    skipLevelIcon.SetActive(false);
                }
                else
                {
                    adIcon.SetActive(false);
                    skipLevelIcon.SetActive(true);
                }
                break;
            case "Level38":
                if (!gameDataManager.Level39UnlockedCheck())
                {
                    adIcon.SetActive(true);
                    skipLevelIcon.SetActive(false);
                }
                else
                {
                    adIcon.SetActive(false);
                    skipLevelIcon.SetActive(true);
                }
                    break;
            case "Level39":
                if (!gameDataManager.Level40UnlockedCheck())
                {
                    adIcon.SetActive(true);
                    skipLevelIcon.SetActive(false);
                }
                else
                {
                    adIcon.SetActive(false);
                    skipLevelIcon.SetActive(true);
                }
                break;
            case "Level40":
                if (!gameDataManager.Level41UnlockedCheck())
                {
                    adIcon.SetActive(true);
                    skipLevelIcon.SetActive(false);
                }
                else
                {
                    adIcon.SetActive(false);
                    skipLevelIcon.SetActive(true);
                }
                break;
            case "Level41":
                if (!gameDataManager.Level42UnlockedCheck())
                {
                    adIcon.SetActive(true);
                    skipLevelIcon.SetActive(false);
                }
                else
                {
                    adIcon.SetActive(false);
                    skipLevelIcon.SetActive(true);
                }
                break;
            case "Level42":
                if (!gameDataManager.Level43UnlockedCheck())
                {
                    adIcon.SetActive(true);
                    skipLevelIcon.SetActive(false);
                }
                else
                {
                    adIcon.SetActive(false);
                    skipLevelIcon.SetActive(true);
                }
                break;

            case "Level43":
                if (!gameDataManager.Level44UnlockedCheck())
                {
                    adIcon.SetActive(true);
                    skipLevelIcon.SetActive(false);
                }
                else
                {
                    adIcon.SetActive(false);
                    skipLevelIcon.SetActive(true);
                }
                break;

            case "Level44":
                if (!gameDataManager.Level45UnlockedCheck())
                {
                    adIcon.SetActive(true);
                    skipLevelIcon.SetActive(false);
                }
                else
                {
                    adIcon.SetActive(false);
                    skipLevelIcon.SetActive(true);
                }
                break;

            case "Level45":
                if (!gameDataManager.Level46UnlockedCheck())
                {
                    adIcon.SetActive(true);
                    skipLevelIcon.SetActive(false);
                }
                else
                {
                    adIcon.SetActive(false);
                    skipLevelIcon.SetActive(true);
                }
                    break;

            case "Level46":
                if (!gameDataManager.Level47UnlockedCheck())
                {
                    adIcon.SetActive(true);
                    skipLevelIcon.SetActive(false);
                }
                else
                {
                    adIcon.SetActive(false);
                    skipLevelIcon.SetActive(true);
                }
                break;

            case "Level47":
                if (!gameDataManager.Level48UnlockedCheck())
                {
                    adIcon.SetActive(true);
                    skipLevelIcon.SetActive(false);
                }
                else
                {
                    adIcon.SetActive(false);
                    skipLevelIcon.SetActive(true);
                }
                break;

            case "Level48":
                if (!gameDataManager.Level49UnlockedCheck())
                {
                    adIcon.SetActive(true);
                    skipLevelIcon.SetActive(false);
                }
                else
                {
                    adIcon.SetActive(false);
                    skipLevelIcon.SetActive(true);
                }
                break;

            case "Level49":
                if (!gameDataManager.Level50UnlockedCheck())
                {
                    adIcon.SetActive(true);
                    skipLevelIcon.SetActive(false);
                }
                else
                {
                    adIcon.SetActive(false);
                    skipLevelIcon.SetActive(true);
                }
                break;
            case "Level50":
                this.gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }

    // Implement a method to execute when the user clicks the button:
    public void ShowAd()
    {
        Scene scene = SceneManager.GetActiveScene();
        switch (scene.name)
        {
            case "Level1":
                if(!gameDataManager.Level2UnlockedCheck())
                {
                    ActuallyShowAd();
                }
                else
                {
                    int sceneIndex = scene.buildIndex;
                    SceneManager.LoadScene(sceneIndex + 1);
                }
                break;
            case "Level2":
                if (!gameDataManager.Level3UnlockedCheck())
                {
                    ActuallyShowAd();
                }
                else
                {
                    int sceneIndex = scene.buildIndex;
                    SceneManager.LoadScene(sceneIndex + 1);
                }
                break;
            case "Level3":
                if (!gameDataManager.Level4UnlockedCheck())
                {
                    ActuallyShowAd();
                }
                else
                {
                    int sceneIndex = scene.buildIndex;
                    SceneManager.LoadScene(sceneIndex + 1);
                }
                break;
            case "Level4":
                if (!gameDataManager.Level5UnlockedCheck())
                {
                    ActuallyShowAd();
                }
                else
                {
                    int sceneIndex = scene.buildIndex;
                    SceneManager.LoadScene(sceneIndex + 1);
                }
                break;
            case "Level5":
                if (!gameDataManager.Level6UnlockedCheck())
                {
                    ActuallyShowAd();
                }
                else
                {
                    int sceneIndex = scene.buildIndex;
                    SceneManager.LoadScene(sceneIndex + 1);
                }
                break;
            case "Level6":
                if (!gameDataManager.Level7UnlockedCheck())
                {
                    ActuallyShowAd();
                }
                else
                {
                    int sceneIndex = scene.buildIndex;
                    SceneManager.LoadScene(sceneIndex + 1);
                }
                break;
            case "Level7":
                if (!gameDataManager.Level8UnlockedCheck())
                {
                    ActuallyShowAd();
                }
                else
                {
                    int sceneIndex = scene.buildIndex;
                    SceneManager.LoadScene(sceneIndex + 1);
                }
                break;
            case "Level8":
                if (!gameDataManager.Level9UnlockedCheck())
                {
                    ActuallyShowAd();
                }
                else
                {
                    int sceneIndex = scene.buildIndex;
                    SceneManager.LoadScene(sceneIndex + 1);
                }
                break;
            case "Level9":
                if (!gameDataManager.Level10UnlockedCheck())
                {
                    ActuallyShowAd();
                }
                else
                {
                    int sceneIndex = scene.buildIndex;
                    SceneManager.LoadScene(sceneIndex + 1);
                }
                break;
            case "Level10":
                if (!gameDataManager.Level11UnlockedCheck())
                {
                    ActuallyShowAd();
                }
                else
                {
                    int sceneIndex = scene.buildIndex;
                    SceneManager.LoadScene(sceneIndex + 1);
                }
                break;
            case "Level11":
                if (!gameDataManager.Level12UnlockedCheck())
                {
                    ActuallyShowAd();
                }
                else
                {
                    int sceneIndex = scene.buildIndex;
                    SceneManager.LoadScene(sceneIndex + 1);
                }
                break;
            case "Level12":
                if (!gameDataManager.Level13UnlockedCheck())
                {
                    ActuallyShowAd();
                }
                else
                {
                    int sceneIndex = scene.buildIndex;
                    SceneManager.LoadScene(sceneIndex + 1);
                }
                break;
            case "Level13":
                if (!gameDataManager.Level14UnlockedCheck())
                {
                    ActuallyShowAd();
                }
                else
                {
                    int sceneIndex = scene.buildIndex;
                    SceneManager.LoadScene(sceneIndex + 1);
                }
                break;
            case "Level14":
                if (!gameDataManager.Level15UnlockedCheck())
                {
                    ActuallyShowAd();
                }
                else
                {
                    int sceneIndex = scene.buildIndex;
                    SceneManager.LoadScene(sceneIndex + 1);
                }
                break;
            case "Level15":
                if (!gameDataManager.Level16UnlockedCheck())
                {
                    ActuallyShowAd();
                }
                else
                {
                    int sceneIndex = scene.buildIndex;
                    SceneManager.LoadScene(sceneIndex + 1);
                }
                break;
            case "Level16":
                if (!gameDataManager.Level17UnlockedCheck())
                {
                    ActuallyShowAd();
                }
                else
                {
                    int sceneIndex = scene.buildIndex;
                    SceneManager.LoadScene(sceneIndex + 1);
                }

                break;
            case "Level17":
                if (!gameDataManager.Level18UnlockedCheck())
                {
                    ActuallyShowAd();
                }
                else
                {
                    int sceneIndex = scene.buildIndex;
                    SceneManager.LoadScene(sceneIndex + 1);
                }
                break;
            case "Level18":
                if (!gameDataManager.Level19UnlockedCheck())
                {
                    ActuallyShowAd();
                }
                else
                {
                    int sceneIndex = scene.buildIndex;
                    SceneManager.LoadScene(sceneIndex + 1);
                }
                break;
            case "Level19":
                if (!gameDataManager.Level20UnlockedCheck())
                {
                    ActuallyShowAd();
                }
                else
                {
                    int sceneIndex = scene.buildIndex;
                    SceneManager.LoadScene(sceneIndex + 1);
                }
                break;
            case "Level20":
                if (!gameDataManager.Level21UnlockedCheck())
                {
                    ActuallyShowAd();
                }
                else
                {
                    int sceneIndex = scene.buildIndex;
                    SceneManager.LoadScene(sceneIndex + 1);
                }
                break;
            case "Level21":
                if (!gameDataManager.Level22UnlockedCheck())
                {
                    ActuallyShowAd();
                }
                else
                {
                    int sceneIndex = scene.buildIndex;
                    SceneManager.LoadScene(sceneIndex + 1);
                }
                break;

            case "Level22":
                if (!gameDataManager.Level23UnlockedCheck())
                {
                    ActuallyShowAd();
                }
                else
                {
                    int sceneIndex = scene.buildIndex;
                    SceneManager.LoadScene(sceneIndex + 1);
                }
                break;

            case "Level23":
                if (!gameDataManager.Level24UnlockedCheck())
                {
                    ActuallyShowAd();
                }
                else
                {
                    int sceneIndex = scene.buildIndex;
                    SceneManager.LoadScene(sceneIndex + 1);
                }
                break;

            case "Level24":
                if (!gameDataManager.Level25UnlockedCheck())
                {
                    ActuallyShowAd();
                }
                else
                {
                    int sceneIndex = scene.buildIndex;
                    SceneManager.LoadScene(sceneIndex + 1);
                }
                break;
            case "Level25":
                if (!gameDataManager.Level26UnlockedCheck())
                {
                    ActuallyShowAd();
                }
                else
                {
                    int sceneIndex = scene.buildIndex;
                    SceneManager.LoadScene(sceneIndex + 1);
                }
                break;
            case "Level26":
                if (!gameDataManager.Level27UnlockedCheck())
                {
                    ActuallyShowAd();
                }
                else
                {
                    int sceneIndex = scene.buildIndex;
                    SceneManager.LoadScene(sceneIndex + 1);
                }
                break;
            case "Level27":
                if (!gameDataManager.Level28UnlockedCheck())
                {
                    ActuallyShowAd();
                }
                else
                {
                    int sceneIndex = scene.buildIndex;
                    SceneManager.LoadScene(sceneIndex + 1);
                }
                break;
            case "Level28":
                if (!gameDataManager.Level29UnlockedCheck())
                {
                    ActuallyShowAd();
                }
                else
                {
                    int sceneIndex = scene.buildIndex;
                    SceneManager.LoadScene(sceneIndex + 1);
                }
                break;
            case "Level29":
                if (!gameDataManager.Level30UnlockedCheck())
                {
                    ActuallyShowAd();
                }
                else
                {
                    int sceneIndex = scene.buildIndex;
                    SceneManager.LoadScene(sceneIndex + 1);
                }
                break;
            case "Level30":
                if (!gameDataManager.Level31UnlockedCheck())
                {
                    ActuallyShowAd();
                }
                else
                {
                    int sceneIndex = scene.buildIndex;
                    SceneManager.LoadScene(sceneIndex + 1);
                }
                break;
            case "Level31":
                if (!gameDataManager.Level32UnlockedCheck())
                {
                    ActuallyShowAd();
                }
                else
                {
                    int sceneIndex = scene.buildIndex;
                    SceneManager.LoadScene(sceneIndex + 1);
                }
                break;
            case "Level32":
                if (!gameDataManager.Level33UnlockedCheck())
                {
                    ActuallyShowAd();
                }
                else
                {
                    int sceneIndex = scene.buildIndex;
                    SceneManager.LoadScene(sceneIndex + 1);
                }
                break;
            case "Level33":
                if (!gameDataManager.Level34UnlockedCheck())
                {
                    ActuallyShowAd();
                }
                else
                {
                    int sceneIndex = scene.buildIndex;
                    SceneManager.LoadScene(sceneIndex + 1);
                }
                break;
            case "Level34":
                if (!gameDataManager.Level35UnlockedCheck())
                {
                    ActuallyShowAd();
                }
                else
                {
                    int sceneIndex = scene.buildIndex;
                    SceneManager.LoadScene(sceneIndex + 1);
                }
                break;
            case "Level35":
                if (!gameDataManager.Level36UnlockedCheck())
                {
                    ActuallyShowAd();
                }
                else
                {
                    int sceneIndex = scene.buildIndex;
                    SceneManager.LoadScene(sceneIndex + 1);
                }
                break;
            case "Level36":
                if (!gameDataManager.Level37UnlockedCheck())
                {
                    ActuallyShowAd();
                }
                else
                {
                    int sceneIndex = scene.buildIndex;
                    SceneManager.LoadScene(sceneIndex + 1);
                }
                break;
            case "Level37":
                if (!gameDataManager.Level38UnlockedCheck())
                {
                    ActuallyShowAd();
                }
                else
                {
                    int sceneIndex = scene.buildIndex;
                    SceneManager.LoadScene(sceneIndex + 1);
                }
                break;
            case "Level38":
                if (!gameDataManager.Level39UnlockedCheck())
                {
                    ActuallyShowAd();
                }
                else
                {
                    int sceneIndex = scene.buildIndex;
                    SceneManager.LoadScene(sceneIndex + 1);
                }
                break;
            case "Level39":
                if (!gameDataManager.Level40UnlockedCheck())
                {
                    ActuallyShowAd();
                }
                else
                {
                    int sceneIndex = scene.buildIndex;
                    SceneManager.LoadScene(sceneIndex + 1);
                }
                break;
            case "Level40":
                if (!gameDataManager.Level41UnlockedCheck())
                {
                    ActuallyShowAd();
                }
                else
                {
                    int sceneIndex = scene.buildIndex;
                    SceneManager.LoadScene(sceneIndex + 1);
                }
                break;
            case "Level41":
                if (!gameDataManager.Level42UnlockedCheck())
                {
                    ActuallyShowAd();
                }
                else
                {
                    int sceneIndex = scene.buildIndex;
                    SceneManager.LoadScene(sceneIndex + 1);
                }
                break;
            case "Level42":
                if (!gameDataManager.Level43UnlockedCheck())
                {
                    ActuallyShowAd();
                }
                else
                {
                    int sceneIndex = scene.buildIndex;
                    SceneManager.LoadScene(sceneIndex + 1);
                }
                break;

            case "Level43":
                if (!gameDataManager.Level44UnlockedCheck())
                {
                    ActuallyShowAd();
                }
                else
                {
                    int sceneIndex = scene.buildIndex;
                    SceneManager.LoadScene(sceneIndex + 1);
                }
                break;

            case "Level44":
                if (!gameDataManager.Level45UnlockedCheck())
                {
                    ActuallyShowAd();
                }
                else
                {
                    int sceneIndex = scene.buildIndex;
                    SceneManager.LoadScene(sceneIndex + 1);
                }
                break;

            case "Level45":
                if (!gameDataManager.Level46UnlockedCheck())
                {
                    ActuallyShowAd();
                }
                else
                {
                    int sceneIndex = scene.buildIndex;
                    SceneManager.LoadScene(sceneIndex + 1);
                }
                break;

            case "Level46":
                if (!gameDataManager.Level47UnlockedCheck())
                {
                    ActuallyShowAd();
                }
                else
                {
                    int sceneIndex = scene.buildIndex;
                    SceneManager.LoadScene(sceneIndex + 1);
                }
                break;

            case "Level47":
                if (!gameDataManager.Level48UnlockedCheck())
                {
                    ActuallyShowAd();
                }
                else
                {
                    int sceneIndex = scene.buildIndex;
                    SceneManager.LoadScene(sceneIndex + 1);
                }
                break;

            case "Level48":
                if (!gameDataManager.Level49UnlockedCheck())
                {
                    ActuallyShowAd();
                }
                else
                {
                    int sceneIndex = scene.buildIndex;
                    SceneManager.LoadScene(sceneIndex + 1);
                }
                break;

            case "Level49":
                if (!gameDataManager.Level50UnlockedCheck())
                {
                    ActuallyShowAd();
                }
                else
                {
                    int sceneIndex = scene.buildIndex;
                    SceneManager.LoadScene(sceneIndex + 1);
                }
                break;

            default:
                break;
        }
    }

    public void ActuallyShowAd()
    {
        // Disable the button:
        _showAdButton.interactable = false;
        // Then show the ad:
        Advertisement.Show(_adUnitId, this);
    }

    // Implement the Show Listener's OnUnityAdsShowComplete callback method to determine if the user gets a reward:
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("Unity Ads Rewarded Ad Completed");
            // Grant a reward.
            loadingMaster.ClickNextLevel();
            // Load another ad:
            Advertisement.Load(_adUnitId, this);
        }
    }

    // Implement Load and Show Listener error callbacks:
    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
        Debug.Log("User is offline!!!!!!");
        // Use the error details to determine whether to try to load another ad.
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
        // Use the error details to determine whether to try to load another ad.
    }

    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }

    void OnDestroy()
    {
        // Clean up the button listeners:
        _showAdButton.onClick.RemoveAllListeners();
    }
}