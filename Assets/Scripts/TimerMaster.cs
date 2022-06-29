using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerMaster : MonoBehaviour
{
    public float timer;
    public float timerSimplified;

    public WinTriggerMaster winTriggerMaster;

    public TextMeshProUGUI timerText;
    // Start is called before the first frame update
    void Start()
    {
        winTriggerMaster = GameObject.Find("WinTrigger").GetComponent<WinTriggerMaster>();
    }

    public void LevelOneCompleteTimer()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.timeSinceLevelLoad;
        timerSimplified = Mathf.Round(timer * 100f) / 100f;

        timerText.text = timerSimplified.ToString();
        Debug.Log(timer);
    }
}
