using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class DataController : MonoBehaviour
{
    public RoundData[] allRoundData;
    private PlayerProgress playerProgress;
    private string gameDataFileName = "Questions.json";
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        LoadPlayerProgress();
        LoadGameData();

        SceneManager.LoadScene("MenuScreen");

    }

    public void LoadGameData()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);

        if(File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);

            GameData loadedData = JsonUtility.FromJson<GameData>(dataAsJson);

            allRoundData = loadedData.allRoundData;
        }
        else
        {
            Debug.LogError("Cannot load game data");
        }
    }

    public RoundData GetCurrentRoundData()
    {
        return allRoundData[0];
    }

    public void SubmitNewPlayerScore(int newScore)
    {
        if(newScore>playerProgress.highestScore)
        {
            playerProgress.highestScore = newScore;
            SavePlayerProgress();
        }
    }

    public int GetPlayerHighestScore()
    {
        return playerProgress.highestScore;
    }

    private void LoadPlayerProgress()
    {
        playerProgress = new PlayerProgress();

        if(PlayerPrefs.HasKey("highestScore"))
        {
            playerProgress.highestScore = PlayerPrefs.GetInt("highestScore");
        }
    }

    private void SavePlayerProgress()
    {
        PlayerPrefs.SetInt("highestScore", playerProgress.highestScore);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
