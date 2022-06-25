using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WinTriggerMaster : MonoBehaviour
{
    private GameDataManager gameDataManager;

    public List<GameObject> playerObjects = new List<GameObject>();

    private GameObject winCanvas;

    private TextMeshProUGUI itemsRemaining;

    [Header("Ints")]
    private int itemsRemainingInt;
    private int totalItemsInt;
    private int objectsTriggered;


    // Start is called before the first frame update
    void Start()
    {
        gameDataManager = GameObject.Find("GameDataManager").GetComponent<GameDataManager>();
        winCanvas = GameObject.Find("WinCanvas");
        itemsRemaining = GameObject.Find("ItemsRemainingText").GetComponent<TextMeshProUGUI>();
        winCanvas.SetActive(false);
        totalItemsInt = playerObjects.Count;
        ItemsRemaining();
    }

    public void CheckWinCondition()
    {
        if (objectsTriggered == totalItemsInt)
        {
            Invoke("WinTrigger", 0f);
        }
    }

    public void WinTrigger()
    {
        winCanvas.SetActive(true);
        Debug.Log("Win condition achieved");
        Time.timeScale = 0;

        Scene scene = SceneManager.GetActiveScene();
        switch (scene.name)
        {
            case "Level1":
                gameDataManager.UnlockLevel2();
                Debug.Log("Unlocking level 2");
                break;
            case "Level2":
                gameDataManager.UnlockLevel3();
                break;
            case "Level3":
                gameDataManager.UnlockLevel4();
                break;
            case "Level4":
                gameDataManager.UnlockLevel5();
                break;
            case "Level5":
                gameDataManager.UnlockLevel6();
                break;
            case "Level6":
                gameDataManager.UnlockLevel7();
                break;
            case "Level7":
                gameDataManager.UnlockLevel8();
                break;
            case "Level8":
                gameDataManager.UnlockLevel9();
                break;
            case "Level9":
                gameDataManager.UnlockLevel10();
                break;
            case "Level10":
                gameDataManager.UnlockLevel11();
                break;
            case "Level11":
                gameDataManager.UnlockLevel12();
                break;
            case "Level12":
                gameDataManager.UnlockLevel13();
                break;
            case "Level13":
                gameDataManager.UnlockLevel14();
                break;
            case "Level14":
                gameDataManager.UnlockLevel15();
                break;
            case "Level15":
                gameDataManager.UnlockLevel16();
                break;
            case "Level16":
                gameDataManager.UnlockLevel17();
                break;
            case "Level17":
                gameDataManager.UnlockLevel18();
                break;
            case "Level18":
                gameDataManager.UnlockLevel19();
                break;
            case "Level19":
                gameDataManager.UnlockLevel20();
                break;
                
        }
    }

    public void ItemsRemaining()
    {
        itemsRemainingInt = totalItemsInt - objectsTriggered;
        itemsRemaining.text = itemsRemainingInt.ToString() + " / " + totalItemsInt.ToString() + " Items Remaining";
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach (GameObject obj in playerObjects)
        {
            if (other.gameObject == obj)
            {
                if (obj?.GetComponent<PlayerGuideObjects>().endTriggered == false)
                {
                    Debug.Log("Player object fell through hole");
                    objectsTriggered++;
                    obj.GetComponent<PlayerGuideObjects>().endTriggered = true;
                    Debug.Log(objectsTriggered);
                    Invoke("CheckWinCondition", 1f);
                    ItemsRemaining();
                }
            }
        }
    }
}
