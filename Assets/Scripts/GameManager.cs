using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData
{
    public int lastLevel;
    public bool secretLevel;
}

public class GameManager : MonoBehaviour
{
    PlayerData playerData;
    public static GameManager Instance;
    string saveFilePath;

    public int lastLevel = 1;
    public bool secretLevel = false;
    public bool didLose = false;

    public void SaveGame()
    {
        playerData = new PlayerData();
        playerData.lastLevel = lastLevel;
        playerData.secretLevel = secretLevel;

        saveFilePath = Application.persistentDataPath + "/PlayerData";
        string savePlayerData = JsonUtility.ToJson(playerData);
        File.WriteAllText(saveFilePath, savePlayerData);
    }

    public void LoadGame()
    {
        if (File.Exists(saveFilePath))
        {
            string loadPlayerData = File.ReadAllText(saveFilePath);
            playerData = JsonUtility.FromJson<PlayerData>(loadPlayerData);

            lastLevel = playerData.lastLevel;
            secretLevel = playerData.secretLevel;
        }
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadGame();
    }
}



