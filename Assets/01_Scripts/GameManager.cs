using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;

    int highScore = 0;

    public BallController ball; // Referencia a la pelota para poder reiniciarla/lanzarla

    // Referencias a los textos UI del marcador
    public TextMeshProUGUI leftScoreText;
    public TextMeshProUGUI rightScoreText;
    public TextMeshProUGUI highScoreText; // Nuevo texto para mostrar la mejor puntuación

    // Contadores internos de puntos
    int leftScore = 0;
    int rightScore = 0;
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "Highest Score: " + highScore.ToString();
    }

    void Start()
    {
        // Cargar la puntuación más alta guardada (0 si no existe)
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore.ToString();

        // Inicializar los textos del marcador
        leftScoreText.text = leftScore.ToString();
        rightScoreText.text = rightScore.ToString();
    }

    // Método que suma puntos al jugador de la izquierda
    public void ScoreLeft()
    {
        leftScore++;
        leftScoreText.text = leftScore.ToString();
        CheckHighScore(leftScore); // Verifica si hay nuevo récord
        ball.Launch(-1);
        CheckHighScore();
    }

    public void ScoreRight()
    {
        rightScore++;
        rightScoreText.text = rightScore.ToString();
        CheckHighScore(rightScore); // Verifica si hay nuevo récord
        ball.Launch(1);
        CheckHighScore();
    }

    void CheckHighScore()
    {
        int currentScore = Mathf.Max(leftScore, rightScore);
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            highScoreText.text = "Puntaje Máximo: " + highScore.ToString();
        }
    }

}
