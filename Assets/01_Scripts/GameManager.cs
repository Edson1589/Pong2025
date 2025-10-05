using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Texto para mostrar la puntuacion mas alta
    public TextMeshProUGUI highScoreText;

    int highScore = 0;

    public BallController ball; // Referencia a la pelota para poder reiniciarla/lanzarla

    // Referencias a los textos UI del marcador
    public TextMeshProUGUI leftScoreText;
    public TextMeshProUGUI rightScoreText;

    // Contadores internos de puntos
    int leftScore = 0;
    int rightScore = 0;

    // Para el sonido al hacer un punto
    public AudioSource sfxAS;
    public AudioClip pingSFX;
    void Start()
    {
        // Cargar la puntuaci�n m�s alta guardada (0 si no existe)
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "Puntaje Máximo: " + highScore.ToString();

        // Inicializar los textos del marcador
        leftScoreText.text = leftScore.ToString();
        rightScoreText.text = rightScore.ToString();
    }

    // Método que suma puntos al jugador de la izquierda
    public void ScoreLeft()
    {
        sfxAS.PlayOneShot(pingSFX);
        leftScore++;
        leftScoreText.text = leftScore.ToString();
        CheckHighScore(leftScore); // Verifica si hay nuevo r�cord
        ball.Launch(-1);
    }

    // Método que suma puntos al jugador de la derecha
    public void ScoreRight()
    {
        sfxAS.PlayOneShot(pingSFX);
        rightScore++;
        rightScoreText.text = rightScore.ToString();
        CheckHighScore(rightScore); // Verifica si hay nuevo r�cord
        ball.Launch(1);
    }

    // Verifica si hay nuevo récord y lo actualiza
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
