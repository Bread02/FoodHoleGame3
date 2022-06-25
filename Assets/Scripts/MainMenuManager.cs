using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenuManager : LoadingMaster
{
    // Start is called before the first frame update

    public GameObject mainMainCanvas;

    [Header("Level Canvases")]
    public GameObject levelSelectCanvas1;
    public GameObject levelSelectCanvas2;
    public GameObject levelSelectCanvas3;
    public GameObject levelSelectCanvas4;

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
        gameDataManager = GameObject.Find("GameDataManager").GetComponent<GameDataManager>();
        mainMainCanvas.SetActive(true);
        HideAllLevelSelectCanvas();
    }

    public void ClickPlay()
    {
        mainMainCanvas.SetActive(false);
        levelSelectCanvas1.SetActive(true);
        CheckUnlockedLevels();
    }

    public void HideAllLevelSelectCanvas()
    {
        levelSelectCanvas1.SetActive(false);
        levelSelectCanvas2.SetActive(false);
        levelSelectCanvas3.SetActive(false);
        levelSelectCanvas4.SetActive(false);
    }

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

    // Update is called once per frame
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

}
