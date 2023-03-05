using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuHandler : MonoBehaviour
{
    private ScoreKeeper scoreKeeper;
    private Button startButton, clearButton, exitButton;
    private TMP_InputField inputField;

    private void Awake()
    {
        scoreKeeper = GameObject.FindGameObjectWithTag("SK").GetComponent<ScoreKeeper>();
        
        Button[] buttons = GetComponentsInChildren<Button>();
        startButton = buttons[0];
        clearButton = buttons[1];
        exitButton = buttons[2];

        startButton.onClick.AddListener(OpenNamingMenu);
        clearButton.onClick.AddListener(ClearHighScore);
        exitButton.onClick.AddListener(ExitGame);

        inputField = GetComponentInChildren<TMP_InputField>();
        inputField.onEndEdit.AddListener(StartGame);
        inputField.transform.parent.gameObject.SetActive(false);

    }

    private void OpenNamingMenu()
    {
        inputField.transform.parent.gameObject.SetActive(true);
    }

    private void ClearHighScore()
    {
        scoreKeeper.ClearHighScore();
    }

    private void StartGame(string arg0)
    {
        scoreKeeper.SetPlayerName(arg0);
        SceneManager.LoadScene(1);
    }


    private void ExitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }

}
