using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;

    int highScore = 0;

    public BallController ball; // Referencia a la pelota para poder reiniciarla/lanzarla

    //Referencias a los textos UI del marcador
    public TextMeshProUGUI leftScoreText;
    public TextMeshProUGUI rightScoreText;

    // Contadores internos de puntos
    int leftScore = 0;
    int rightScore = 0;
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "Highest Score: " + highScore.ToString();
    }

    // Metodo que suma puntos al jugador de la izquierda y actualiza el marcador.
    // Luego lanza la pelota hacia la izquierda (-1 = izquierda, 1 = derecha)
    public void ScoreLeft()
    {
        leftScore++;
        leftScoreText.text = leftScore.ToString();
        ball.Launch(-1);
        CheckHighScore();
    }

    public void ScoreRight()
    {
        rightScore++;
        rightScoreText.text = rightScore.ToString();
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
