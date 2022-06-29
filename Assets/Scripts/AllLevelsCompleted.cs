using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllLevelsCompleted : LoadingMaster
{

    public void MainMenuClick()
    {
        StartCoroutine(LoadAsynchronously("MainMenu"));
    }

}
