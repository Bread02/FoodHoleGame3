using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapButtonMaster : MonoBehaviour
{
    public GameObject itemToTrigger;
    private WinTriggerMaster winTriggerMaster;

    public bool buttonTriggered;

    public MovingWall movingWall;

    [Header("Lists")]
    public List<GameObject> playerObjects = new List<GameObject>();

    public void Start()
    {
        buttonTriggered = false;
        winTriggerMaster = GameObject.Find("WinTrigger").GetComponent<WinTriggerMaster>();
        playerObjects = winTriggerMaster.playerObjects;
        movingWall = GameObject.Find("MovingWall").GetComponent<MovingWall>();
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach (GameObject obj in playerObjects)
        {
            if (other.gameObject == obj)
            {
                if (obj?.GetComponent<PlayerGuideObjects>().endTriggered == false)
                {
                    Debug.Log("Button Triggered");
                    buttonTriggered = true;
                    movingWall.triggered = true;
                }
            }
        }
    }
}
