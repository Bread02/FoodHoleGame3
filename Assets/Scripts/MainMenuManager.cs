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

    public GameDataManager gameDataManager;

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


    void Start()
    {
        FindButtons();
        gameDataManager = GameObject.Find("GameDataManager").GetComponent<GameDataManager>();
        mainMainCanvas.SetActive(true);
        HideAllLevelSelectCanvas();
        gameDataManager.ReadGame();
        Debug.Log(gameDataManager.ReturnLevel1Time());
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


    }

    public void ClickPlay()
    {
        mainMainCanvas.SetActive(false);
        levelSelectCanvas1.SetActive(true);
        CheckUnlockedLevels();
        CheckLevel1TimeAndStars();
    }

    public void HideAllLevelSelectCanvas()
    {
        levelSelectCanvas1.SetActive(false);
        levelSelectCanvas2.SetActive(false);
        levelSelectCanvas3.SetActive(false);
        levelSelectCanvas4.SetActive(false);
        levelSelectCanvas5.SetActive(false);
        levelSelectCanvas6.SetActive(false);
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
        if (levelTime != 111111)
        {
            levelTimeText.text = "Time Record: " + levelTime.ToString() + "s";
        }
        else
        {
            levelTimeText.text = "Level Not Completed";
        }
    }

    #region Check Level Time and Stars
    public void CheckLevel1TimeAndStars()
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

    public void CheckLevel2TimeAndStars()
    {
        int level2Stars = gameDataManager.ReturnLevel2Stars();
        float level2Time = gameDataManager.ReturnLevel2Time();
        GameObject level2Star1 = GameObject.Find("Level2Star1");
        GameObject level2Star2 = GameObject.Find("Level2Star2");
        GameObject level2Star3 = GameObject.Find("Level2Star3");

        LevelStars(level2Star1, level2Star2, level2Star3, level2Stars);
        TextMeshProUGUI level2TimeText = GameObject.Find("Level2Time").GetComponent<TextMeshProUGUI>();

        LevelTimeText(level2Time, level2TimeText);
    }
    public void CheckLevel3TimeAndStars()
    {
        int level3Stars = gameDataManager.ReturnLevel3Stars();
        float level3Time = gameDataManager.ReturnLevel3Time();
        GameObject level3Star1 = GameObject.Find("Level3Star1");
        GameObject level3Star2 = GameObject.Find("Level3Star2");
        GameObject level3Star3 = GameObject.Find("Level3Star3");

        LevelStars(level3Star1, level3Star2, level3Star3, level3Stars);
        TextMeshProUGUI level3TimeText = GameObject.Find("Level2Time").GetComponent<TextMeshProUGUI>();

        LevelTimeText(level3Time, level3TimeText);
    }

    public void CheckLevel4TimeAndStars()
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

    public void CheckLevel5TimeAndStars()
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

    public void CheckLevel6TimeAndStars()
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

    public void CheckLevel7TimeAndStars()
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

    public void CheckLevel8TimeAndStars()
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

    public void CheckLevel9TimeAndStars()
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

    public void CheckLevel10TimeAndStars()
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

    public void CheckLevel11TimeAndStars()
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

    public void CheckLevel12TimeAndStars()
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

    public void CheckLevel13TimeAndStars()
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

    public void CheckLevel14TimeAndStars()
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

    public void CheckLevel15TimeAndStars()
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

    public void CheckLevel16TimeAndStars()
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

    public void CheckLevel17TimeAndStars()
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

    public void CheckLevel18TimeAndStars()
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

    public void CheckLevel19TimeAndStars()
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

    public void CheckLevel20TimeAndStars()
    {
        int levelStars = gameDataManager.ReturnLevel20Stars();
        float levelTime = gameDataManager.ReturnLevel20Time();
        GameObject levelStar1 = GameObject.Find("Level20Star1");
        GameObject levelStar2 = GameObject.Find("Level20Star2");
        GameObject levelStar3 = GameObject.Find("Level20Star3");

        LevelStars(levelStar1, levelStar2, levelStar3, levelStars);
        TextMeshProUGUI levelTimeText = GameObject.Find("Level20Time").GetComponent<TextMeshProUGUI>();

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
    }

    #region Click Levels
    public void ClickLevel1()
    {
        StartCoroutine(LoadAsynchronously("Level1"));
    }
    public void ClickLevel2()
    {
        StartCoroutine(LoadAsynchronously("Level2"));
    }
    public void ClickLevel3()
    {
        StartCoroutine(LoadAsynchronously("Level3"));
    }
    public void ClickLevel4()
    {
        StartCoroutine(LoadAsynchronously("Level4"));
    }

    public void ClickLevel5()
    {
        StartCoroutine(LoadAsynchronously("Level5"));
    }

    public void ClickLevel6()
    {
        StartCoroutine(LoadAsynchronously("Level6"));
    }

    public void ClickLevel7()
    {
        StartCoroutine(LoadAsynchronously("Level7"));
    }
    public void ClickLevel8()
    {
        StartCoroutine(LoadAsynchronously("Level8"));
    }
    public void ClickLevel9()
    {
        StartCoroutine(LoadAsynchronously("Level9"));
    }
    public void ClickLevel10()
    {
        StartCoroutine(LoadAsynchronously("Level10"));
    }

    public void ClickLevel11()
    {
        StartCoroutine(LoadAsynchronously("Level11"));
    }

    public void ClickLevel12()
    {
        StartCoroutine(LoadAsynchronously("Level12"));
    }

    public void ClickLevel13()
    {
        StartCoroutine(LoadAsynchronously("Level13"));
    }

    public void ClickLevel14()
    {
        StartCoroutine(LoadAsynchronously("Level14"));
    }

    public void ClickLevel15()
    {
        StartCoroutine(LoadAsynchronously("Level15"));
    }

    public void ClickLevel16()
    {
        StartCoroutine(LoadAsynchronously("Level16"));
    }

    public void ClickLevel17()
    {
        StartCoroutine(LoadAsynchronously("Level17"));
    }

    public void ClickLevel18()
    {
        StartCoroutine(LoadAsynchronously("Level18"));
    }

    public void ClickLevel19()
    {
        StartCoroutine(LoadAsynchronously("Level19"));
    }

    public void ClickLevel20()
    {
        StartCoroutine(LoadAsynchronously("Level20"));
    }
    #endregion
}
