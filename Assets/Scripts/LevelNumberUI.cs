using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelNumberUI : MonoBehaviour
{
    public TextMeshProUGUI levelNumber;

    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        switch (scene.name)
        {
            case "Level1":
                levelNumber.text = "Level 1";
                break;
            case "Level2":
                levelNumber.text = "Level 2";
                break;
            case "Level3":
                levelNumber.text = "Level 3";
                break;
            case "Level4":
                levelNumber.text = "Level 4";
                break;
            case "Level5":
                levelNumber.text = "Level 5";
                break;
            case "Level6":
                levelNumber.text = "Level 6";
                break;
            case "Level7":
                levelNumber.text = "Level 7";
                break;
            case "Level8":
                levelNumber.text = "Level 8";
                break;
            case "Level9":
                levelNumber.text = "Level 9";
                break;
            case "Level10":
                levelNumber.text = "Level 10";
                break;
            case "Level11":
                levelNumber.text = "Level 11";
                break;
            case "Level12":
                levelNumber.text = "Level 12";
                break;
            case "Level13":
                levelNumber.text = "Level 13";
                break;
            case "Level14":
                levelNumber.text = "Level 14";
                break;
            case "Level15":
                levelNumber.text = "Level 15";
                break;
            case "Level16":
                levelNumber.text = "Level 16";
                break;
            case "Level17":
                levelNumber.text = "Level 17";
                break;
            case "Level18":
                levelNumber.text = "Level 18";
                break;
            case "Level19":
                levelNumber.text = "Level 19";
                break;
            case "Level20":
                levelNumber.text = "Level 20";
                break;
            default:
                levelNumber.text = "RAN OUT OF LEVELS TO DISPLAY";
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
