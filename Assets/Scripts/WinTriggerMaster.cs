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
            case "Level 1":
                gameDataManager.UnlockLevel2();
                break;
            case "Level 2":
                gameDataManager.UnlockLevel3();
                break;
            case "Level 3":
                gameDataManager.UnlockLevel4();
                break;
            case "Level 4":
                gameDataManager.UnlockLevel5();
                break;
            case "Level 5":
                gameDataManager.UnlockLevel6();
                break;
            case "Level 6":
                gameDataManager.UnlockLevel7();
                break;
            case "Level 7":
                gameDataManager.UnlockLevel8();
                break;
            case "Level 8":
                gameDataManager.UnlockLevel9();
                break;
            case "Level 9":
                gameDataManager.UnlockLevel10();
                break;
            case "Level 10":
                gameDataManager.UnlockLevel11();
                break;
            case "Level 11":
                gameDataManager.UnlockLevel12();
                break;
            case "Level 12":
                gameDataManager.UnlockLevel13();
                break;
            case "Level 13":
                gameDataManager.UnlockLevel14();
                break;
            case "Level 14":
                gameDataManager.UnlockLevel15();
                break;
            case "Level 15":
                gameDataManager.UnlockLevel16();
                break;
            case "Level 16":
                gameDataManager.UnlockLevel17();
                break;
            case "Level 17":
                gameDataManager.UnlockLevel18();
                break;
            case "Level 18":
                gameDataManager.UnlockLevel19();
                break;
            case "Level 19":
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
