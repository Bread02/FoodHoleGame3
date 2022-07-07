using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapButtonMaster : MonoBehaviour
{
    private WinTriggerMaster winTriggerMaster;

    public bool buttonTriggered;

    private MovingWall movingWall;

    public Material activatedMaterial;

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
                    this.gameObject.GetComponent<Renderer>().material = activatedMaterial;
                }
            }
        }
    }
}
