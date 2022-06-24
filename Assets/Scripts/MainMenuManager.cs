using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuManager : LoadingMaster
{
    // Start is called before the first frame update

    public GameObject mainMainCanvas;
    public GameObject levelSelectCanvas;

    void Start()
    {
        mainMainCanvas.SetActive(true);
        levelSelectCanvas.SetActive(false);
    }

    public void ClickPlay()
    {
        mainMainCanvas.SetActive(false);
        levelSelectCanvas.SetActive(true);
    }

    // Update is called once per frame
    public void ClickLevel1()
    {
        StartCoroutine(LoadAsynchronously("LevelOne"));
    }
    public void ClickLevel2()
    {
        StartCoroutine(LoadAsynchronously("LevelTwo"));
    }
    public void ClickLevel3()
    {
        StartCoroutine(LoadAsynchronously("LevelThree"));
    }
    public void ClickLevel4()
    {
        StartCoroutine(LoadAsynchronously("LevelFour"));
    }

    public void ClickLevel5()
    {
        StartCoroutine(LoadAsynchronously("LevelFive"));
    }

    public void ClickLevel6()
    {
        StartCoroutine(LoadAsynchronously("LevelSix"));
    }

    public void ClickLevel7()
    {
        StartCoroutine(LoadAsynchronously("LevelSeven"));
    }
    public void ClickLevel8()
    {
        StartCoroutine(LoadAsynchronously("LevelEight"));
    }
    public void ClickLevel9()
    {
        StartCoroutine(LoadAsynchronously("LevelNine"));
    }
    public void ClickLevel10()
    {
        StartCoroutine(LoadAsynchronously("LevelTen"));
    }

    public void ClickLevel11()
    {
        StartCoroutine(LoadAsynchronously("LevelTen"));
    }

    public void ClickLevel12()
    {
        StartCoroutine(LoadAsynchronously("LevelTen"));
    }

    public void ClickLevel13()
    {
        StartCoroutine(LoadAsynchronously("LevelTen"));
    }

}
