using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseTriggerMaster : MonoBehaviour
{
    private WinTriggerMaster winTriggerMaster;
    public List<GameObject> playerObjects = new List<GameObject>();
    private GameObject loseCanvas;

    [Header("SFX")]
    [SerializeField] private AudioClip loseSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        loseCanvas = GameObject.Find("LossCanvas");
        loseCanvas.SetActive(false);
        winTriggerMaster = GameObject.Find("WinTrigger").GetComponent<WinTriggerMaster>();
        playerObjects = winTriggerMaster.playerObjects;
    }

    public void LossTrigger()
    {
        loseCanvas.SetActive(true);
        Time.timeScale = 0;
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = loseSoundEffect;
        audio.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach (GameObject obj in playerObjects)
        {
            if (other.gameObject == obj)
            {
                if (obj?.GetComponent<PlayerGuideObjects>().endTriggered == false)
                {
                    LossTrigger();
                }
            }
        }
    }
}
