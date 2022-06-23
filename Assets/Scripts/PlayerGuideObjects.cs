using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGuideObjects : MonoBehaviour
{
    public WinTriggerMaster winTriggerMaster;
    public bool endTriggered;

    // Start is called before the first frame update
    void Awake()
    {
        endTriggered = false;
        winTriggerMaster = GameObject.Find("WinTrigger").GetComponent<WinTriggerMaster>();
        winTriggerMaster.playerObjects.Add(this.gameObject);
    }
}
