using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    //NESTED CLASS FOR SAVING
    [Serializable]
    public class SaveData
    {
        public string name;
        public int score;
        public SaveData(string name,int score)
        {
            this.name = name;
            this.score = score;
        }
    }

    private static ScoreKeeper instance;
    [SerializeField]private string playerName,bestPlayerName;
    private int bestScore;

    public string PlayerName => playerName;
    public string BestPlayerName => bestPlayerName;
    public int BestScore => bestScore;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }
    // Start is called before the first frame update
    void Start()
    {

        bestPlayerName = "-";
        bestScore = 0;
        Load();

        DontDestroyOnLoad(gameObject);
    }

    public void SetPlayerName(string setName)
    {
        playerName = setName;
    }

    public void SetBestPlayerNameAndScore(string setName, int best)
    {
        bestPlayerName = setName;
        bestScore = best;

        //saves the file
        Save(setName, best);
        
    }

    public void ClearHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = JsonUtility.ToJson(new SaveData("-", 0));
            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }

        bestPlayerName = "-";
        bestScore = 0;

    }

    private void Save(string setName,int best)
    {
        string json = JsonUtility.ToJson(new SaveData(setName, best));
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    private void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            SaveData data = JsonUtility.FromJson<SaveData>(json);
            bestPlayerName = data.name;
            bestScore = data.score;
        }
    }
}
