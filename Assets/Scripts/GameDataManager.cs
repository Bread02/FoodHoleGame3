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
    #endregion

    #region Set Time Per Level
    public void SetLevel1Time(float time)
    {
        timeLevelCompleted1.level1Time = time;
        Debug.Log(time + " Game Data Manager saving this time");
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

    #endregion

    #region Return Time Per Level

    public float ReturnLevel1Time()
    {
        return timeLevelCompleted1.level1Time;
    }

    public float ReturnLevel2Time()
    {
        return timeLevelCompleted1.level2Time;
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

        public UnlockedLevels(bool level2Unlocked, bool level3Unlocked, bool level4Unlocked, bool level5Unlocked,
            bool level6Unlocked, bool level7Unlocked, bool level8Unlocked, bool level9Unlocked, bool level10Unlocked,
            bool level11Unlocked, bool level12Unlocked, bool level13Unlocked, bool level14Unlocked, bool level15Unlocked,
            bool level16Unlocked, bool level17Unlocked, bool level18Unlocked, bool level19Unlocked, bool level20Unlocked)
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
    public StarsPerLevel(int level1Stars, int level2Stars, int level3Stars, int level4Stars, int level5Stars, int level6Stars,
        int level7Stars, int level8Stars, int level9Stars, int level10Stars, int level11Stars, int level12Stars, int level13Stars,
        int level14Stars, int level15Stars, int level16Stars, int level17Stars, int level18Stars, int level19Stars, int level20Stars)
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

    public TimeLevelCompleted(float level1Time, float level2Time, float level3Time, float level4Time, float level5Time, float level6Time, float level7Time,
        float level8Time, float level9Time, float level10Time, float level11Time, float level12Time, float level13Time, float level14Time, float level15Time,
        float level16Time, float level17Time, float level18Time, float level19Time, float level20Time)
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
    }

}
    

