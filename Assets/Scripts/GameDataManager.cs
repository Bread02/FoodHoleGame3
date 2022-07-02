using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]
public class GameDataManager : MonoBehaviour
{
    public static GameDataManager gameDataManagerInstance;

    [SerializeField] UnlockedLevels unlockedLevels = new UnlockedLevels();

    [SerializeField] StarsPerLevel starsPerLevel = new StarsPerLevel();

    [SerializeField] TimeLevelCompleted timeLevelCompleted = new TimeLevelCompleted();

    public UnlockedLevels unlockedLevels1 {get => unlockedLevels; set { unlockedLevels = value; } }

    public StarsPerLevel starsPerLevel1 { get => starsPerLevel; set { starsPerLevel = value; } }

    public TimeLevelCompleted timeLevelCompleted1 { get => timeLevelCompleted; set { timeLevelCompleted = value; } }

    // Start is called before the first frame update
    void Awake()
    {
        ReadFromSave();

        // destroys game data manager if there's more than one in the scene.
        int gameDataManager = FindObjectsOfType<GameDataManager>().Length;
        if (gameDataManager != 1)
        {
            Destroy(this.gameObject);
        }

        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void WriteToSave()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string filePath = $"{Application.persistentDataPath}/unlockedLevels.save";
        FileStream stream = new FileStream(filePath, FileMode.Create);
        string json = JsonUtility.ToJson(unlockedLevels);
        formatter.Serialize(stream, json);
        stream.Close();

        filePath = $"{Application.persistentDataPath}/starsPerLevel.save";
        stream = new FileStream(filePath, FileMode.Create);
        string json2 = JsonUtility.ToJson(starsPerLevel);
        formatter.Serialize(stream, json2);
        stream.Close();

        filePath = $"{Application.persistentDataPath}/timeLevelCompleted.save";
        stream = new FileStream(filePath, FileMode.Create);
        string json3 = JsonUtility.ToJson(timeLevelCompleted);
        formatter.Serialize(stream, json3);
        stream.Close();
    }

    private void ReadFromSave()
    {
        string filePath = $"{Application.persistentDataPath}/unlockedLevels.save";
        if (File.Exists(filePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(filePath, FileMode.Open);
            string json = (string)formatter.Deserialize(stream);
            unlockedLevels = JsonUtility.FromJson<UnlockedLevels>(json);
            stream.Close();
        }
        else
        {
            Debug.LogWarning($"Unlocked levels cannot be found");
            unlockedLevels = new UnlockedLevels();
        }

        filePath = $"{Application.persistentDataPath}/starsPerLevel.save";
        if (File.Exists(filePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(filePath, FileMode.Open);
            string json2 = (string)formatter.Deserialize(stream);
            starsPerLevel = JsonUtility.FromJson<StarsPerLevel>(json2);
            stream.Close();
        }
        else
        {
            Debug.LogWarning($"Stars Per Level cannot be found");
            starsPerLevel = new StarsPerLevel();
        }

        filePath = $"{Application.persistentDataPath}/timeLevelCompleted.save";
        if (File.Exists(filePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(filePath, FileMode.Open);
            string json3 = (string)formatter.Deserialize(stream);
            timeLevelCompleted = JsonUtility.FromJson<TimeLevelCompleted>(json3);
            stream.Close();
        }
        else
        {
            Debug.LogWarning($"Time level completed cannot be found");
            timeLevelCompleted = new TimeLevelCompleted();
        }
    }

    public void ReadGame()
    {
        Debug.Log("Reading Game");
        ReadFromSave();
    }

    public void SaveGame()
    {
        Debug.Log("Saving game");
        WriteToSave();
    }

    #region Unlock Levels
    public void UnlockLevel2()
    {
        unlockedLevels1.level2Unlocked = true;
        SaveGame();
    }

    public void UnlockLevel3()
    {
        unlockedLevels1.level3Unlocked = true;
        SaveGame();

    }

    public void UnlockLevel4()
    {
        unlockedLevels1.level4Unlocked = true;
        SaveGame();

    }

    public void UnlockLevel5()
    {
        unlockedLevels1.level5Unlocked = true;
        SaveGame();

    }

    public void UnlockLevel6()
    {
        unlockedLevels1.level6Unlocked = true;
        SaveGame();

    }

    public void UnlockLevel7()
    {
        unlockedLevels1.level7Unlocked = true;
        SaveGame();

    }

    public void UnlockLevel8()
    {
        unlockedLevels1.level8Unlocked = true;
        SaveGame();

    }

    public void UnlockLevel9()
    {
        unlockedLevels1.level9Unlocked = true;
        SaveGame();

    }

    public void UnlockLevel10()
    {
        unlockedLevels1.level10Unlocked = true;
        SaveGame();

    }

    public void UnlockLevel11()
    {
        unlockedLevels1.level11Unlocked = true;
        SaveGame();

    }

    public void UnlockLevel12()
    {
        unlockedLevels1.level12Unlocked = true;
        SaveGame();

    }

    public void UnlockLevel13()
    {
        unlockedLevels1.level13Unlocked = true;
        SaveGame();

    }

    public void UnlockLevel14()
    {
        unlockedLevels1.level14Unlocked = true;
        SaveGame();

    }

    public void UnlockLevel15()
    {
        unlockedLevels1.level15Unlocked = true;
        SaveGame();

    }

    public void UnlockLevel16()
    {
        unlockedLevels1.level16Unlocked = true;
        SaveGame();

    }

    public void UnlockLevel17()
    {
        unlockedLevels1.level17Unlocked = true;
        SaveGame();

    }

    public void UnlockLevel18()

    {
        unlockedLevels1.level18Unlocked = true;
        SaveGame();

    }

    public void UnlockLevel19()
    {
        unlockedLevels1.level19Unlocked = true;
        SaveGame();

    }


    public void UnlockLevel20()
    {
        unlockedLevels1.level20Unlocked = true;
        SaveGame();

    }

    public void UnlockLevel21()
    {
        unlockedLevels1.level21Unlocked = true;
        SaveGame();

    }

    public void UnlockLevel22()
    {
        unlockedLevels1.level22Unlocked = true;
        SaveGame();

    }

    public void UnlockLevel23()
    {
        unlockedLevels1.level23Unlocked = true;
        SaveGame();

    }

    public void UnlockLevel24()
    {
        unlockedLevels1.level24Unlocked = true;
        SaveGame();

    }

    public void UnlockLevel25()
    {
        unlockedLevels1.level25Unlocked = true;
        SaveGame();

    }

    public void UnlockLevel26()
    {
        unlockedLevels1.level26Unlocked = true;
        SaveGame();

    }

    public void UnlockLevel27()
    {
        unlockedLevels1.level27Unlocked = true;
        SaveGame();

    }

    public void UnlockLevel28()
    {
        unlockedLevels1.level28Unlocked = true;
        SaveGame();

    }

    public void UnlockLevel29()
    {
        unlockedLevels1.level29Unlocked = true;
        SaveGame();

    }

    public void UnlockLevel30()
    {
        unlockedLevels1.level30Unlocked = true;
        SaveGame();
    }

    public void UnlockLevel31()
    {
        unlockedLevels1.level31Unlocked = true;
        SaveGame();
    }

    public void UnlockLevel32()
    {
        unlockedLevels1.level32Unlocked = true;
        SaveGame();
    }

    public void UnlockLevel33()
    {
        unlockedLevels1.level33Unlocked = true;
        SaveGame();
    }

    public void UnlockLevel34()
    {
        unlockedLevels1.level34Unlocked = true;
        SaveGame();
    }

    public void UnlockLevel35()
    {
        unlockedLevels1.level35Unlocked = true;
        SaveGame();
    }

    public void UnlockLevel36()
    {
        unlockedLevels1.level36Unlocked = true;
        SaveGame();
    }

    public void UnlockLevel37()
    {
        unlockedLevels1.level37Unlocked = true;
        SaveGame();
    }

    public void UnlockLevel38()
    {
        unlockedLevels1.level38Unlocked = true;
        SaveGame();
    }

    public void UnlockLevel39()
    {
        unlockedLevels1.level39Unlocked = true;
        SaveGame();
    }

    public void UnlockLevel40()
    {
        unlockedLevels1.level40Unlocked = true;
        SaveGame();
    }

    public void UnlockLevel41()
    {
        unlockedLevels1.level41Unlocked = true;
        SaveGame();
    }

    public void UnlockLevel42()
    {
        unlockedLevels1.level42Unlocked = true;
        SaveGame();
    }

    public void UnlockLevel43()
    {
        unlockedLevels1.level43Unlocked = true;
        SaveGame();
    }

    public void UnlockLevel44()
    {
        unlockedLevels1.level44Unlocked = true;
        SaveGame();
    }
    public void UnlockLevel45()
    {
        unlockedLevels1.level45Unlocked = true;
        SaveGame();
    }

    public void UnlockLevel46()
    {
        unlockedLevels1.level46Unlocked = true;
        SaveGame();
    }

    public void UnlockLevel47()
    {
        unlockedLevels1.level47Unlocked = true;
        SaveGame();
    }

    public void UnlockLevel48()
    {
        unlockedLevels1.level48Unlocked = true;
        SaveGame();
    }

    public void UnlockLevel49()
    {
        unlockedLevels1.level49Unlocked = true;
        SaveGame();
    }

    public void UnlockLevel50()
    {
        unlockedLevels1.level50Unlocked = true;
        SaveGame();
    }

    #endregion

    #region Check Unlocked Levels
    public bool Level2UnlockedCheck()
    {
        if (unlockedLevels1.level2Unlocked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Level3UnlockedCheck()
    {
        if (unlockedLevels1.level3Unlocked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Level4UnlockedCheck()
    {
        if (unlockedLevels1.level4Unlocked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Level5UnlockedCheck()
    {
        if (unlockedLevels1.level5Unlocked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Level6UnlockedCheck()
    {
        if (unlockedLevels1.level6Unlocked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Level7UnlockedCheck()
    {
        if (unlockedLevels1.level7Unlocked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Level8UnlockedCheck()
    {
        if (unlockedLevels1.level8Unlocked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Level9UnlockedCheck()
    {
        if (unlockedLevels1.level9Unlocked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Level10UnlockedCheck()
    {
        if (unlockedLevels1.level10Unlocked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Level11UnlockedCheck()
    {
        if (unlockedLevels1.level11Unlocked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Level12UnlockedCheck()
    {
        if (unlockedLevels1.level12Unlocked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Level13UnlockedCheck()
    {
        if (unlockedLevels1.level13Unlocked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool Level14UnlockedCheck()
    {
        if (unlockedLevels1.level14Unlocked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Level15UnlockedCheck()
    {
        if (unlockedLevels1.level15Unlocked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Level16UnlockedCheck()
    {
        if (unlockedLevels1.level16Unlocked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Level17UnlockedCheck()
    {
        if (unlockedLevels1.level17Unlocked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Level18UnlockedCheck()
    {
        if (unlockedLevels1.level18Unlocked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Level19UnlockedCheck()
    {
        if (unlockedLevels1.level19Unlocked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Level20UnlockedCheck()

    {
        if (unlockedLevels1.level20Unlocked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Level21UnlockedCheck()

    {
        if (unlockedLevels1.level21Unlocked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Level22UnlockedCheck()

    {
        if (unlockedLevels1.level22Unlocked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Level23UnlockedCheck()

    {
        if (unlockedLevels1.level23Unlocked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Level24UnlockedCheck()

    {
        if (unlockedLevels1.level24Unlocked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Level25UnlockedCheck()

    {
        if (unlockedLevels1.level25Unlocked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Level26UnlockedCheck()

    {
        if (unlockedLevels1.level26Unlocked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Level27UnlockedCheck()

    {
        if (unlockedLevels1.level27Unlocked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Level28UnlockedCheck()

    {
        if (unlockedLevels1.level28Unlocked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Level29UnlockedCheck()

    {
        if (unlockedLevels1.level29Unlocked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Level30UnlockedCheck()
    {
        if (unlockedLevels1.level30Unlocked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Level31UnlockedCheck()
    {
        if (unlockedLevels1.level31Unlocked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Level32UnlockedCheck()
    {
        if (unlockedLevels1.level32Unlocked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Level33UnlockedCheck()
    {
        if (unlockedLevels1.level33Unlocked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Level34UnlockedCheck()
    {
        if (unlockedLevels1.level34Unlocked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Level35UnlockedCheck()
    {
        if (unlockedLevels1.level35Unlocked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Level36UnlockedCheck()
    {
        if (unlockedLevels1.level36Unlocked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Level37UnlockedCheck()
    {
        if (unlockedLevels1.level37Unlocked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Level38UnlockedCheck()
    {
        if (unlockedLevels1.level38Unlocked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Level39UnlockedCheck()
    {
        if (unlockedLevels1.level39Unlocked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Level40UnlockedCheck()
    {
        if (unlockedLevels1.level40Unlocked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Level41UnlockedCheck()
    {
        if (unlockedLevels1.level41Unlocked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Level42UnlockedCheck()
    {
        if (unlockedLevels1.level42Unlocked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Level43UnlockedCheck()
    {
        if (unlockedLevels1.level43Unlocked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Level44UnlockedCheck()
    {
        if (unlockedLevels1.level44Unlocked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Level45UnlockedCheck()
    {
        if (unlockedLevels1.level45Unlocked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Level46UnlockedCheck()
    {
        if (unlockedLevels1.level46Unlocked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Level47UnlockedCheck()
    {
        if (unlockedLevels1.level47Unlocked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Level48UnlockedCheck()
    {
        if (unlockedLevels1.level48Unlocked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Level49UnlockedCheck()
    {
        if (unlockedLevels1.level49Unlocked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool Level50UnlockedCheck()
    {
        if (unlockedLevels1.level50Unlocked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    #endregion

    #region Set Stars Per Level
    public void SetLevel1Stars(int stars)
    {
        starsPerLevel1.level1Stars = stars;
        SaveGame();
    }

    public void SetLevel2Stars(int stars)
    {
        starsPerLevel1.level2Stars = stars;
        SaveGame();
    }

    public void SetLevel3Stars(int stars)
    {
        starsPerLevel1.level3Stars = stars;
        SaveGame();
    }

    public void SetLevel4Stars(int stars)
    {
        starsPerLevel1.level4Stars = stars;
        SaveGame();
    }

    public void SetLevel5Stars(int stars)
    {
        starsPerLevel1.level5Stars = stars;
        SaveGame();

    }

    public void SetLevel6Stars(int stars)
    {
        starsPerLevel1.level6Stars = stars;
        SaveGame();
    }
    public void SetLevel7Stars(int stars)
    {
        starsPerLevel1.level7Stars = stars;
        SaveGame();
    }
    public void SetLevel8Stars(int stars)
    {
        starsPerLevel1.level8Stars = stars;
        SaveGame();
    }
    public void SetLevel9Stars(int stars)
    {
        starsPerLevel1.level9Stars = stars;
        SaveGame();
    }
    public void SetLevel10Stars(int stars)
    {
        starsPerLevel1.level10Stars = stars;
        SaveGame();
    }
    public void SetLevel11Stars(int stars)
    {
        starsPerLevel1.level11Stars = stars;
        SaveGame();
    }
    public void SetLevel12Stars(int stars)
    {
        starsPerLevel1.level12Stars = stars;
        SaveGame();
    }
    public void SetLevel13Stars(int stars)
    {
        starsPerLevel1.level13Stars = stars;
        SaveGame();
    }
    public void SetLevel14Stars(int stars)
    {
        starsPerLevel1.level14Stars = stars;
        SaveGame();
    }
    public void SetLevel15Stars(int stars)
    {
        starsPerLevel1.level15Stars = stars;
        SaveGame();
    }
    public void SetLevel16Stars(int stars)
    {
        starsPerLevel1.level16Stars = stars;
        SaveGame();
    }
    public void SetLevel17Stars(int stars)
    {
        starsPerLevel1.level17Stars = stars;
        SaveGame();
    }
    public void SetLevel18Stars(int stars)
    {
        starsPerLevel1.level18Stars = stars;
        SaveGame();
    }

    public void SetLevel19Stars(int stars)
    {
        starsPerLevel1.level19Stars = stars;
        SaveGame();
    }

    public void SetLevel20Stars(int stars)
    {
        starsPerLevel1.level20Stars = stars;
        SaveGame();
    }

    public void SetLevel21Stars(int stars)
    {
        starsPerLevel1.level21Stars = stars;
        SaveGame();
    }

    public void SetLevel22Stars(int stars)
    {
        starsPerLevel1.level22Stars = stars;
        SaveGame();
    }

    public void SetLevel23Stars(int stars)
    {
        starsPerLevel1.level23Stars = stars;
        SaveGame();
    }

    public void SetLevel24Stars(int stars)
    {
        starsPerLevel1.level24Stars = stars;
        SaveGame();
    }

    public void SetLevel25Stars(int stars)
    {
        starsPerLevel1.level25Stars = stars;
        SaveGame();
    }

    public void SetLevel26Stars(int stars)
    {
        starsPerLevel1.level26Stars = stars;
        SaveGame();
    }

    public void SetLevel27Stars(int stars)
    {
        starsPerLevel1.level27Stars = stars;
        SaveGame();
    }

    public void SetLevel28Stars(int stars)
    {
        starsPerLevel1.level28Stars = stars;
        SaveGame();
    }

    public void SetLevel29Stars(int stars)
    {
        starsPerLevel1.level29Stars = stars;
        SaveGame();
    }

    public void SetLevel30Stars(int stars)
    {
        starsPerLevel1.level30Stars = stars;
        SaveGame();
    }

    public void SetLevel31Stars(int stars)
    {
        starsPerLevel1.level31Stars = stars;
        SaveGame();
    }

    public void SetLevel32Stars(int stars)
    {
        starsPerLevel1.level32Stars = stars;
        SaveGame();
    }

    public void SetLevel33Stars(int stars)
    {
        starsPerLevel1.level33Stars = stars;
        SaveGame();
    }

    public void SetLevel34Stars(int stars)
    {
        starsPerLevel1.level34Stars = stars;
        SaveGame();
    }

    public void SetLevel35Stars(int stars)
    {
        starsPerLevel1.level35Stars = stars;
        SaveGame();
    }

    public void SetLevel36Stars(int stars)
    {
        starsPerLevel1.level36Stars = stars;
        SaveGame();
    }

    public void SetLevel37Stars(int stars)
    {
        starsPerLevel1.level37Stars = stars;
        SaveGame();
    }

    public void SetLevel38Stars(int stars)
    {
        starsPerLevel1.level38Stars = stars;
        SaveGame();
    }

    public void SetLevel39Stars(int stars)
    {
        starsPerLevel1.level39Stars = stars;
        SaveGame();
    }

    public void SetLevel40Stars(int stars)
    {
        starsPerLevel1.level40Stars = stars;
        SaveGame();
    }

    public void SetLevel41Stars(int stars)
    {
        starsPerLevel1.level41Stars = stars;
        SaveGame();
    }

    public void SetLevel42Stars(int stars)
    {
        starsPerLevel1.level42Stars = stars;
        SaveGame();
    }

    public void SetLevel43Stars(int stars)
    {
        starsPerLevel1.level43Stars = stars;
        SaveGame();
    }

    public void SetLevel44Stars(int stars)
    {
        starsPerLevel1.level44Stars = stars;
        SaveGame();
    }

    public void SetLevel45Stars(int stars)
    {
        starsPerLevel1.level45Stars = stars;
        SaveGame();
    }

    public void SetLevel46Stars(int stars)
    {
        starsPerLevel1.level46Stars = stars;
        SaveGame();
    }

    public void SetLevel47Stars(int stars)
    {
        starsPerLevel1.level47Stars = stars;
        SaveGame();
    }

    public void SetLevel48Stars(int stars)
    {
        starsPerLevel1.level48Stars = stars;
        SaveGame();
    }

    public void SetLevel49Stars(int stars)
    {
        starsPerLevel1.level49Stars = stars;
        SaveGame();
    }

    public void SetLevel50Stars(int stars)
    {
        starsPerLevel1.level50Stars = stars;
        SaveGame();
    }
    #endregion

    #region Return Stars Per Level
    public int ReturnLevel1Stars()
    {
        return starsPerLevel1.level1Stars;
    }

    public int ReturnLevel2Stars()
    {
        return starsPerLevel1.level2Stars;
    }

    public int ReturnLevel3Stars()
    {
        return starsPerLevel1.level3Stars;
    }

    public int ReturnLevel4Stars()
    {
        return starsPerLevel1.level4Stars;
    }

    public int ReturnLevel5Stars()
    {
        return starsPerLevel1.level5Stars;
    }

    public int ReturnLevel6Stars()
    {
        return starsPerLevel1.level6Stars;
    }

    public int ReturnLevel7Stars()
    {
        return starsPerLevel1.level7Stars;
    }

    public int ReturnLevel8Stars()
    {
        return starsPerLevel1.level8Stars;
    }

    public int ReturnLevel9Stars()
    {
        return starsPerLevel1.level9Stars;
    }

    public int ReturnLevel10Stars()
    {
        return starsPerLevel1.level10Stars;
    }
    public int ReturnLevel11Stars()
    {
        return starsPerLevel1.level11Stars;
    }

    public int ReturnLevel12Stars()
    {
        return starsPerLevel1.level12Stars;
    }
    public int ReturnLevel13Stars()
    {
        return starsPerLevel1.level13Stars;
    }
    public int ReturnLevel14Stars()
    {
        return starsPerLevel1.level14Stars;
    }
    public int ReturnLevel15Stars()
    {
        return starsPerLevel1.level15Stars;

    }

    public int ReturnLevel16Stars()
    {
        return starsPerLevel1.level16Stars;

    }

    public int ReturnLevel17Stars()
    {
        return starsPerLevel1.level17Stars;

    }

    public int ReturnLevel18Stars()
    {
        return starsPerLevel1.level18Stars;

    }

    public int ReturnLevel19Stars()
    {
        return starsPerLevel1.level19Stars;

    }

    public int ReturnLevel20Stars()
    {
        return starsPerLevel1.level20Stars;

    }

    public int ReturnLevel21Stars()
    {
        return starsPerLevel1.level21Stars;

    }

    public int ReturnLevel22Stars()
    {
        return starsPerLevel1.level22Stars;

    }

    public int ReturnLevel23Stars()
    {
        return starsPerLevel1.level23Stars;

    }

    public int ReturnLevel24Stars()
    {
        return starsPerLevel1.level24Stars;

    }

    public int ReturnLevel25Stars()
    {
        return starsPerLevel1.level25Stars;

    }

    public int ReturnLevel26Stars()
    {
        return starsPerLevel1.level26Stars;

    }

    public int ReturnLevel27Stars()
    {
        return starsPerLevel1.level27Stars;

    }

    public int ReturnLevel28Stars()
    {
        return starsPerLevel1.level28Stars;

    }

    public int ReturnLevel29Stars()
    {
        return starsPerLevel1.level29Stars;

    }

    public int ReturnLevel30Stars()
    {
        return starsPerLevel1.level30Stars;
    }

    public int ReturnLevel31Stars()
    {
        return starsPerLevel1.level31Stars;
    }

    public int ReturnLevel32Stars()
    {
        return starsPerLevel1.level32Stars;
    }

    public int ReturnLevel33Stars()
    {
        return starsPerLevel1.level33Stars;
    }

    public int ReturnLevel34Stars()
    {
        return starsPerLevel1.level34Stars;
    }

    public int ReturnLevel35Stars()
    {
        return starsPerLevel1.level35Stars;
    }

    public int ReturnLevel36Stars()
    {
        return starsPerLevel1.level36Stars;
    }

    public int ReturnLevel37Stars()
    {
        return starsPerLevel1.level37Stars;
    }

    public int ReturnLevel38Stars()
    {
        return starsPerLevel1.level38Stars;
    }

    public int ReturnLevel39Stars()
    {
        return starsPerLevel1.level39Stars;
    }

    public int ReturnLevel40Stars()
    {
        return starsPerLevel1.level40Stars;
    }

    public int ReturnLevel41Stars()
    {
        return starsPerLevel1.level41Stars;
    }

    public int ReturnLevel42Stars()
    {
        return starsPerLevel1.level42Stars;
    }

    public int ReturnLevel43Stars()
    {
        return starsPerLevel1.level43Stars;
    }

    public int ReturnLevel44Stars()
    {
        return starsPerLevel1.level44Stars;
    }

    public int ReturnLevel45Stars()
    {
        return starsPerLevel1.level45Stars;
    }

    public int ReturnLevel46Stars()
    {
        return starsPerLevel1.level46Stars;
    }

    public int ReturnLevel47Stars()
    {
        return starsPerLevel1.level47Stars;
    }

    public int ReturnLevel48Stars()
    {
        return starsPerLevel1.level48Stars;
    }

    public int ReturnLevel49Stars()
    {
        return starsPerLevel1.level49Stars;
    }

    public int ReturnLevel50Stars()
    {
        return starsPerLevel1.level50Stars;
    }
    #endregion

    #region Set Time Per Level
    public void SetLevel1Time(float time)
    {
        timeLevelCompleted1.level1Time = time;
        SaveGame();
    }

    public void SetLevel2Time(float time)
    {
        timeLevelCompleted1.level2Time = time;
        SaveGame();
    }

    public void SetLevel3Time(float time)
    {
        timeLevelCompleted1.level3Time = time;
        SaveGame();
    }

    public void SetLevel4Time(float time)
    {
        timeLevelCompleted1.level4Time = time;
        SaveGame();
    }

    public void SetLevel5Time(float time)
    {
        timeLevelCompleted1.level5Time = time;
        SaveGame();
    }

    public void SetLevel6Time(float time)
    {
        timeLevelCompleted1.level6Time = time;
        SaveGame();
    }

    public void SetLevel7Time(float time)
    {
        timeLevelCompleted1.level7Time = time;
        SaveGame();
    }

    public void SetLevel8Time(float time)
    {
        timeLevelCompleted1.level8Time = time;
        SaveGame();
    }

    public void SetLevel9Time(float time)
    {
        timeLevelCompleted1.level9Time = time;
        SaveGame();
    }

    public void SetLevel10Time(float time)
    {
        timeLevelCompleted1.level10Time = time;
        SaveGame();
    }

    public void SetLevel11Time(float time)
    {
        timeLevelCompleted1.level11Time = time;
        SaveGame();
    }

    public void SetLevel12Time(float time)
    {
        timeLevelCompleted1.level12Time = time;
        SaveGame();
    }

    public void SetLevel13Time(float time)
    {
        timeLevelCompleted1.level13Time = time;
        SaveGame();
    }

    public void SetLevel14Time(float time)
    {
        timeLevelCompleted1.level14Time = time;
        SaveGame();
    }

    public void SetLevel15Time(float time)
    {
        timeLevelCompleted1.level15Time = time;
        SaveGame();
    }

    public void SetLevel16Time(float time)
    {
        timeLevelCompleted1.level16Time = time;
        SaveGame();
    }
    public void SetLevel17Time(float time)
    {
        timeLevelCompleted1.level17Time = time;
        SaveGame();
    }

    public void SetLevel18Time(float time)
    {
        timeLevelCompleted1.level18Time = time;
        SaveGame();
    }

    public void SetLevel19Time(float time)
    {
        timeLevelCompleted1.level19Time = time;
        SaveGame();
    }

    public void SetLevel20Time(float time)
    {
        timeLevelCompleted1.level20Time = time;
        SaveGame();
    }

    public void SetLevel21Time(float time)
    {
        timeLevelCompleted1.level21Time = time;
        SaveGame();
    }

    public void SetLevel22Time(float time)
    {
        timeLevelCompleted1.level22Time = time;
        SaveGame();
    }

    public void SetLevel23Time(float time)
    {
        timeLevelCompleted1.level23Time = time;
        SaveGame();
    }

    public void SetLevel24Time(float time)
    {
        timeLevelCompleted1.level24Time = time;
        SaveGame();
    }

    public void SetLevel25Time(float time)
    {
        timeLevelCompleted1.level25Time = time;
        SaveGame();
    }

    public void SetLevel26Time(float time)
    {
        timeLevelCompleted1.level26Time = time;
        SaveGame();
    }

    public void SetLevel27Time(float time)
    {
        timeLevelCompleted1.level27Time = time;
        SaveGame();
    }

    public void SetLevel28Time(float time)
    {
        timeLevelCompleted1.level28Time = time;
        SaveGame();
    }

    public void SetLevel29Time(float time)
    {
        timeLevelCompleted1.level29Time = time;
        SaveGame();
    }

    public void SetLevel30Time(float time)
    {
        timeLevelCompleted1.level30Time = time;
        SaveGame();
    }

    public void SetLevel31Time(float time)
    {
        timeLevelCompleted1.level31Time = time;
        SaveGame();
    }

    public void SetLevel32Time(float time)
    {
        timeLevelCompleted1.level32Time = time;
        SaveGame();
    }

    public void SetLevel33Time(float time)
    {
        timeLevelCompleted1.level33Time = time;
        SaveGame();
    }

    public void SetLevel34Time(float time)
    {
        timeLevelCompleted1.level34Time = time;
        SaveGame();
    }

    public void SetLevel35Time(float time)
    {
        timeLevelCompleted1.level35Time = time;
        SaveGame();
    }

    public void SetLevel36Time(float time)
    {
        timeLevelCompleted1.level36Time = time;
        SaveGame();
    }

    public void SetLevel37Time(float time)
    {
        timeLevelCompleted1.level37Time = time;
        SaveGame();
    }

    public void SetLevel38Time(float time)
    {
        timeLevelCompleted1.level38Time = time;
        SaveGame();
    }

    public void SetLevel39Time(float time)
    {
        timeLevelCompleted1.level39Time = time;
        SaveGame();
    }

    public void SetLevel40Time(float time)
    {
        timeLevelCompleted1.level40Time = time;
        SaveGame();
    }

    public void SetLevel41Time(float time)
    {
        timeLevelCompleted1.level41Time = time;
        SaveGame();
    }

    public void SetLevel42Time(float time)
    {
        timeLevelCompleted1.level42Time = time;
        SaveGame();
    }

    public void SetLevel43Time(float time)
    {
        timeLevelCompleted1.level43Time = time;
        SaveGame();
    }

    public void SetLevel44Time(float time)
    {
        timeLevelCompleted1.level44Time = time;
        SaveGame();
    }

    public void SetLevel45Time(float time)
    {
        timeLevelCompleted1.level45Time = time;
        SaveGame();
    }

    public void SetLevel46Time(float time)
    {
        timeLevelCompleted1.level46Time = time;
        SaveGame();
    }

    public void SetLevel47Time(float time)
    {
        timeLevelCompleted1.level47Time = time;
        SaveGame();
    }

    public void SetLevel48Time(float time)
    {
        timeLevelCompleted1.level48Time = time;
        SaveGame();
    }

    public void SetLevel49Time(float time)
    {
        timeLevelCompleted1.level49Time = time;
        SaveGame();
    }

    public void SetLevel50Time(float time)
    {
        timeLevelCompleted1.level50Time = time;
        SaveGame();
    }

    #endregion

    #region Return Time Per Level

    public float ReturnLevel1Time()
    {
        return timeLevelCompleted1.level1Time;
    }

    public float ReturnLevel2Time()
    {
        return timeLevelCompleted.level2Time;
    }

    public float ReturnLevel3Time()
    {
        return timeLevelCompleted1.level3Time;
    }

    public float ReturnLevel4Time()
    {
        return timeLevelCompleted1.level4Time;
    }

    public float ReturnLevel5Time()
    {
        return timeLevelCompleted1.level5Time;
    }

    public float ReturnLevel6Time()
    {
        return timeLevelCompleted1.level6Time;
    }

    public float ReturnLevel7Time()
    {
        return timeLevelCompleted1.level7Time;
    }

    public float ReturnLevel8Time()
    {
        return timeLevelCompleted1.level8Time;
    }

    public float ReturnLevel9Time()
    {
        return timeLevelCompleted1.level9Time;
    }

    public float ReturnLevel10Time()
    {
        return timeLevelCompleted1.level10Time;
    }

    public float ReturnLevel11Time()
    {
        return timeLevelCompleted1.level11Time;
    }

    public float ReturnLevel12Time()
    {
        return timeLevelCompleted1.level12Time;
    }

    public float ReturnLevel13Time()
    {
        return timeLevelCompleted1.level13Time;
    }

    public float ReturnLevel14Time()
    {
        return timeLevelCompleted1.level14Time;
    }

    public float ReturnLevel15Time()
    {
        return timeLevelCompleted1.level15Time;
    }

    public float ReturnLevel16Time()
    {
        return timeLevelCompleted1.level16Time;
    }

    public float ReturnLevel17Time()
    {
        return timeLevelCompleted1.level17Time;
    }

    public float ReturnLevel18Time()
    {
        return timeLevelCompleted1.level18Time;
    }

    public float ReturnLevel19Time()
    {
        return timeLevelCompleted1.level19Time;
    }

    public float ReturnLevel20Time()
    {
        return timeLevelCompleted1.level20Time;
    }

    public float ReturnLevel21Time()
    {
        return timeLevelCompleted1.level21Time;
    }

    public float ReturnLevel22Time()
    {
        return timeLevelCompleted1.level22Time;
    }

    public float ReturnLevel23Time()
    {
        return timeLevelCompleted1.level23Time;
    }

    public float ReturnLevel24Time()
    {
        return timeLevelCompleted1.level24Time;
    }

    public float ReturnLevel25Time()
    {
        return timeLevelCompleted1.level25Time;
    }

    public float ReturnLevel26Time()
    {
        return timeLevelCompleted1.level26Time;
    }

    public float ReturnLevel27Time()
    {
        return timeLevelCompleted1.level27Time;
    }

    public float ReturnLevel28Time()
    {
        return timeLevelCompleted1.level28Time;
    }

    public float ReturnLevel29Time()
    {
        return timeLevelCompleted1.level29Time;
    }

    public float ReturnLevel30Time()
    {
        return timeLevelCompleted1.level30Time;
    }

    public float ReturnLevel31Time()
    {
        return timeLevelCompleted1.level31Time;
    }

    public float ReturnLevel32Time()
    {
        return timeLevelCompleted1.level32Time;
    }

    public float ReturnLevel33Time()
    {
        return timeLevelCompleted1.level33Time;
    }

    public float ReturnLevel34Time()
    {
        return timeLevelCompleted1.level34Time;
    }

    public float ReturnLevel35Time()
    {
        return timeLevelCompleted1.level35Time;
    }

    public float ReturnLevel36Time()
    {
        return timeLevelCompleted1.level36Time;
    }

    public float ReturnLevel37Time()
    {
        return timeLevelCompleted1.level37Time;
    }

    public float ReturnLevel38Time()
    {
        return timeLevelCompleted1.level38Time;
    }

    public float ReturnLevel39Time()
    {
        return timeLevelCompleted1.level39Time;
    }

    public float ReturnLevel40Time()
    {
        return timeLevelCompleted1.level40Time;
    }

    public float ReturnLevel41Time()
    {
        return timeLevelCompleted1.level41Time;
    }

    public float ReturnLevel42Time()
    {
        return timeLevelCompleted1.level42Time;
    }

    public float ReturnLevel43Time()
    {
        return timeLevelCompleted1.level43Time;
    }

    public float ReturnLevel44Time()
    {
        return timeLevelCompleted1.level44Time;
    }

    public float ReturnLevel45Time()
    {
        return timeLevelCompleted1.level45Time;
    }

    public float ReturnLevel46Time()
    {
        return timeLevelCompleted1.level46Time;
    }

    public float ReturnLevel47Time()
    {
        return timeLevelCompleted1.level47Time;
    }

    public float ReturnLevel48Time()
    {
        return timeLevelCompleted1.level48Time;
    }

    public float ReturnLevel49Time()
    {
        return timeLevelCompleted1.level49Time;
    }

    public float ReturnLevel50Time()
    {
        return timeLevelCompleted1.level50Time;
    }

    #endregion
}

[SerializeField]
public class UnlockedLevels
{
    public bool level2Unlocked;
    public bool level3Unlocked;
    public bool level4Unlocked;
    public bool level5Unlocked;
    public bool level6Unlocked;
    public bool level7Unlocked;
    public bool level8Unlocked;
    public bool level9Unlocked;
    public bool level10Unlocked;
    public bool level11Unlocked;
    public bool level12Unlocked;
    public bool level13Unlocked;
    public bool level14Unlocked;
    public bool level15Unlocked;
    public bool level16Unlocked;
    public bool level17Unlocked;
    public bool level18Unlocked;
    public bool level19Unlocked;
    public bool level20Unlocked;
    public bool level21Unlocked;
    public bool level22Unlocked;
    public bool level23Unlocked;
    public bool level24Unlocked;
    public bool level25Unlocked;
    public bool level26Unlocked;
    public bool level27Unlocked;
    public bool level28Unlocked;
    public bool level29Unlocked;
    public bool level30Unlocked;
    public bool level31Unlocked;
    public bool level32Unlocked;
    public bool level33Unlocked;
    public bool level34Unlocked;
    public bool level35Unlocked;
    public bool level36Unlocked;
    public bool level37Unlocked;
    public bool level38Unlocked;
    public bool level39Unlocked;
    public bool level40Unlocked;
    public bool level41Unlocked;
    public bool level42Unlocked;
    public bool level43Unlocked;
    public bool level44Unlocked;
    public bool level45Unlocked;
    public bool level46Unlocked;
    public bool level47Unlocked;
    public bool level48Unlocked;
    public bool level49Unlocked;
    public bool level50Unlocked;

    public UnlockedLevels(bool level2Unlocked, bool level3Unlocked, bool level4Unlocked, bool level5Unlocked,
    bool level6Unlocked, bool level7Unlocked, bool level8Unlocked, bool level9Unlocked, bool level10Unlocked,
    bool level11Unlocked, bool level12Unlocked, bool level13Unlocked, bool level14Unlocked, bool level15Unlocked,
    bool level16Unlocked, bool level17Unlocked, bool level18Unlocked, bool level19Unlocked, bool level20Unlocked, 
    bool level21Unlocked, bool level22Unlocked, bool level23Unlocked, bool level24Unlocked, bool level25Unlocked, 
    bool level26Unlocked, bool level27Unlocked, bool level28Unlocked, bool level29Unlocked, bool level30Unlocked, 
    bool level31Unlocked, bool level32Unlocked, bool level33Unlocked, bool level34Unlocked, bool level35Unlocked, 
    bool level36Unlocked, bool level37Unlocked, bool level38Unlocked, bool level39Unlocked, bool level40Unlocked, 
    bool level41Unlocked, bool level42Unlocked, bool level43Unlocked, bool level44Unlocked, bool level45Unlocked, 
    bool level46Unlocked, bool level47Unlocked, bool level48Unlocked, bool level49Unlocked, bool level50Unlocked)
    {
        this.level2Unlocked = level2Unlocked;
        this.level3Unlocked = level3Unlocked;
        this.level4Unlocked = level4Unlocked;
        this.level5Unlocked = level5Unlocked;
        this.level6Unlocked = level6Unlocked;
        this.level7Unlocked = level7Unlocked;
        this.level8Unlocked = level8Unlocked;
        this.level9Unlocked = level9Unlocked;
        this.level10Unlocked = level10Unlocked;
        this.level11Unlocked = level11Unlocked;
        this.level12Unlocked = level12Unlocked;
        this.level13Unlocked = level13Unlocked;
        this.level14Unlocked = level14Unlocked;
        this.level15Unlocked = level15Unlocked;
        this.level16Unlocked = level16Unlocked;
        this.level17Unlocked = level17Unlocked;
        this.level18Unlocked = level18Unlocked;
        this.level19Unlocked = level19Unlocked;
        this.level20Unlocked = level20Unlocked;
        this.level21Unlocked = level21Unlocked;
        this.level22Unlocked = level22Unlocked;
        this.level23Unlocked = level23Unlocked;
        this.level24Unlocked = level24Unlocked;
        this.level25Unlocked = level25Unlocked;
        this.level26Unlocked = level26Unlocked;
        this.level27Unlocked = level27Unlocked;
        this.level28Unlocked = level28Unlocked;
        this.level29Unlocked = level29Unlocked;
        this.level30Unlocked = level30Unlocked;
        this.level31Unlocked = level31Unlocked;
        this.level32Unlocked = level32Unlocked;
        this.level33Unlocked = level33Unlocked;
        this.level34Unlocked = level34Unlocked;
        this.level35Unlocked = level35Unlocked;
        this.level36Unlocked = level36Unlocked;
        this.level37Unlocked = level37Unlocked;
        this.level38Unlocked = level38Unlocked;
        this.level39Unlocked = level39Unlocked;
        this.level40Unlocked = level40Unlocked;
        this.level41Unlocked = level41Unlocked;
        this.level42Unlocked = level42Unlocked;
        this.level43Unlocked = level43Unlocked;
        this.level44Unlocked = level44Unlocked;
        this.level45Unlocked = level45Unlocked;
        this.level46Unlocked = level46Unlocked;
        this.level47Unlocked = level47Unlocked;
        this.level48Unlocked = level48Unlocked;
        this.level49Unlocked = level49Unlocked;
        this.level50Unlocked = level50Unlocked;
    }

    public UnlockedLevels()
    {
        level2Unlocked = false;
        level3Unlocked = false;
        level4Unlocked = false;
        level5Unlocked = false;
        level6Unlocked = false;
        level7Unlocked = false;
        level8Unlocked = false;
        level9Unlocked = false;
        level10Unlocked = false;
        level11Unlocked = false;
        level12Unlocked = false;
        level13Unlocked = false;
        level14Unlocked = false;
        level15Unlocked = false;
        level16Unlocked = false;
        level17Unlocked = false;
        level18Unlocked = false;
        level19Unlocked = false;
        level20Unlocked = false;
        level21Unlocked = false;
        level22Unlocked = false;
        level23Unlocked = false;
        level24Unlocked = false;
        level25Unlocked = false;
        level26Unlocked = false;
        level27Unlocked = false;
        level28Unlocked = false;
        level29Unlocked = false;
        level30Unlocked = false;
        level31Unlocked = false;
        level32Unlocked = false;
        level33Unlocked = false;
        level34Unlocked = false;
        level35Unlocked = false;
        level36Unlocked = false;
        level37Unlocked = false;
        level38Unlocked = false;
        level39Unlocked = false;
        level40Unlocked = false;
        level41Unlocked = false;
        level42Unlocked = false;
        level43Unlocked = false;
        level44Unlocked = false;
        level45Unlocked = false;
        level46Unlocked = false;
        level47Unlocked = false;
        level48Unlocked = false;
        level49Unlocked = false;
        level50Unlocked = false;
    }

}

[SerializeField]
public class StarsPerLevel
    {
    public int level1Stars;
    public int level2Stars;
    public int level3Stars;
    public int level4Stars;
    public int level5Stars;
    public int level6Stars;
    public int level7Stars;
    public int level8Stars;
    public int level9Stars;
    public int level10Stars;
    public int level11Stars;
    public int level12Stars;
    public int level13Stars;
    public int level14Stars;
    public int level15Stars;
    public int level16Stars;
    public int level17Stars;
    public int level18Stars;
    public int level19Stars;
    public int level20Stars;
    public int level21Stars;
    public int level22Stars;
    public int level23Stars;
    public int level24Stars;
    public int level25Stars;
    public int level26Stars;
    public int level27Stars;
    public int level28Stars;
    public int level29Stars;
    public int level30Stars;
    public int level31Stars;
    public int level32Stars;
    public int level33Stars;
    public int level34Stars;
    public int level35Stars;
    public int level36Stars;
    public int level37Stars;
    public int level38Stars;
    public int level39Stars;
    public int level40Stars;
    public int level41Stars;
    public int level42Stars;
    public int level43Stars;
    public int level44Stars;
    public int level45Stars;
    public int level46Stars;
    public int level47Stars;
    public int level48Stars;
    public int level49Stars;
    public int level50Stars;

    public StarsPerLevel(int level1Stars, int level2Stars, int level3Stars, int level4Stars, int level5Stars, int level6Stars,
        int level7Stars, int level8Stars, int level9Stars, int level10Stars, int level11Stars, int level12Stars, int level13Stars,
        int level14Stars, int level15Stars, int level16Stars, int level17Stars, int level18Stars, int level19Stars, int level20Stars, 
        int level21Stars, int level22Stars, int level23Stars, int level24Stars, int level25Stars, int level26Stars, int level27Stars, 
        int level28Stars, int level29Stars, int level30Stars, int level31Stars, int level32Stars, int level33Stars, int level34Stars, 
        int level35Stars, int level36Stars, int level37Stars, int level38Stars, int level39Stars, int level40Stars, int level41Stars, 
        int level42Stars, int level43Stars, int level44Stars, int level45Stars, int level46Stars, int level47Stars, int level48Stars, 
        int level49Stars, int level50Stars)
    {
        this.level1Stars = level1Stars;
        this.level2Stars = level2Stars;
        this.level3Stars = level3Stars;
        this.level4Stars = level4Stars;
        this.level5Stars = level5Stars;
        this.level6Stars = level6Stars;
        this.level7Stars = level7Stars;
        this.level8Stars = level8Stars;
        this.level9Stars = level9Stars;
        this.level10Stars = level10Stars;
        this.level11Stars = level11Stars;
        this.level12Stars = level12Stars;
        this.level13Stars = level13Stars;
        this.level14Stars = level14Stars;
        this.level15Stars = level15Stars;
        this.level16Stars = level16Stars;
        this.level17Stars = level17Stars;
        this.level18Stars = level18Stars;
        this.level19Stars = level19Stars;
        this.level20Stars = level20Stars;
        this.level21Stars = level21Stars;
        this.level22Stars = level22Stars;
        this.level23Stars = level23Stars;
        this.level24Stars = level24Stars;
        this.level25Stars = level25Stars;
        this.level26Stars = level26Stars;
        this.level27Stars = level27Stars;
        this.level28Stars = level28Stars;
        this.level29Stars = level29Stars;
        this.level30Stars = level30Stars;
        this.level31Stars = level31Stars;
        this.level32Stars = level32Stars;
        this.level33Stars = level33Stars;
        this.level34Stars = level34Stars;
        this.level35Stars = level35Stars;
        this.level36Stars = level36Stars;
        this.level37Stars = level37Stars;
        this.level38Stars = level38Stars;
        this.level39Stars = level39Stars;
        this.level40Stars = level40Stars;
        this.level41Stars = level41Stars;
        this.level42Stars = level42Stars;
        this.level43Stars = level43Stars;
        this.level44Stars = level44Stars;
        this.level45Stars = level45Stars;
        this.level46Stars = level46Stars;
        this.level47Stars = level47Stars;
        this.level48Stars = level48Stars;
        this.level49Stars = level49Stars;
        this.level50Stars = level50Stars;
    }

    public StarsPerLevel()
    {
        level1Stars = 0;
        level2Stars = 0;
        level3Stars = 0;
        level4Stars = 0;
        level5Stars = 0;
        level6Stars = 0;
        level7Stars = 0;
        level8Stars = 0;
        level9Stars = 0;
        level10Stars = 0;
        level11Stars = 0;
        level12Stars = 0;
        level13Stars = 0;
        level14Stars = 0;
        level15Stars = 0;
        level16Stars = 0;
        level17Stars = 0;
        level18Stars = 0;
        level19Stars = 0;
        level20Stars = 0;
        level21Stars = 0;
        level22Stars = 0;
        level23Stars = 0;
        level24Stars = 0;
        level25Stars = 0;
        level26Stars = 0;
        level27Stars = 0;
        level28Stars = 0;
        level29Stars = 0;
        level30Stars = 0;
        level31Stars = 0;
        level32Stars = 0;
        level33Stars = 0;
        level34Stars = 0;
        level35Stars = 0;
        level36Stars = 0;
        level37Stars = 0;
        level38Stars = 0;
        level39Stars = 0;
        level40Stars = 0;
        level41Stars = 0;
        level42Stars = 0;
        level43Stars = 0;
        level44Stars = 0;
        level45Stars = 0;
        level46Stars = 0;
        level47Stars = 0;
        level48Stars = 0;
        level49Stars = 0;
        level50Stars = 0;
    }

}

[SerializeField]
public class TimeLevelCompleted
{
    public float level1Time;
    public float level2Time;
    public float level3Time;
    public float level4Time;
    public float level5Time;
    public float level6Time;
    public float level7Time;
    public float level8Time;
    public float level9Time;
    public float level10Time;
    public float level11Time;
    public float level12Time;
    public float level13Time;
    public float level14Time;
    public float level15Time;
    public float level16Time;
    public float level17Time;
    public float level18Time;
    public float level19Time;
    public float level20Time;
    public float level21Time;
    public float level22Time;
    public float level23Time;
    public float level24Time;
    public float level25Time;
    public float level26Time;
    public float level27Time;
    public float level28Time;
    public float level29Time;
    public float level30Time;
    public float level31Time;
    public float level32Time;
    public float level33Time;
    public float level34Time;
    public float level35Time;
    public float level36Time;
    public float level37Time;
    public float level38Time;
    public float level39Time;
    public float level40Time;
    public float level41Time;
    public float level42Time;
    public float level43Time;
    public float level44Time;
    public float level45Time;
    public float level46Time;
    public float level47Time;
    public float level48Time;
    public float level49Time;
    public float level50Time;

    public TimeLevelCompleted(float level1Time, float level2Time, float level3Time, float level4Time, float level5Time, float level6Time, float level7Time,
        float level8Time, float level9Time, float level10Time, float level11Time, float level12Time, float level13Time, float level14Time, float level15Time,
        float level16Time, float level17Time, float level18Time, float level19Time, float level20Time, float level21Time, float level22Time,
        float level23Time, float level24Time, float level25Time, float level26Time, float level27Time, float level28Time, float level29Time,
        float level30Time, float level31Time, float level32Time, float level33Time, float level34Time, float level35Time, 
        float level36Time, float level37Time, float level38Time, float level39Time, float level40Time, float level41Time, 
        float level42Time, float level43Time, float level44Time, float level45Time, float level46Time, float level47Time, 
        float level48Time, float level49Time, float level50Time)
    {
        this.level1Time = level1Time;
        this.level2Time = level2Time;
        this.level3Time = level3Time;
        this.level4Time = level4Time;
        this.level5Time = level5Time;
        this.level6Time = level6Time;
        this.level7Time = level7Time;
        this.level8Time = level8Time;
        this.level9Time = level9Time;
        this.level10Time = level10Time;
        this.level11Time = level11Time;
        this.level12Time = level12Time;
        this.level13Time = level13Time;
        this.level14Time = level14Time;
        this.level15Time = level15Time;
        this.level16Time = level16Time;
        this.level17Time = level17Time;
        this.level18Time = level18Time;
        this.level19Time = level19Time;
        this.level20Time = level20Time;
        this.level21Time = level21Time;
        this.level22Time = level22Time;
        this.level23Time = level23Time;
        this.level24Time = level24Time;
        this.level25Time = level25Time;
        this.level26Time = level26Time;
        this.level27Time = level27Time;
        this.level28Time = level28Time;
        this.level29Time = level29Time;
        this.level30Time = level30Time;
        this.level31Time = level31Time;
        this.level32Time = level32Time;
        this.level33Time = level33Time;
        this.level34Time = level34Time;
        this.level35Time = level35Time;
        this.level36Time = level36Time;
        this.level37Time = level37Time;
        this.level38Time = level38Time;
        this.level39Time = level39Time;
        this.level40Time = level40Time;
        this.level41Time = level41Time;
        this.level42Time = level42Time;
        this.level43Time = level43Time;
        this.level44Time = level44Time;
        this.level45Time = level45Time;
        this.level46Time = level46Time;
        this.level47Time = level47Time;
        this.level48Time = level48Time;
        this.level49Time = level49Time;
        this.level50Time = level50Time;
    }

    // 111111 is a very high number that is set as the default value.
    // nullables caused problems with saving.
    public TimeLevelCompleted()
    {
        level1Time = 111111;
        level2Time = 111111;
        level3Time = 111111;
        level4Time = 111111;
        level5Time = 111111;
        level6Time = 111111;
        level7Time = 111111;
        level8Time = 111111;
        level9Time = 111111;
        level10Time = 111111;
        level11Time = 111111;
        level12Time = 111111;
        level13Time = 111111;
        level14Time = 111111;
        level15Time = 111111;
        level16Time = 111111;
        level17Time = 111111;
        level18Time = 111111;
        level19Time = 111111;
        level20Time = 111111;
        level21Time = 111111;
        level22Time = 111111;
        level23Time = 111111;
        level24Time = 111111;
        level25Time = 111111;
        level26Time = 111111;
        level27Time = 111111;
        level28Time = 111111;
        level29Time = 111111;
        level30Time = 111111;
        level31Time = 111111;
        level32Time = 111111;
        level33Time = 111111;
        level34Time = 111111;
        level35Time = 111111;
        level36Time = 111111;
        level37Time = 111111;
        level38Time = 111111;
        level39Time = 111111;
        level40Time = 111111;
        level41Time = 111111;
        level42Time = 111111;
        level43Time = 111111;
        level44Time = 111111;
        level45Time = 111111;
        level46Time = 111111;
        level47Time = 111111;
        level48Time = 111111;
        level49Time = 111111;
        level50Time = 111111;
    }

}
    

