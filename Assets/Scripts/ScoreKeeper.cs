using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private string playerName;
    private int score, BestScore;

    public string PlayerName => playerName;
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Debug.Log($"playerName: {playerName}");
    }

    public void SetPlayerName(string setName)
    {
        playerName = setName;
    }
}
