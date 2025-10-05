using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI score;

    public string menuSceneName = "MainMenu";
    public string gameSceneName = "GameScenePong";

    void Start()
    {
        title.text = $"¡Ganó {GameSession.Winner}!";
        score.text = $"{GameSession.LeftScore} — {GameSession.RightScore}";
    }

    public void OnRestart()
    {
        GameSession.Reset();
        SceneManager.LoadScene(gameSceneName);
    }

    public void OnMenu()
    {
        GameSession.Reset();
        SceneManager.LoadScene(menuSceneName);
    }
}
