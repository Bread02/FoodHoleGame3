using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    void Update()
    {
        
    }
}
