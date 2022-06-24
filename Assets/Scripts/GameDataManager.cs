using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]
public class GameDataManager : MonoBehaviour
{
    public static GameDataManager gameDataManagerInstance;

    [SerializeField] UnlockedLevels unlockedLevels;

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
        Debug.Log("Writing to save");
        BinaryFormatter formatter = new BinaryFormatter();
        string filePath = $"{Application.persistentDataPath}/unlockedLevels.save";
        FileStream stream = new FileStream(filePath, FileMode.Create);
        string json = JsonUtility.ToJson(unlockedLevels);
        formatter.Serialize(stream, json);
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
    }

    public void SaveGame()
    {
        Debug.Log("Saving game");
        WriteToSave();
    }
}

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
    

