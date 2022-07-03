using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuManager : LoadingMaster
{
    // Start is called before the first frame update

    public GameObject mainMainCanvas;

    [Header("Level Canvases")]
    public GameObject levelSelectCanvas1;
    public GameObject levelSelectCanvas2;
    public GameObject levelSelectCanvas3;
    public GameObject levelSelectCanvas4;
    public GameObject levelSelectCanvas5;
    public GameObject levelSelectCanvas6;

    public GameObject levelSelectCanvas7;
    public GameObject levelSelectCanvas8;
    public GameObject levelSelectCanvas9;
    public GameObject levelSelectCanvas10;
    public GameObject levelSelectCanvas11;
    public GameObject levelSelectCanvas12;
    public GameObject levelSelectCanvas13;




    [Header("LevelButtons")]
    public GameObject level1Button;
    public GameObject level2Button;
    public GameObject level3Button;
    public GameObject level4Button;
    public GameObject level5Button;
    public GameObject level6Button;
    public GameObject level7Button;
    public GameObject level8Button;
    public GameObject level9Button;
    public GameObject level10Button;
    public GameObject level11Button;
    public GameObject level12Button;
    public GameObject level13Button;
    public GameObject level14Button;
    public GameObject level15Button;
    public GameObject level16Button;
    public GameObject level17Button;
    public GameObject level18Button;
    public GameObject level19Button;
    public GameObject level20Button;

    
    public GameObject level21Button;
    public GameObject level22Button;
    public GameObject level23Button;
    public GameObject level24Button;
    public GameObject level25Button;
    public GameObject level26Button;
    public GameObject level27Button;
    public GameObject level28Button;
    public GameObject level29Button;
    public GameObject level30Button;
    
    public GameObject level31Button;
    public GameObject level32Button;
    public GameObject level33Button;
    public GameObject level34Button;
    public GameObject level35Button;
    public GameObject level36Button;
    public GameObject level37Button;
    public GameObject level38Button;
    public GameObject level39Button;
    public GameObject level40Button;
    public GameObject level41Button;
    public GameObject level42Button;
    public GameObject level43Button;
    public GameObject level44Button;
    public GameObject level45Button;
    public GameObject level46Button;
    public GameObject level47Button;
    public GameObject level48Button;
    public GameObject level49Button;
    public GameObject level50Button;
    


    [Header("LevelStars")]
    public int level1Star1;

    [Header("LevelLockedButtons")]
    public GameObject level2LockedButton;
    public GameObject level3LockedButton;
    public GameObject level4LockedButton;
    public GameObject level5LockedButton;
    public GameObject level6LockedButton;
    public GameObject level7LockedButton;
    public GameObject level8LockedButton;
    public GameObject level9LockedButton;
    public GameObject level10LockedButton;
    public GameObject level11LockedButton;
    public GameObject level12LockedButton;
    public GameObject level13LockedButton;
    public GameObject level14LockedButton;
    public GameObject level15LockedButton;
    public GameObject level16LockedButton;
    public GameObject level17LockedButton;
    public GameObject level18LockedButton;
    public GameObject level19LockedButton;
    public GameObject level20LockedButton;

    
    public GameObject level21LockedButton;
    public GameObject level22LockedButton;
    public GameObject level23LockedButton;
    public GameObject level24LockedButton;
    public GameObject level25LockedButton;
    public GameObject level26LockedButton;
    public GameObject level27LockedButton;
    public GameObject level28LockedButton;
    public GameObject level29LockedButton;
    public GameObject level30LockedButton;
    
    public GameObject level31LockedButton;
    public GameObject level32LockedButton;
    public GameObject level33LockedButton;
    public GameObject level34LockedButton;
    public GameObject level35LockedButton;
    public GameObject level36LockedButton;
    public GameObject level37LockedButton;
    public GameObject level38LockedButton;
    public GameObject level39LockedButton;
    public GameObject level40LockedButton;
    public GameObject level41LockedButton;
    public GameObject level42LockedButton;
    public GameObject level43LockedButton;
    public GameObject level44LockedButton;
    public GameObject level45LockedButton;
    public GameObject level46LockedButton;
    public GameObject level47LockedButton;
    public GameObject level48LockedButton;
    public GameObject level49LockedButton;
    public GameObject level50LockedButton;
    

    [Header("Level 20 stars")]
    public GameObject level20Star1;
    public GameObject level20Star2;
    public GameObject level20Star3;

    [Header("Click Level SFX")]
    public AudioClip clickPlayButton;
    public AudioClip clickLevelSFX;

    public override void Awake()
    {
        gameDataManager = GameObject.Find("GameDataManager").GetComponent<GameDataManager>();
        gameDataManager.ReadGame();
        FindButtons();
        CheckTimeAndLocks();

        loadingCanvas = GameObject.Find("LoadingCanvas");
        loadingCanvas?.SetActive(false);
        Time.timeScale = 1;
    }

    void Start()
    {
        mainMainCanvas.SetActive(true);
        HideAllLevelSelectCanvas();
    }

    private void FindButtons()
    {
        level1Button = GameObject.Find("Level1Button").gameObject;
        level2Button = GameObject.Find("Level2Button").gameObject;
        level3Button = GameObject.Find("Level3Button").gameObject;
        level4Button = GameObject.Find("Level4Button").gameObject;
        level5Button = GameObject.Find("Level5Button").gameObject;
        level6Button = GameObject.Find("Level6Button").gameObject;
        level7Button = GameObject.Find("Level7Button").gameObject;
        level8Button = GameObject.Find("Level8Button").gameObject;
        level9Button = GameObject.Find("Level9Button").gameObject;
        level10Button = GameObject.Find("Level10Button").gameObject;
        level11Button = GameObject.Find("Level11Button").gameObject;
        level12Button = GameObject.Find("Level12Button").gameObject;
        level13Button = GameObject.Find("Level13Button").gameObject;
        level14Button = GameObject.Find("Level14Button").gameObject;
        level15Button = GameObject.Find("Level15Button").gameObject;
        level16Button = GameObject.Find("Level16Button").gameObject;
        level17Button = GameObject.Find("Level17Button").gameObject;
        level18Button = GameObject.Find("Level18Button").gameObject;
        level19Button = GameObject.Find("Level19Button").gameObject;
        level20Button = GameObject.Find("Level20Button").gameObject;

        
        level21Button = GameObject.Find("Level21Button").gameObject;
        level22Button = GameObject.Find("Level22Button").gameObject;
        level23Button = GameObject.Find("Level23Button").gameObject;
        level24Button = GameObject.Find("Level24Button").gameObject;
        level25Button = GameObject.Find("Level25Button").gameObject;
        level26Button = GameObject.Find("Level26Button").gameObject;
        level27Button = GameObject.Find("Level27Button").gameObject;
        level28Button = GameObject.Find("Level28Button").gameObject;
        level29Button = GameObject.Find("Level29Button").gameObject;
        level30Button = GameObject.Find("Level30Button").gameObject;
        
        level31Button = GameObject.Find("Level31Button").gameObject;
        level32Button = GameObject.Find("Level32Button").gameObject;
        level33Button = GameObject.Find("Level33Button").gameObject;
        level34Button = GameObject.Find("Level34Button").gameObject;
        level35Button = GameObject.Find("Level35Button").gameObject;
        level36Button = GameObject.Find("Level36Button").gameObject;
        level37Button = GameObject.Find("Level37Button").gameObject;
        level38Button = GameObject.Find("Level38Button").gameObject;
        level39Button = GameObject.Find("Level39Button").gameObject;
        level40Button = GameObject.Find("Level40Button").gameObject;
        level41Button = GameObject.Find("Level41Button").gameObject;
        level42Button = GameObject.Find("Level42Button").gameObject;
        level43Button = GameObject.Find("Level43Button").gameObject;
        level44Button = GameObject.Find("Level44Button").gameObject;
        level45Button = GameObject.Find("Level45Button").gameObject;
        level46Button = GameObject.Find("Level46Button").gameObject;
        level47Button = GameObject.Find("Level47Button").gameObject;
        level48Button = GameObject.Find("Level48Button").gameObject;
        level49Button = GameObject.Find("Level49Button").gameObject;
        level50Button = GameObject.Find("Level50Button").gameObject;

        

        level2LockedButton = GameObject.Find("Level2LockedButton").gameObject;
        level3LockedButton = GameObject.Find("Level3LockedButton").gameObject;
        level4LockedButton = GameObject.Find("Level4LockedButton").gameObject;
        level5LockedButton = GameObject.Find("Level5LockedButton").gameObject;
        level6LockedButton = GameObject.Find("Level6LockedButton").gameObject;
        level7LockedButton = GameObject.Find("Level7LockedButton").gameObject;
        level8LockedButton = GameObject.Find("Level8LockedButton").gameObject;
        level9LockedButton = GameObject.Find("Level9LockedButton").gameObject;
        level10LockedButton = GameObject.Find("Level10LockedButton").gameObject;
        level11LockedButton = GameObject.Find("Level11LockedButton").gameObject;
        level12LockedButton = GameObject.Find("Level12LockedButton").gameObject;
        level13LockedButton = GameObject.Find("Level13LockedButton").gameObject;
        level14LockedButton = GameObject.Find("Level14LockedButton").gameObject;
        level15LockedButton = GameObject.Find("Level15LockedButton").gameObject;
        level16LockedButton = GameObject.Find("Level16LockedButton").gameObject;
        level17LockedButton = GameObject.Find("Level17LockedButton").gameObject;
        level18LockedButton = GameObject.Find("Level18LockedButton").gameObject;
        level19LockedButton = GameObject.Find("Level19LockedButton").gameObject;
        level20LockedButton = GameObject.Find("Level20LockedButton").gameObject;

        
        level21LockedButton = GameObject.Find("Level21LockedButton").gameObject;
        level22LockedButton = GameObject.Find("Level22LockedButton").gameObject;
        level23LockedButton = GameObject.Find("Level23LockedButton").gameObject;
        level24LockedButton = GameObject.Find("Level24LockedButton").gameObject;
        level25LockedButton = GameObject.Find("Level25LockedButton").gameObject;
        level26LockedButton = GameObject.Find("Level26LockedButton").gameObject;
        level27LockedButton = GameObject.Find("Level27LockedButton").gameObject;
        level28LockedButton = GameObject.Find("Level28LockedButton").gameObject;
        level29LockedButton = GameObject.Find("Level29LockedButton").gameObject;
        level30LockedButton = GameObject.Find("Level30LockedButton").gameObject;

        
        level31LockedButton = GameObject.Find("Level31LockedButton").gameObject;
        level32LockedButton = GameObject.Find("Level32LockedButton").gameObject;
        level33LockedButton = GameObject.Find("Level33LockedButton").gameObject;
        level34LockedButton = GameObject.Find("Level34LockedButton").gameObject;
        level35LockedButton = GameObject.Find("Level35LockedButton").gameObject;
        level36LockedButton = GameObject.Find("Level36LockedButton").gameObject;
        level37LockedButton = GameObject.Find("Level37LockedButton").gameObject;
        level38LockedButton = GameObject.Find("Level38LockedButton").gameObject;
        level39LockedButton = GameObject.Find("Level39LockedButton").gameObject;
        level40LockedButton = GameObject.Find("Level40LockedButton").gameObject;
        level41LockedButton = GameObject.Find("Level41LockedButton").gameObject;
        level42LockedButton = GameObject.Find("Level42LockedButton").gameObject;
        level43LockedButton = GameObject.Find("Level43LockedButton").gameObject;
        level44LockedButton = GameObject.Find("Level44LockedButton").gameObject;
        level45LockedButton = GameObject.Find("Level45LockedButton").gameObject;
        level46LockedButton = GameObject.Find("Level46LockedButton").gameObject;
        level47LockedButton = GameObject.Find("Level47LockedButton").gameObject;
        level48LockedButton = GameObject.Find("Level48LockedButton").gameObject;
        level49LockedButton = GameObject.Find("Level49LockedButton").gameObject;
        level50LockedButton = GameObject.Find("Level50LockedButton").gameObject;
        
    }

    public void ClickPlay()
    {
        mainMainCanvas.SetActive(false);
        levelSelectCanvas1.SetActive(true);
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickPlayButton;
        audio.Play();
    }

    public void ClickMainMenu()
    {
        mainMainCanvas.SetActive(true);
        HideAllLevelSelectCanvas();
    }

    private void CheckTimeAndLocks()
    {
        CheckLevel20TimeAndStars();
        CheckLevel1TimeAndStars();
        CheckLevel2TimeAndStars();
        CheckLevel3TimeAndStars();
        CheckLevel4TimeAndStars();
        CheckLevel5TimeAndStars();
        CheckLevel6TimeAndStars();
        CheckLevel7TimeAndStars();
        CheckLevel8TimeAndStars();
        CheckLevel9TimeAndStars();
        CheckLevel10TimeAndStars();
        CheckLevel11TimeAndStars();
        CheckLevel12TimeAndStars();
        CheckLevel13TimeAndStars();
        CheckLevel14TimeAndStars();
        CheckLevel15TimeAndStars();
        CheckLevel16TimeAndStars();
        CheckLevel17TimeAndStars();
        CheckLevel18TimeAndStars();
        CheckLevel19TimeAndStars();
        CheckLevel20TimeAndStars();

        // Ungreen the following lines of code once these levels are added in.
        
        CheckLevel21TimeAndStars();
        CheckLevel22TimeAndStars();
        CheckLevel23TimeAndStars();
        CheckLevel24TimeAndStars();
        CheckLevel25TimeAndStars();
        CheckLevel26TimeAndStars();
        CheckLevel27TimeAndStars();
        CheckLevel28TimeAndStars();
        CheckLevel29TimeAndStars();
        CheckLevel30TimeAndStars();
        /*
        CheckLevel31TimeAndStars();
        CheckLevel32TimeAndStars();
        CheckLevel33TimeAndStars();
        CheckLevel34TimeAndStars();
        CheckLevel35TimeAndStars();
        CheckLevel36TimeAndStars();
        CheckLevel37TimeAndStars();
        CheckLevel38TimeAndStars();
        CheckLevel39TimeAndStars();
        CheckLevel40TimeAndStars();
        CheckLevel41TimeAndStars();
        CheckLevel42TimeAndStars();
        CheckLevel43TimeAndStars();
        CheckLevel44TimeAndStars();
        CheckLevel45TimeAndStars();
        CheckLevel46TimeAndStars();
        CheckLevel47TimeAndStars();
        CheckLevel48TimeAndStars();
        CheckLevel49TimeAndStars();
        CheckLevel50TimeAndStars();
        
        */
        CheckUnlockedLevels();
    }

    public void HideAllLevelSelectCanvas()
    {
        levelSelectCanvas1.SetActive(false);
        levelSelectCanvas2.SetActive(false);
        levelSelectCanvas3.SetActive(false);
        levelSelectCanvas4.SetActive(false);
        levelSelectCanvas5.SetActive(false);
        levelSelectCanvas6.SetActive(false);

        levelSelectCanvas7.SetActive(false);
        levelSelectCanvas8.SetActive(false);
        levelSelectCanvas9.SetActive(false);
        levelSelectCanvas10.SetActive(false);
        levelSelectCanvas11.SetActive(false);
        levelSelectCanvas12.SetActive(false);
        levelSelectCanvas13.SetActive(false);

    }

    #region Click Pages
    public void ClickPage1()
    {
        HideAllLevelSelectCanvas();
        levelSelectCanvas1.SetActive(true);
    }

    public void ClickPage2()
    {
        HideAllLevelSelectCanvas();
        levelSelectCanvas2.SetActive(true);
    }

    public void ClickPage3()
    {
        HideAllLevelSelectCanvas();
        levelSelectCanvas3.SetActive(true);
    }

    public void ClickPage4()
    {
        HideAllLevelSelectCanvas();
        levelSelectCanvas4.SetActive(true);
    }

    public void ClickPage5()
    {
        HideAllLevelSelectCanvas();
        levelSelectCanvas5.SetActive(true);
    }

    public void ClickPage6()
    {
        HideAllLevelSelectCanvas();
        levelSelectCanvas6.SetActive(true);
    }

    public void ClickPage7()
    {
        HideAllLevelSelectCanvas();
        levelSelectCanvas7.SetActive(true);
    }

    public void ClickPage8()
    {
        HideAllLevelSelectCanvas();
        levelSelectCanvas8.SetActive(true);
    }

    public void ClickPage9()
    {
        HideAllLevelSelectCanvas();
        levelSelectCanvas9.SetActive(true);
    }

    public void ClickPage10()
    {
        HideAllLevelSelectCanvas();
        levelSelectCanvas10.SetActive(true);
    }

    public void ClickPage11()
    {
        HideAllLevelSelectCanvas();
        levelSelectCanvas11.SetActive(true);
    }

    public void ClickPage12()
    {
        HideAllLevelSelectCanvas();
        levelSelectCanvas12.SetActive(true);
    }

    public void ClickPage13()
    {
        HideAllLevelSelectCanvas();
        levelSelectCanvas13.SetActive(true);
    }

    #endregion
    // level stars
    public void LevelStars(GameObject star1, GameObject star2, GameObject star3, int numberOfStars)
    {
        if (numberOfStars == 3)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
        }
        if (numberOfStars == 2)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(false);
        }
        if (numberOfStars == 1)
        {
            star1.SetActive(true);
            star2.SetActive(false);
            star3.SetActive(false);
        }
        if (numberOfStars == 0)
        {
            star1.SetActive(false);
            star2.SetActive(false);
            star3.SetActive(false);
        }
    }

    public void LevelTimeText(float levelTime, TextMeshProUGUI levelTimeText)
    {
        if (levelTime == 111111)
        {
            levelTimeText.text = "Level Not Completed";
            return;
        }
        else
        {
            levelTimeText.text = "Time Record: " + levelTime.ToString() + "s";
            return;
        }
    }

    #region Check Level Time and Stars
    private void CheckLevel1TimeAndStars()
    {
        int level1Stars = gameDataManager.ReturnLevel1Stars();
        float level1Time = gameDataManager.ReturnLevel1Time();
        GameObject level1Star1 = GameObject.Find("Level1Star1");
        GameObject level1Star2 = GameObject.Find("Level1Star2");
        GameObject level1Star3 = GameObject.Find("Level1Star3");

        LevelStars(level1Star1, level1Star2, level1Star3, level1Stars);
        TextMeshProUGUI level1TimeText = GameObject.Find("Level1Time").GetComponent<TextMeshProUGUI>();

        LevelTimeText(level1Time, level1TimeText);
    }

    private void CheckLevel2TimeAndStars()
    {
        int level2Stars = gameDataManager.ReturnLevel2Stars();
        float level2Time = gameDataManager.ReturnLevel2Time();
        GameObject level2Star1 = GameObject.Find("Level2Star1");
        GameObject level2Star2 = GameObject.Find("Level2Star2");
        GameObject level2Star3 = GameObject.Find("Level2Star3");

        LevelStars(level2Star1, level2Star2, level2Star3, level2Stars);
        TextMeshProUGUI levelTimeText = GameObject.Find("Level2Time").GetComponent<TextMeshProUGUI>();

        LevelTimeText(level2Time, levelTimeText);

    }
    private void CheckLevel3TimeAndStars()
    {
        int level3Stars = gameDataManager.ReturnLevel3Stars();
        float level3Time = gameDataManager.ReturnLevel3Time();
        GameObject level3Star1 = GameObject.Find("Level3Star1");
        GameObject level3Star2 = GameObject.Find("Level3Star2");
        GameObject level3Star3 = GameObject.Find("Level3Star3");

        LevelStars(level3Star1, level3Star2, level3Star3, level3Stars);
        TextMeshProUGUI level3TimeText = GameObject.Find("Level3Time").GetComponent<TextMeshProUGUI>();

        LevelTimeText(level3Time, level3TimeText);
    }

    private void CheckLevel4TimeAndStars()
    {
        int levelStars = gameDataManager.ReturnLevel4Stars();
        float levelTime = gameDataManager.ReturnLevel4Time();
        GameObject levelStar1 = GameObject.Find("Level4Star1");
        GameObject levelStar2 = GameObject.Find("Level4Star2");
        GameObject levelStar3 = GameObject.Find("Level4Star3");

        LevelStars(levelStar1, levelStar2, levelStar3, levelStars);
        TextMeshProUGUI levelTimeText = GameObject.Find("Level4Time").GetComponent<TextMeshProUGUI>();

        LevelTimeText(levelTime, levelTimeText);
    }

    private void CheckLevel5TimeAndStars()
    {
        int levelStars = gameDataManager.ReturnLevel5Stars();
        float levelTime = gameDataManager.ReturnLevel5Time();
        GameObject levelStar1 = GameObject.Find("Level5Star1");
        GameObject levelStar2 = GameObject.Find("Level5Star2");
        GameObject levelStar3 = GameObject.Find("Level5Star3");

        LevelStars(levelStar1, levelStar2, levelStar3, levelStars);
        TextMeshProUGUI levelTimeText = GameObject.Find("Level5Time").GetComponent<TextMeshProUGUI>();

        LevelTimeText(levelTime, levelTimeText);
    }

    private void CheckLevel6TimeAndStars()
    {
        int levelStars = gameDataManager.ReturnLevel6Stars();
        float levelTime = gameDataManager.ReturnLevel6Time();
        GameObject levelStar1 = GameObject.Find("Level6Star1");
        GameObject levelStar2 = GameObject.Find("Level6Star2");
        GameObject levelStar3 = GameObject.Find("Level6Star3");

        LevelStars(levelStar1, levelStar2, levelStar3, levelStars);
        TextMeshProUGUI levelTimeText = GameObject.Find("Level6Time").GetComponent<TextMeshProUGUI>();

        LevelTimeText(levelTime, levelTimeText);
    }

    private void CheckLevel7TimeAndStars()
    {
        int levelStars = gameDataManager.ReturnLevel7Stars();
        float levelTime = gameDataManager.ReturnLevel7Time();
        GameObject levelStar1 = GameObject.Find("Level7Star1");
        GameObject levelStar2 = GameObject.Find("Level7Star2");
        GameObject levelStar3 = GameObject.Find("Level7Star3");

        LevelStars(levelStar1, levelStar2, levelStar3, levelStars);
        TextMeshProUGUI levelTimeText = GameObject.Find("Level7Time").GetComponent<TextMeshProUGUI>();

        LevelTimeText(levelTime, levelTimeText);
    }

    private void CheckLevel8TimeAndStars()
    {
        int levelStars = gameDataManager.ReturnLevel8Stars();
        float levelTime = gameDataManager.ReturnLevel8Time();
        GameObject levelStar1 = GameObject.Find("Level8Star1");
        GameObject levelStar2 = GameObject.Find("Level8Star2");
        GameObject levelStar3 = GameObject.Find("Level8Star3");

        LevelStars(levelStar1, levelStar2, levelStar3, levelStars);
        TextMeshProUGUI levelTimeText = GameObject.Find("Level8Time").GetComponent<TextMeshProUGUI>();

        LevelTimeText(levelTime, levelTimeText);
    }

    private void CheckLevel9TimeAndStars()
    {
        int levelStars = gameDataManager.ReturnLevel9Stars();
        float levelTime = gameDataManager.ReturnLevel9Time();
        GameObject levelStar1 = GameObject.Find("Level9Star1");
        GameObject levelStar2 = GameObject.Find("Level9Star2");
        GameObject levelStar3 = GameObject.Find("Level9Star3");

        LevelStars(levelStar1, levelStar2, levelStar3, levelStars);
        TextMeshProUGUI levelTimeText = GameObject.Find("Level9Time").GetComponent<TextMeshProUGUI>();

        LevelTimeText(levelTime, levelTimeText);
    }

    private void CheckLevel10TimeAndStars()
    {
        int levelStars = gameDataManager.ReturnLevel10Stars();
        float levelTime = gameDataManager.ReturnLevel10Time();
        GameObject levelStar1 = GameObject.Find("Level10Star1");
        GameObject levelStar2 = GameObject.Find("Level10Star2");
        GameObject levelStar3 = GameObject.Find("Level10Star3");

        LevelStars(levelStar1, levelStar2, levelStar3, levelStars);
        TextMeshProUGUI levelTimeText = GameObject.Find("Level10Time").GetComponent<TextMeshProUGUI>();

        LevelTimeText(levelTime, levelTimeText);
    }

    private void CheckLevel11TimeAndStars()
    {
        int levelStars = gameDataManager.ReturnLevel11Stars();
        float levelTime = gameDataManager.ReturnLevel11Time();
        GameObject levelStar1 = GameObject.Find("Level11Star1");
        GameObject levelStar2 = GameObject.Find("Level11Star2");
        GameObject levelStar3 = GameObject.Find("Level11Star3");

        LevelStars(levelStar1, levelStar2, levelStar3, levelStars);
        TextMeshProUGUI levelTimeText = GameObject.Find("Level11Time").GetComponent<TextMeshProUGUI>();

        LevelTimeText(levelTime, levelTimeText);
    }

    private void CheckLevel12TimeAndStars()
    {
        int levelStars = gameDataManager.ReturnLevel12Stars();
        float levelTime = gameDataManager.ReturnLevel12Time();
        GameObject levelStar1 = GameObject.Find("Level12Star1");
        GameObject levelStar2 = GameObject.Find("Level12Star2");
        GameObject levelStar3 = GameObject.Find("Level12Star3");

        LevelStars(levelStar1, levelStar2, levelStar3, levelStars);
        TextMeshProUGUI levelTimeText = GameObject.Find("Level12Time").GetComponent<TextMeshProUGUI>();

        LevelTimeText(levelTime, levelTimeText);
    }

    private void CheckLevel13TimeAndStars()
    {
        int levelStars = gameDataManager.ReturnLevel13Stars();
        float levelTime = gameDataManager.ReturnLevel13Time();
        GameObject levelStar1 = GameObject.Find("Level13Star1");
        GameObject levelStar2 = GameObject.Find("Level13Star2");
        GameObject levelStar3 = GameObject.Find("Level13Star3");

        LevelStars(levelStar1, levelStar2, levelStar3, levelStars);
        TextMeshProUGUI levelTimeText = GameObject.Find("Level13Time").GetComponent<TextMeshProUGUI>();

        LevelTimeText(levelTime, levelTimeText);
    }

    private void CheckLevel14TimeAndStars()
    {
        int levelStars = gameDataManager.ReturnLevel14Stars();
        float levelTime = gameDataManager.ReturnLevel14Time();
        GameObject levelStar1 = GameObject.Find("Level14Star1");
        GameObject levelStar2 = GameObject.Find("Level14Star2");
        GameObject levelStar3 = GameObject.Find("Level14Star3");

        LevelStars(levelStar1, levelStar2, levelStar3, levelStars);
        TextMeshProUGUI levelTimeText = GameObject.Find("Level14Time").GetComponent<TextMeshProUGUI>();

        LevelTimeText(levelTime, levelTimeText);
    }

    private void CheckLevel15TimeAndStars()
    {
        int levelStars = gameDataManager.ReturnLevel15Stars();
        float levelTime = gameDataManager.ReturnLevel15Time();
        GameObject levelStar1 = GameObject.Find("Level15Star1");
        GameObject levelStar2 = GameObject.Find("Level15Star2");
        GameObject levelStar3 = GameObject.Find("Level15Star3");

        LevelStars(levelStar1, levelStar2, levelStar3, levelStars);
        TextMeshProUGUI levelTimeText = GameObject.Find("Level15Time").GetComponent<TextMeshProUGUI>();

        LevelTimeText(levelTime, levelTimeText);
    }

    private void CheckLevel16TimeAndStars()
    {
        int levelStars = gameDataManager.ReturnLevel16Stars();
        float levelTime = gameDataManager.ReturnLevel16Time();
        GameObject levelStar1 = GameObject.Find("Level16Star1");
        GameObject levelStar2 = GameObject.Find("Level16Star2");
        GameObject levelStar3 = GameObject.Find("Level16Star3");

        LevelStars(levelStar1, levelStar2, levelStar3, levelStars);
        TextMeshProUGUI levelTimeText = GameObject.Find("Level16Time").GetComponent<TextMeshProUGUI>();

        LevelTimeText(levelTime, levelTimeText);
    }

    private void CheckLevel17TimeAndStars()
    {
        int levelStars = gameDataManager.ReturnLevel17Stars();
        float levelTime = gameDataManager.ReturnLevel17Time();
        GameObject levelStar1 = GameObject.Find("Level17Star1");
        GameObject levelStar2 = GameObject.Find("Level17Star2");
        GameObject levelStar3 = GameObject.Find("Level17Star3");

        LevelStars(levelStar1, levelStar2, levelStar3, levelStars);
        TextMeshProUGUI levelTimeText = GameObject.Find("Level17Time").GetComponent<TextMeshProUGUI>();

        LevelTimeText(levelTime, levelTimeText);
    }

    private void CheckLevel18TimeAndStars()
    {
        int levelStars = gameDataManager.ReturnLevel18Stars();
        float levelTime = gameDataManager.ReturnLevel18Time();
        GameObject levelStar1 = GameObject.Find("Level18Star1");
        GameObject levelStar2 = GameObject.Find("Level18Star2");
        GameObject levelStar3 = GameObject.Find("Level18Star3");

        LevelStars(levelStar1, levelStar2, levelStar3, levelStars);
        TextMeshProUGUI levelTimeText = GameObject.Find("Level18Time").GetComponent<TextMeshProUGUI>();

        LevelTimeText(levelTime, levelTimeText);
    }

    private void CheckLevel19TimeAndStars()
    {
        int levelStars = gameDataManager.ReturnLevel19Stars();
        float levelTime = gameDataManager.ReturnLevel19Time();
        GameObject levelStar1 = GameObject.Find("Level19Star1");
        GameObject levelStar2 = GameObject.Find("Level19Star2");
        GameObject levelStar3 = GameObject.Find("Level19Star3");

        LevelStars(levelStar1, levelStar2, levelStar3, levelStars);
        TextMeshProUGUI levelTimeText = GameObject.Find("Level19Time").GetComponent<TextMeshProUGUI>();

        LevelTimeText(levelTime, levelTimeText);
    }

    private void CheckLevel20TimeAndStars()
    {
        int levelStars = gameDataManager.ReturnLevel20Stars();
        float levelTime = gameDataManager.ReturnLevel20Time();

        LevelStars(level20Star1, level20Star2, level20Star3, levelStars);
        TextMeshProUGUI levelTimeText = GameObject.Find("Level20Time").GetComponent<TextMeshProUGUI>();

        LevelTimeText(levelTime, levelTimeText);
    }

    private void CheckLevel21TimeAndStars()
    {
        int levelStars = gameDataManager.ReturnLevel21Stars();
        float levelTime = gameDataManager.ReturnLevel21Time();
        GameObject levelStar1 = GameObject.Find("Level21Star1");
        GameObject levelStar2 = GameObject.Find("Level21Star2");
        GameObject levelStar3 = GameObject.Find("Level21Star3");

        LevelStars(levelStar1, levelStar2, levelStar3, levelStars);
        TextMeshProUGUI levelTimeText = GameObject.Find("Level21Time").GetComponent<TextMeshProUGUI>();

        LevelTimeText(levelTime, levelTimeText);
    }

    private void CheckLevel22TimeAndStars()
    {
        int levelStars = gameDataManager.ReturnLevel2Stars();
        float levelTime = gameDataManager.ReturnLevel22Time();
        GameObject levelStar1 = GameObject.Find("Level22Star1");
        GameObject levelStar2 = GameObject.Find("Level22Star2");
        GameObject levelStar3 = GameObject.Find("Level22Star3");

        LevelStars(levelStar1, levelStar2, levelStar3, levelStars);
        TextMeshProUGUI levelTimeText = GameObject.Find("Level22Time").GetComponent<TextMeshProUGUI>();

        LevelTimeText(levelTime, levelTimeText);
    }

    private void CheckLevel23TimeAndStars()
    {
        int levelStars = gameDataManager.ReturnLevel23Stars();
        float levelTime = gameDataManager.ReturnLevel23Time();
        GameObject levelStar1 = GameObject.Find("Level23Star1");
        GameObject levelStar2 = GameObject.Find("Level23Star2");
        GameObject levelStar3 = GameObject.Find("Level23Star3");

        LevelStars(levelStar1, levelStar2, levelStar3, levelStars);
        TextMeshProUGUI levelTimeText = GameObject.Find("Level23Time").GetComponent<TextMeshProUGUI>();

        LevelTimeText(levelTime, levelTimeText);
    }

    private void CheckLevel24TimeAndStars()
    {
        int levelStars = gameDataManager.ReturnLevel24Stars();
        float levelTime = gameDataManager.ReturnLevel24Time();
        GameObject levelStar1 = GameObject.Find("Level24Star1");
        GameObject levelStar2 = GameObject.Find("Level24Star2");
        GameObject levelStar3 = GameObject.Find("Level24Star3");

        LevelStars(levelStar1, levelStar2, levelStar3, levelStars);
        TextMeshProUGUI levelTimeText = GameObject.Find("Level24Time").GetComponent<TextMeshProUGUI>();

        LevelTimeText(levelTime, levelTimeText);
    }

    private void CheckLevel25TimeAndStars()
    {
        int levelStars = gameDataManager.ReturnLevel25Stars();
        float levelTime = gameDataManager.ReturnLevel25Time();
        GameObject levelStar1 = GameObject.Find("Level25Star1");
        GameObject levelStar2 = GameObject.Find("Level25Star2");
        GameObject levelStar3 = GameObject.Find("Level25Star3");

        LevelStars(levelStar1, levelStar2, levelStar3, levelStars);
        TextMeshProUGUI levelTimeText = GameObject.Find("Level25Time").GetComponent<TextMeshProUGUI>();

        LevelTimeText(levelTime, levelTimeText);
    }

    private void CheckLevel26TimeAndStars()
    {
        int levelStars = gameDataManager.ReturnLevel26Stars();
        float levelTime = gameDataManager.ReturnLevel26Time();
        GameObject levelStar1 = GameObject.Find("Level26Star1");
        GameObject levelStar2 = GameObject.Find("Level26Star2");
        GameObject levelStar3 = GameObject.Find("Level26Star3");

        LevelStars(levelStar1, levelStar2, levelStar3, levelStars);
        TextMeshProUGUI levelTimeText = GameObject.Find("Level26Time").GetComponent<TextMeshProUGUI>();

        LevelTimeText(levelTime, levelTimeText);
    }

    private void CheckLevel27TimeAndStars()
    {
        int levelStars = gameDataManager.ReturnLevel27Stars();
        float levelTime = gameDataManager.ReturnLevel27Time();
        GameObject levelStar1 = GameObject.Find("Level27Star1");
        GameObject levelStar2 = GameObject.Find("Level27Star2");
        GameObject levelStar3 = GameObject.Find("Level27Star3");

        LevelStars(levelStar1, levelStar2, levelStar3, levelStars);
        TextMeshProUGUI levelTimeText = GameObject.Find("Level27Time").GetComponent<TextMeshProUGUI>();

        LevelTimeText(levelTime, levelTimeText);
    }

    private void CheckLevel28TimeAndStars()
    {
        int levelStars = gameDataManager.ReturnLevel28Stars();
        float levelTime = gameDataManager.ReturnLevel28Time();
        GameObject levelStar1 = GameObject.Find("Level28Star1");
        GameObject levelStar2 = GameObject.Find("Level28Star2");
        GameObject levelStar3 = GameObject.Find("Level28Star3");

        LevelStars(levelStar1, levelStar2, levelStar3, levelStars);
        TextMeshProUGUI levelTimeText = GameObject.Find("Level28Time").GetComponent<TextMeshProUGUI>();

        LevelTimeText(levelTime, levelTimeText);
    }

    private void CheckLevel29TimeAndStars()
    {
        int levelStars = gameDataManager.ReturnLevel29Stars();
        float levelTime = gameDataManager.ReturnLevel29Time();
        GameObject levelStar1 = GameObject.Find("Level29Star1");
        GameObject levelStar2 = GameObject.Find("Level29Star2");
        GameObject levelStar3 = GameObject.Find("Level29Star3");

        LevelStars(levelStar1, levelStar2, levelStar3, levelStars);
        TextMeshProUGUI levelTimeText = GameObject.Find("Level29Time").GetComponent<TextMeshProUGUI>();

        LevelTimeText(levelTime, levelTimeText);
    }

    private void CheckLevel30TimeAndStars()
    {
        int levelStars = gameDataManager.ReturnLevel30Stars();
        float levelTime = gameDataManager.ReturnLevel30Time();
        GameObject levelStar1 = GameObject.Find("Level30Star1");
        GameObject levelStar2 = GameObject.Find("Level30Star2");
        GameObject levelStar3 = GameObject.Find("Level30Star3");

        LevelStars(levelStar1, levelStar2, levelStar3, levelStars);
        TextMeshProUGUI levelTimeText = GameObject.Find("Level30Time").GetComponent<TextMeshProUGUI>();

        LevelTimeText(levelTime, levelTimeText);
    }

    private void CheckLevel31TimeAndStars()
    {
        int levelStars = gameDataManager.ReturnLevel31Stars();
        float levelTime = gameDataManager.ReturnLevel31Time();
        GameObject levelStar1 = GameObject.Find("Level31Star1");
        GameObject levelStar2 = GameObject.Find("Level31Star2");
        GameObject levelStar3 = GameObject.Find("Level31Star3");

        LevelStars(levelStar1, levelStar2, levelStar3, levelStars);
        TextMeshProUGUI levelTimeText = GameObject.Find("Level31Time").GetComponent<TextMeshProUGUI>();

        LevelTimeText(levelTime, levelTimeText);
    }

    private void CheckLevel32TimeAndStars()
    {
        int levelStars = gameDataManager.ReturnLevel32Stars();
        float levelTime = gameDataManager.ReturnLevel32Time();
        GameObject levelStar1 = GameObject.Find("Level32Star1");
        GameObject levelStar2 = GameObject.Find("Level32Star2");
        GameObject levelStar3 = GameObject.Find("Level32Star3");

        LevelStars(levelStar1, levelStar2, levelStar3, levelStars);
        TextMeshProUGUI levelTimeText = GameObject.Find("Level32Time").GetComponent<TextMeshProUGUI>();

        LevelTimeText(levelTime, levelTimeText);
    }

    private void CheckLevel33TimeAndStars()
    {
        int levelStars = gameDataManager.ReturnLevel33Stars();
        float levelTime = gameDataManager.ReturnLevel33Time();
        GameObject levelStar1 = GameObject.Find("Level33Star1");
        GameObject levelStar2 = GameObject.Find("Level33Star2");
        GameObject levelStar3 = GameObject.Find("Level33Star3");

        LevelStars(levelStar1, levelStar2, levelStar3, levelStars);
        TextMeshProUGUI levelTimeText = GameObject.Find("Level33Time").GetComponent<TextMeshProUGUI>();

        LevelTimeText(levelTime, levelTimeText);
    }

    private void CheckLevel34TimeAndStars()
    {
        int levelStars = gameDataManager.ReturnLevel34Stars();
        float levelTime = gameDataManager.ReturnLevel34Time();
        GameObject levelStar1 = GameObject.Find("Level34Star1");
        GameObject levelStar2 = GameObject.Find("Level34Star2");
        GameObject levelStar3 = GameObject.Find("Level34Star3");

        LevelStars(levelStar1, levelStar2, levelStar3, levelStars);
        TextMeshProUGUI levelTimeText = GameObject.Find("Level34Time").GetComponent<TextMeshProUGUI>();

        LevelTimeText(levelTime, levelTimeText);
    }

    private void CheckLevel35TimeAndStars()
    {
        int levelStars = gameDataManager.ReturnLevel35Stars();
        float levelTime = gameDataManager.ReturnLevel35Time();
        GameObject levelStar1 = GameObject.Find("Level35Star1");
        GameObject levelStar2 = GameObject.Find("Level35Star2");
        GameObject levelStar3 = GameObject.Find("Level35Star3");

        LevelStars(levelStar1, levelStar2, levelStar3, levelStars);
        TextMeshProUGUI levelTimeText = GameObject.Find("Level35Time").GetComponent<TextMeshProUGUI>();

        LevelTimeText(levelTime, levelTimeText);
    }

    private void CheckLevel36TimeAndStars()
    {
        int levelStars = gameDataManager.ReturnLevel36Stars();
        float levelTime = gameDataManager.ReturnLevel36Time();
        GameObject levelStar1 = GameObject.Find("Level36Star1");
        GameObject levelStar2 = GameObject.Find("Level36Star2");
        GameObject levelStar3 = GameObject.Find("Level36Star3");

        LevelStars(levelStar1, levelStar2, levelStar3, levelStars);
        TextMeshProUGUI levelTimeText = GameObject.Find("Level36Time").GetComponent<TextMeshProUGUI>();

        LevelTimeText(levelTime, levelTimeText);
    }

    private void CheckLevel37TimeAndStars()
    {
        int levelStars = gameDataManager.ReturnLevel37Stars();
        float levelTime = gameDataManager.ReturnLevel37Time();
        GameObject levelStar1 = GameObject.Find("Level37Star1");
        GameObject levelStar2 = GameObject.Find("Level37Star2");
        GameObject levelStar3 = GameObject.Find("Level37Star3");

        LevelStars(levelStar1, levelStar2, levelStar3, levelStars);
        TextMeshProUGUI levelTimeText = GameObject.Find("Level37Time").GetComponent<TextMeshProUGUI>();

        LevelTimeText(levelTime, levelTimeText);
    }

    private void CheckLevel38TimeAndStars()
    {
        int levelStars = gameDataManager.ReturnLevel38Stars();
        float levelTime = gameDataManager.ReturnLevel38Time();
        GameObject levelStar1 = GameObject.Find("Level38Star1");
        GameObject levelStar2 = GameObject.Find("Level38Star2");
        GameObject levelStar3 = GameObject.Find("Level38Star3");

        LevelStars(levelStar1, levelStar2, levelStar3, levelStars);
        TextMeshProUGUI levelTimeText = GameObject.Find("Level38Time").GetComponent<TextMeshProUGUI>();

        LevelTimeText(levelTime, levelTimeText);
    }

    private void CheckLevel39TimeAndStars()
    {
        int levelStars = gameDataManager.ReturnLevel39Stars();
        float levelTime = gameDataManager.ReturnLevel39Time();
        GameObject levelStar1 = GameObject.Find("Level39Star1");
        GameObject levelStar2 = GameObject.Find("Level39Star2");
        GameObject levelStar3 = GameObject.Find("Level39Star3");

        LevelStars(levelStar1, levelStar2, levelStar3, levelStars);
        TextMeshProUGUI levelTimeText = GameObject.Find("Level39Time").GetComponent<TextMeshProUGUI>();

        LevelTimeText(levelTime, levelTimeText);
    }

    private void CheckLevel40TimeAndStars()
    {
        int levelStars = gameDataManager.ReturnLevel40Stars();
        float levelTime = gameDataManager.ReturnLevel40Time();
        GameObject levelStar1 = GameObject.Find("Level40Star1");
        GameObject levelStar2 = GameObject.Find("Level40Star2");
        GameObject levelStar3 = GameObject.Find("Level40Star3");

        LevelStars(levelStar1, levelStar2, levelStar3, levelStars);
        TextMeshProUGUI levelTimeText = GameObject.Find("Level40Time").GetComponent<TextMeshProUGUI>();

        LevelTimeText(levelTime, levelTimeText);
    }

    private void CheckLevel41TimeAndStars()
    {
        int levelStars = gameDataManager.ReturnLevel41Stars();
        float levelTime = gameDataManager.ReturnLevel41Time();
        GameObject levelStar1 = GameObject.Find("Level41Star1");
        GameObject levelStar2 = GameObject.Find("Level41Star2");
        GameObject levelStar3 = GameObject.Find("Level41Star3");

        LevelStars(levelStar1, levelStar2, levelStar3, levelStars);
        TextMeshProUGUI levelTimeText = GameObject.Find("Level41Time").GetComponent<TextMeshProUGUI>();

        LevelTimeText(levelTime, levelTimeText);
    }

    private void CheckLevel42TimeAndStars()
    {
        int levelStars = gameDataManager.ReturnLevel42Stars();
        float levelTime = gameDataManager.ReturnLevel42Time();
        GameObject levelStar1 = GameObject.Find("Level42Star1");
        GameObject levelStar2 = GameObject.Find("Level42Star2");
        GameObject levelStar3 = GameObject.Find("Level42Star3");

        LevelStars(levelStar1, levelStar2, levelStar3, levelStars);
        TextMeshProUGUI levelTimeText = GameObject.Find("Level42Time").GetComponent<TextMeshProUGUI>();

        LevelTimeText(levelTime, levelTimeText);
    }

    private void CheckLevel43TimeAndStars()
    {
        int levelStars = gameDataManager.ReturnLevel43Stars();
        float levelTime = gameDataManager.ReturnLevel43Time();
        GameObject levelStar1 = GameObject.Find("Level43Star1");
        GameObject levelStar2 = GameObject.Find("Level43Star2");
        GameObject levelStar3 = GameObject.Find("Level43Star3");

        LevelStars(levelStar1, levelStar2, levelStar3, levelStars);
        TextMeshProUGUI levelTimeText = GameObject.Find("Level43Time").GetComponent<TextMeshProUGUI>();

        LevelTimeText(levelTime, levelTimeText);
    }

    private void CheckLevel44TimeAndStars()
    {
        int levelStars = gameDataManager.ReturnLevel44Stars();
        float levelTime = gameDataManager.ReturnLevel44Time();
        GameObject levelStar1 = GameObject.Find("Level44Star1");
        GameObject levelStar2 = GameObject.Find("Level44Star2");
        GameObject levelStar3 = GameObject.Find("Level44Star3");

        LevelStars(levelStar1, levelStar2, levelStar3, levelStars);
        TextMeshProUGUI levelTimeText = GameObject.Find("Level44Time").GetComponent<TextMeshProUGUI>();

        LevelTimeText(levelTime, levelTimeText);
    }

    private void CheckLevel45TimeAndStars()
    {
        int levelStars = gameDataManager.ReturnLevel45Stars();
        float levelTime = gameDataManager.ReturnLevel45Time();
        GameObject levelStar1 = GameObject.Find("Level45Star1");
        GameObject levelStar2 = GameObject.Find("Level45Star2");
        GameObject levelStar3 = GameObject.Find("Level45Star3");

        LevelStars(levelStar1, levelStar2, levelStar3, levelStars);
        TextMeshProUGUI levelTimeText = GameObject.Find("Level45Time").GetComponent<TextMeshProUGUI>();

        LevelTimeText(levelTime, levelTimeText);
    }

    private void CheckLevel46TimeAndStars()
    {
        int levelStars = gameDataManager.ReturnLevel46Stars();
        float levelTime = gameDataManager.ReturnLevel46Time();
        GameObject levelStar1 = GameObject.Find("Level46Star1");
        GameObject levelStar2 = GameObject.Find("Level46Star2");
        GameObject levelStar3 = GameObject.Find("Level46Star3");

        LevelStars(levelStar1, levelStar2, levelStar3, levelStars);
        TextMeshProUGUI levelTimeText = GameObject.Find("Level46Time").GetComponent<TextMeshProUGUI>();

        LevelTimeText(levelTime, levelTimeText);
    }

    private void CheckLevel47TimeAndStars()
    {
        int levelStars = gameDataManager.ReturnLevel47Stars();
        float levelTime = gameDataManager.ReturnLevel47Time();
        GameObject levelStar1 = GameObject.Find("Level47Star1");
        GameObject levelStar2 = GameObject.Find("Level47Star2");
        GameObject levelStar3 = GameObject.Find("Level47Star3");

        LevelStars(levelStar1, levelStar2, levelStar3, levelStars);
        TextMeshProUGUI levelTimeText = GameObject.Find("Level47Time").GetComponent<TextMeshProUGUI>();

        LevelTimeText(levelTime, levelTimeText);
    }

    private void CheckLevel48TimeAndStars()
    {
        int levelStars = gameDataManager.ReturnLevel48Stars();
        float levelTime = gameDataManager.ReturnLevel48Time();
        GameObject levelStar1 = GameObject.Find("Level48Star1");
        GameObject levelStar2 = GameObject.Find("Level48Star2");
        GameObject levelStar3 = GameObject.Find("Level48Star3");

        LevelStars(levelStar1, levelStar2, levelStar3, levelStars);
        TextMeshProUGUI levelTimeText = GameObject.Find("Level48Time").GetComponent<TextMeshProUGUI>();

        LevelTimeText(levelTime, levelTimeText);
    }

    private void CheckLevel49TimeAndStars()
    {
        int levelStars = gameDataManager.ReturnLevel49Stars();
        float levelTime = gameDataManager.ReturnLevel49Time();
        GameObject levelStar1 = GameObject.Find("Level49Star1");
        GameObject levelStar2 = GameObject.Find("Level49Star2");
        GameObject levelStar3 = GameObject.Find("Level49Star3");

        LevelStars(levelStar1, levelStar2, levelStar3, levelStars);
        TextMeshProUGUI levelTimeText = GameObject.Find("Level19Time").GetComponent<TextMeshProUGUI>();

        LevelTimeText(levelTime, levelTimeText);
    }

    private void CheckLevel50TimeAndStars()
    {
        int levelStars = gameDataManager.ReturnLevel50Stars();
        float levelTime = gameDataManager.ReturnLevel50Time();
        GameObject levelStar1 = GameObject.Find("Level50Star1");
        GameObject levelStar2 = GameObject.Find("Level50Star2");
        GameObject levelStar3 = GameObject.Find("Level50Star3");

        LevelStars(levelStar1, levelStar2, levelStar3, levelStars);
        TextMeshProUGUI levelTimeText = GameObject.Find("Level50Time").GetComponent<TextMeshProUGUI>();

        LevelTimeText(levelTime, levelTimeText);
    }

    #endregion

    public void CheckUnlockedLevels()
    {
        if (gameDataManager.Level2UnlockedCheck())
        {
            level2Button.SetActive(true);
            level2LockedButton.SetActive(false);
        }
        else
        {
           level2Button.SetActive(false);
           level2LockedButton.SetActive(true);
        }
        
        if (gameDataManager.Level3UnlockedCheck())
        {
            level3Button.SetActive(true);
            level3LockedButton.SetActive(false);
        }
        else
        {
            level3Button.SetActive(false);
            level3LockedButton.SetActive(true);
        }

        if (gameDataManager.Level4UnlockedCheck())
        {
            level4Button.SetActive(true);
            level4LockedButton.SetActive(false);
        }
        else
        {
            level4Button.SetActive(false);
            level4LockedButton.SetActive(true);
        }

        if (gameDataManager.Level5UnlockedCheck())
        {
            level5Button.SetActive(true);
            level5LockedButton.SetActive(false);
        }
        else
        {
            level5Button.SetActive(false);
            level5LockedButton.SetActive(true);
        }

        if (gameDataManager.Level6UnlockedCheck())
        {
            level6Button.SetActive(true);
            level6LockedButton.SetActive(false);
        }
        else
        {
            level6Button.SetActive(false);
            level6LockedButton.SetActive(true);
        }

        if (gameDataManager.Level7UnlockedCheck())
        {
            level7Button.SetActive(true);
            level7LockedButton.SetActive(false);
        }
        else
        {
            level7Button.SetActive(false);
            level7LockedButton.SetActive(true);
        }

        if (gameDataManager.Level8UnlockedCheck())
        {
            level8Button.SetActive(true);
            level8LockedButton.SetActive(false);
        }
        else
        {
            level8Button.SetActive(false);
            level8LockedButton.SetActive(true);
        }

        if (gameDataManager.Level9UnlockedCheck())
        {
            level9Button.SetActive(true);
            level9LockedButton.SetActive(false);
        }
        else
        {
            level9Button.SetActive(false);
            level9LockedButton.SetActive(true);
        }

        if (gameDataManager.Level10UnlockedCheck())
        {
            level10Button.SetActive(true);
            level10LockedButton.SetActive(false);
        }
        else
        {
            level10Button.SetActive(false);
            level10LockedButton.SetActive(true);
        }

        if (gameDataManager.Level11UnlockedCheck())
        {
            level11Button.SetActive(true);
            level11LockedButton.SetActive(false);
        }
        else
        {
            level11Button.SetActive(false);
            level11LockedButton.SetActive(true);
        }

        if (gameDataManager.Level12UnlockedCheck())
        {
            level12Button.SetActive(true);
            level12LockedButton.SetActive(false);
        }
        else
        {
            level12Button.SetActive(false);
            level12LockedButton.SetActive(true);
        }
        if (gameDataManager.Level13UnlockedCheck())
        {
            level13Button.SetActive(true);
            level13LockedButton.SetActive(false);
        }
        else
        {
            level13Button.SetActive(false);
            level13LockedButton.SetActive(true);
        }

        if (gameDataManager.Level14UnlockedCheck())
        {
            level14Button.SetActive(true);
            level14LockedButton.SetActive(false);
        }
        else
        {
            level14Button.SetActive(false);
            level14LockedButton.SetActive(true);
        }

        if (gameDataManager.Level15UnlockedCheck())
        {
            level15Button.SetActive(true);
            level15LockedButton.SetActive(false);
        }
        else
        {
            level15Button.SetActive(false);
            level15LockedButton.SetActive(true);
        }

        if (gameDataManager.Level16UnlockedCheck())
        {
            level16Button.SetActive(true);
            level16LockedButton.SetActive(false);
        }
        else
        {
            level16Button.SetActive(false);
            level16LockedButton.SetActive(true);
        }

        if (gameDataManager.Level17UnlockedCheck())
        {
            level17Button.SetActive(true);
            level17LockedButton.SetActive(false);
        }
        else
        {
            level17Button.SetActive(false);
            level17LockedButton.SetActive(true);
        }

        if (gameDataManager.Level18UnlockedCheck())
        {
            level18Button.SetActive(true);
            level18LockedButton.SetActive(false);
        }
        else
        {
            level18Button.SetActive(false);
            level18LockedButton.SetActive(true);
        }

        if (gameDataManager.Level19UnlockedCheck())
        {
            level19Button.SetActive(true);
            level19LockedButton.SetActive(false);
        }
        else
        {
            level19Button.SetActive(false);
            level19LockedButton.SetActive(true);
        }

        if (gameDataManager.Level20UnlockedCheck())
        {
            level20Button.SetActive(true);
            level20LockedButton.SetActive(false);
        }
        else
        {
            level20Button.SetActive(false);
            level20LockedButton.SetActive(true);
        }

        if (gameDataManager.Level21UnlockedCheck())
        {
            level21Button.SetActive(true);
            level21LockedButton.SetActive(false);
        }
        else
        {
            level21Button.SetActive(false);
            level21LockedButton.SetActive(true);
        }

        if (gameDataManager.Level22UnlockedCheck())
        {
            level22Button.SetActive(true);
            level22LockedButton.SetActive(false);
        }
        else
        {
            level22Button.SetActive(false);
            level22LockedButton.SetActive(true);
        }

        if (gameDataManager.Level23UnlockedCheck())
        {
            level23Button.SetActive(true);
            level23LockedButton.SetActive(false);
        }
        else
        {
            level23Button.SetActive(false);
            level23LockedButton.SetActive(true);
        }

        if (gameDataManager.Level24UnlockedCheck())
        {
            level24Button.SetActive(true);
            level24LockedButton.SetActive(false);
        }
        else
        {
            level24Button.SetActive(false);
            level24LockedButton.SetActive(true);
        }

        if (gameDataManager.Level25UnlockedCheck())
        {
            level25Button.SetActive(true);
            level25LockedButton.SetActive(false);
        }
        else
        {
            level25Button.SetActive(false);
            level25LockedButton.SetActive(true);
        }

        if (gameDataManager.Level26UnlockedCheck())
        {
            level26Button.SetActive(true);
            level26LockedButton.SetActive(false);
        }
        else
        {
            level26Button.SetActive(false);
            level26LockedButton.SetActive(true);
        }

        if (gameDataManager.Level27UnlockedCheck())
        {
            level27Button.SetActive(true);
            level27LockedButton.SetActive(false);
        }
        else
        {
            level27Button.SetActive(false);
            level27LockedButton.SetActive(true);
        }

        if (gameDataManager.Level28UnlockedCheck())
        {
            level28Button.SetActive(true);
            level28LockedButton.SetActive(false);
        }
        else
        {
            level28Button.SetActive(false);
            level28LockedButton.SetActive(true);
        }

        if (gameDataManager.Level29UnlockedCheck())
        {
            level29Button.SetActive(true);
            level29LockedButton.SetActive(false);
        }
        else
        {
            level29Button.SetActive(false);
            level29LockedButton.SetActive(true);
        }

        if (gameDataManager.Level30UnlockedCheck())
        {
            level30Button.SetActive(true);
            level30LockedButton.SetActive(false);
        }
        else
        {
            level30Button.SetActive(false);
            level30LockedButton.SetActive(true);
        }

        if (gameDataManager.Level31UnlockedCheck())
        {
            level31Button.SetActive(true);
            level31LockedButton.SetActive(false);
        }
        else
        {
            level31Button.SetActive(false);
            level31LockedButton.SetActive(true);
        }

        if (gameDataManager.Level32UnlockedCheck())
        {
            level32Button.SetActive(true);
            level32LockedButton.SetActive(false);
        }
        else
        {
            level32Button.SetActive(false);
            level32LockedButton.SetActive(true);
        }

        if (gameDataManager.Level33UnlockedCheck())
        {
            level33Button.SetActive(true);
            level33LockedButton.SetActive(false);
        }
        else
        {
            level33Button.SetActive(false);
            level33LockedButton.SetActive(true);
        }

        if (gameDataManager.Level34UnlockedCheck())
        {
            level34Button.SetActive(true);
            level34LockedButton.SetActive(false);
        }
        else
        {
            level34Button.SetActive(false);
            level34LockedButton.SetActive(true);
        }

        if (gameDataManager.Level35UnlockedCheck())
        {
            level35Button.SetActive(true);
            level35LockedButton.SetActive(false);
        }
        else
        {
            level35Button.SetActive(false);
            level35LockedButton.SetActive(true);
        }

        if (gameDataManager.Level36UnlockedCheck())
        {
            level36Button.SetActive(true);
            level36LockedButton.SetActive(false);
        }
        else
        {
            level36Button.SetActive(false);
            level36LockedButton.SetActive(true);
        }

        if (gameDataManager.Level37UnlockedCheck())
        {
            level37Button.SetActive(true);
            level37LockedButton.SetActive(false);
        }
        else
        {
            level37Button.SetActive(false);
            level37LockedButton.SetActive(true);
        }

        if (gameDataManager.Level38UnlockedCheck())
        {
            level38Button.SetActive(true);
            level38LockedButton.SetActive(false);
        }
        else
        {
            level38Button.SetActive(false);
            level38LockedButton.SetActive(true);
        }

        if (gameDataManager.Level39UnlockedCheck())
        {
            level39Button.SetActive(true);
            level39LockedButton.SetActive(false);
        }
        else
        {
            level39Button.SetActive(false);
            level39LockedButton.SetActive(true);
        }

        if (gameDataManager.Level40UnlockedCheck())
        {
            level40Button.SetActive(true);
            level40LockedButton.SetActive(false);
        }
        else
        {
            level40Button.SetActive(false);
            level40LockedButton.SetActive(true);
        }

        if (gameDataManager.Level41UnlockedCheck())
        {
            level41Button.SetActive(true);
            level41LockedButton.SetActive(false);
        }
        else
        {
            level41Button.SetActive(false);
            level41LockedButton.SetActive(true);
        }

        if (gameDataManager.Level42UnlockedCheck())
        {
            level42Button.SetActive(true);
            level42LockedButton.SetActive(false);
        }
        else
        {
            level42Button.SetActive(false);
            level42LockedButton.SetActive(true);
        }

        if (gameDataManager.Level43UnlockedCheck())
        {
            level43Button.SetActive(true);
            level43LockedButton.SetActive(false);
        }
        else
        {
            level43Button.SetActive(false);
            level43LockedButton.SetActive(true);
        }

        if (gameDataManager.Level44UnlockedCheck())
        {
            level44Button.SetActive(true);
            level44LockedButton.SetActive(false);
        }
        else
        {
            level44Button.SetActive(false);
            level44LockedButton.SetActive(true);
        }

        if (gameDataManager.Level45UnlockedCheck())
        {
            level45Button.SetActive(true);
            level45LockedButton.SetActive(false);
        }
        else
        {
            level45Button.SetActive(false);
            level45LockedButton.SetActive(true);
        }

        if (gameDataManager.Level46UnlockedCheck())
        {
            level46Button.SetActive(true);
            level46LockedButton.SetActive(false);
        }
        else
        {
            level46Button.SetActive(false);
            level46LockedButton.SetActive(true);
        }

        if (gameDataManager.Level47UnlockedCheck())
        {
            level47Button.SetActive(true);
            level47LockedButton.SetActive(false);
        }
        else
        {
            level47Button.SetActive(false);
            level47LockedButton.SetActive(true);
        }

        if (gameDataManager.Level48UnlockedCheck())
        {
            level48Button.SetActive(true);
            level48LockedButton.SetActive(false);
        }
        else
        {
            level48Button.SetActive(false);
            level48LockedButton.SetActive(true);
        }

        if (gameDataManager.Level49UnlockedCheck())
        {
            level49Button.SetActive(true);
            level49LockedButton.SetActive(false);
        }
        else
        {
            level49Button.SetActive(false);
            level49LockedButton.SetActive(true);
        }

        if (gameDataManager.Level50UnlockedCheck())
        {
            level50Button.SetActive(true);
            level50LockedButton.SetActive(false);
        }
        else
        {
            level50Button.SetActive(false);
            level50LockedButton.SetActive(true);
        }
    }

    #region Click Levels
    public void ClickLevel1()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickLevelSFX;
        audio.Play();
        StartCoroutine(LoadAsynchronously("Level1"));
    }
    public void ClickLevel2()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickLevelSFX;
        audio.Play();
        StartCoroutine(LoadAsynchronously("Level2"));
    }
    public void ClickLevel3()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickLevelSFX;
        audio.Play();
        StartCoroutine(LoadAsynchronously("Level3"));
    }
    public void ClickLevel4()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickLevelSFX;
        audio.Play();
        StartCoroutine(LoadAsynchronously("Level4"));
    }

    public void ClickLevel5()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickLevelSFX;
        audio.Play();
        StartCoroutine(LoadAsynchronously("Level5"));
    }

    public void ClickLevel6()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickLevelSFX;
        audio.Play();
        StartCoroutine(LoadAsynchronously("Level6"));
    }

    public void ClickLevel7()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickLevelSFX;
        audio.Play();
        StartCoroutine(LoadAsynchronously("Level7"));
    }
    public void ClickLevel8()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickLevelSFX;
        audio.Play();
        StartCoroutine(LoadAsynchronously("Level8"));
    }
    public void ClickLevel9()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickLevelSFX;
        audio.Play();
        StartCoroutine(LoadAsynchronously("Level9"));
    }
    public void ClickLevel10()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickLevelSFX;
        audio.Play();
        StartCoroutine(LoadAsynchronously("Level10"));
    }

    public void ClickLevel11()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickLevelSFX;
        audio.Play();
        StartCoroutine(LoadAsynchronously("Level11"));
    }

    public void ClickLevel12()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickLevelSFX;
        audio.Play();
        StartCoroutine(LoadAsynchronously("Level12"));
    }

    public void ClickLevel13()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickLevelSFX;
        audio.Play();
        StartCoroutine(LoadAsynchronously("Level13"));
    }

    public void ClickLevel14()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickLevelSFX;
        audio.Play();
        StartCoroutine(LoadAsynchronously("Level14"));
    }

    public void ClickLevel15()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickLevelSFX;
        audio.Play();
        StartCoroutine(LoadAsynchronously("Level15"));
    }

    public void ClickLevel16()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickLevelSFX;
        audio.Play();
        StartCoroutine(LoadAsynchronously("Level16"));
    }

    public void ClickLevel17()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickLevelSFX;
        audio.Play();
        StartCoroutine(LoadAsynchronously("Level17"));
    }

    public void ClickLevel18()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickLevelSFX;
        audio.Play();
        StartCoroutine(LoadAsynchronously("Level18"));
    }

    public void ClickLevel19()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickLevelSFX;
        audio.Play();
        StartCoroutine(LoadAsynchronously("Level19"));
    }


    public void ClickLevel20()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickLevelSFX;
        audio.Play();
        StartCoroutine(LoadAsynchronously("Level20"));
    }


    public void ClickLevel21()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickLevelSFX;
        audio.Play();
        StartCoroutine(LoadAsynchronously("Level21"));
    }

    public void ClickLevel22()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickLevelSFX;
        audio.Play();
        StartCoroutine(LoadAsynchronously("Level22"));
    }

    public void ClickLevel23()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickLevelSFX;
        audio.Play();
        StartCoroutine(LoadAsynchronously("Level23"));
    }

    public void ClickLevel24()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickLevelSFX;
        audio.Play();
        StartCoroutine(LoadAsynchronously("Level24"));
    }
    public void ClickLevel25()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickLevelSFX;
        audio.Play();
        StartCoroutine(LoadAsynchronously("Level25"));
    }
    public void ClickLevel26()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickLevelSFX;
        audio.Play();
        StartCoroutine(LoadAsynchronously("Level26"));
    }

    public void ClickLevel27()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickLevelSFX;
        audio.Play();
        StartCoroutine(LoadAsynchronously("Level27"));
    }
    public void ClickLevel28()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickLevelSFX;
        audio.Play();
        StartCoroutine(LoadAsynchronously("Level28"));
    }
    public void ClickLevel29()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickLevelSFX;
        audio.Play();
        StartCoroutine(LoadAsynchronously("Level29"));
    }
    public void ClickLevel30()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickLevelSFX;
        audio.Play();
        StartCoroutine(LoadAsynchronously("Level30"));
    }
    public void ClickLevel31()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickLevelSFX;
        audio.Play();
        StartCoroutine(LoadAsynchronously("Level31"));
    }
    public void ClickLevel32()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickLevelSFX;
        audio.Play();
        StartCoroutine(LoadAsynchronously("Level32"));
    }
    public void ClickLevel33()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickLevelSFX;
        audio.Play();
        StartCoroutine(LoadAsynchronously("Level33"));
    }
    public void ClickLevel34()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickLevelSFX;
        audio.Play();
        StartCoroutine(LoadAsynchronously("Level34"));
    }
    public void ClickLevel35()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickLevelSFX;
        audio.Play();
        StartCoroutine(LoadAsynchronously("Level35"));
    }
    public void ClickLevel36()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickLevelSFX;
        audio.Play();
        StartCoroutine(LoadAsynchronously("Level36"));
    }
    public void ClickLevel37()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickLevelSFX;
        audio.Play();
        StartCoroutine(LoadAsynchronously("Level37"));
    }
    public void ClickLevel38()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickLevelSFX;
        audio.Play();
        StartCoroutine(LoadAsynchronously("Level38"));
    }
    public void ClickLevel39()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickLevelSFX;
        audio.Play();
        StartCoroutine(LoadAsynchronously("Level39"));
    }
    public void ClickLevel40()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickLevelSFX;
        audio.Play();
        StartCoroutine(LoadAsynchronously("Level40"));
    }
    public void ClickLevel41()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickLevelSFX;
        audio.Play();
        StartCoroutine(LoadAsynchronously("Level41"));
    }
    public void ClickLevel42()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickLevelSFX;
        audio.Play();
        StartCoroutine(LoadAsynchronously("Level42"));
    }
    public void ClickLevel43()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickLevelSFX;
        audio.Play();
        StartCoroutine(LoadAsynchronously("Level43"));
    }
    public void ClickLevel44()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickLevelSFX;
        audio.Play();
        StartCoroutine(LoadAsynchronously("Level44"));
    }
    public void ClickLevel45()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickLevelSFX;
        audio.Play();
        StartCoroutine(LoadAsynchronously("Level45"));
    }
    public void ClickLevel46()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickLevelSFX;
        audio.Play();
        StartCoroutine(LoadAsynchronously("Level46"));
    }
    public void ClickLevel47()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickLevelSFX;
        audio.Play();
        StartCoroutine(LoadAsynchronously("Level47"));
    }
    public void ClickLevel48()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickLevelSFX;
        audio.Play();
        StartCoroutine(LoadAsynchronously("Level48"));
    }
    public void ClickLevel49()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickLevelSFX;
        audio.Play();
        StartCoroutine(LoadAsynchronously("Level49"));
    }
    public void ClickLevel50()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = clickLevelSFX;
        audio.Play();
        StartCoroutine(LoadAsynchronously("Level50"));
    }

    #endregion
}
