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
            case "Level21":
                levelNumber.text = "Level 21";
                break;
            case "Level22":
                levelNumber.text = "Level 22";
                break;
            case "Level23":
                levelNumber.text = "Level 23";
                break;
            case "Level24":
                levelNumber.text = "Level 24";
                break;
            case "Level25":
                levelNumber.text = "Level 25";
                break;
            case "Level26":
                levelNumber.text = "Level 26";
                break;
            case "Level27":
                levelNumber.text = "Level 27";
                break;
            case "Level28":
                levelNumber.text = "Level 28";
                break;
            case "Level29":
                levelNumber.text = "Level 29";
                break;
            case "Level30":
                levelNumber.text = "Level 30";
                break;
            case "Level31":
                levelNumber.text = "Level 31";
                break;
            case "Level32":
                levelNumber.text = "Level 32";
                break;
            case "Level33":
                levelNumber.text = "Level 33";
                break;
            case "Level34":
                levelNumber.text = "Level 34";
                break;
            case "Level35":
                levelNumber.text = "Level 35";
                break;
            case "Level36":
                levelNumber.text = "Level 36";
                break;
            case "Level37":
                levelNumber.text = "Level 37";
                break;
            case "Level38":
                levelNumber.text = "Level 38";
                break;
            case "Level39":
                levelNumber.text = "Level 39";
                break;
            case "Level40":
                levelNumber.text = "Level 40";
                break;
            case "Level41":
                levelNumber.text = "Level 41";
                break;
            case "Level42":
                levelNumber.text = "Level 42";
                break;
            case "Level43":
                levelNumber.text = "Level 43";
                break;
            case "Level44":
                levelNumber.text = "Level 44";
                break;
            case "Level45":
                levelNumber.text = "Level 45";
                break;
            case "Level46":
                levelNumber.text = "Level 46";
                break;
            case "Level47":
                levelNumber.text = "Level 47";
                break;
            case "Level48":
                levelNumber.text = "Level 48";
                break;
            case "Level49":
                levelNumber.text = "Level 49";
                break;
            case "Level50":
                levelNumber.text = "Level 50";
                break;

            default:
                levelNumber.text = "RAN OUT OF LEVELS TO DISPLAY";
                break;

        }
    }
}
