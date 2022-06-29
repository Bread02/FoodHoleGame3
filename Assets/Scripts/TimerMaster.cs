using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerMaster : MonoBehaviour
{
    public float timer;
    public float timerSimplified;
    public float endTime;

    public bool completeCheck;

    public WinTriggerMaster winTriggerMaster;

    public TextMeshProUGUI timerText;

    public TextMeshProUGUI winScreenTimeComplete;
    // Start is called before the first frame update
    void Start()
    {
        winTriggerMaster = GameObject.Find("WinTrigger").GetComponent<WinTriggerMaster>();
        completeCheck = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.timeSinceLevelLoad;
        timerSimplified = Mathf.Round(timer * 100f) / 100f;

        timerText.text = timerSimplified.ToString();

        WinCheck();
    }

    private void WinCheck()
    {
        if (winTriggerMaster.levelComplete == true && completeCheck == false)
        {
            completeCheck = true;
            endTime = timerSimplified;
            Debug.Log("Timer master script");
            winTriggerMaster.CheckTimeScoreLevel1(endTime);
            winScreenTimeComplete.text = "Time: " + endTime.ToString();
        }
    }

    public float ReturnTime()
    {
        return endTime;
    }
}
