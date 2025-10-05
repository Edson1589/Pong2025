using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public BallController ball; // Referencia a la pelota para poder reiniciarla/lanzarla

    // Referencias a los textos UI del marcador
    public TextMeshProUGUI leftScoreText;
    public TextMeshProUGUI rightScoreText;
    public TextMeshProUGUI highScoreText; // Nuevo texto para mostrar la mejor puntuaci�n

    // Contadores internos de puntos
    int leftScore = 0;
    int rightScore = 0;
    int highScore = 0; // Puntuaci�n m�s alta guardada

    void Start()
    {
        // Cargar la puntuacion mas alta guardada (0 si no existe)
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore.ToString();

        // Inicializar los textos del marcador
        leftScoreText.text = leftScore.ToString();
        rightScoreText.text = rightScore.ToString();
    }

    // M�todo que suma puntos al jugador de la izquierda
    public void ScoreLeft()
    {
        leftScore++;
        leftScoreText.text = leftScore.ToString();
        CheckHighScore(leftScore); // Verifica si hay nuevo r�cord
        ball.ResetSpeed(); // Reiniciar la velocidad de la pelota
        ball.Launch(-1);
    }

    // M�todo que suma puntos al jugador de la derecha
    public void ScoreRight()
    {
        rightScore++;
        rightScoreText.text = rightScore.ToString();
        CheckHighScore(rightScore); // Verifica si hay nuevo r�cord
        ball.ResetSpeed(); // Reiniciar la velocidad de la pelota
        ball.Launch(1);
    }

    // M�todo para comprobar y guardar la mejor puntuaci�n
    void CheckHighScore(int score)
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore); // Guarda la nueva puntuaci�n m�s alta
            PlayerPrefs.Save();
            highScoreText.text = "High Score: " + highScore.ToString();
        }
    }
}
