using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerMaster : MonoBehaviour
{
    public float timer;
    public float timerSimplified;

    public bool completeCheck;

    public WinTriggerMaster winTriggerMaster;

    private TextMeshProUGUI timerText;

    public TextMeshProUGUI winScreenTimeComplete;

    public bool timeTriggerCheck;
    // Start is called before the first frame update
    void Start()
    {
        timeTriggerCheck = false;
        winTriggerMaster = GameObject.Find("WinTrigger").GetComponent<WinTriggerMaster>();
        timerText = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();
        completeCheck = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!timeTriggerCheck)
        {
            timer = Time.timeSinceLevelLoad;
            timerSimplified = Mathf.Round(timer * 100f) / 100f;

            timerText.text = timerSimplified.ToString();
        }
        WinCheck();
    }

    private void WinCheck()
    {
        if (winTriggerMaster.levelComplete == true && completeCheck == false)
        {
            completeCheck = true;
            winScreenTimeComplete.text = "Time: " + timerSimplified.ToString();
        }
    }

    public float ReturnTime()
    {
        return timerSimplified;
    }
}
