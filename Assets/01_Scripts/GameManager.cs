using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public BallController ball; // Referencia a la pelota para poder reiniciarla/lanzarla

    //Referencias a los textos UI del marcador
    public TextMeshProUGUI leftScoreText;
    public TextMeshProUGUI rightScoreText;

    // Contadores internos de puntos
    int leftScore = 0;
    int rightScore = 0;

    // Metodo que suma puntos al jugador de la izquierda y actualiza el marcador.
    // Luego lanza la pelota hacia la izquierda (-1 = izquierda, 1 = derecha)
    public void ScoreLeft()
    {
        leftScore++;
        leftScoreText.text = leftScore.ToString();
        ball.Launch(-1);
    }

    // Metodo que suma puntos al jugador de la derecha y actualiza el marcador.
    // Luego lanza la pelota hacia la derecha (-1 = izquierda, 1 = derecha)
    public void ScoreRight()
    {
        rightScore++;
        rightScoreText.text = rightScore.ToString();
        ball.Launch(1);
    }
}
