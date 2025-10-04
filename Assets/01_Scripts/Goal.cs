using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    // Variable booleana para diferenciar entre los arcos izquierdo y derecho
    public bool isLeft;

    // Referencia al GameManager para sumar puntos
    public GameManager gm;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Asegura que solo reaccionamos a la pelota
        if (!other.CompareTag("Ball")) return;

        // Si es el arco izquierdo, anota punto el jugador derecho; si no, anota el izquierdo
        if (isLeft) gm.ScoreRight();
        else gm.ScoreLeft();
    }
}
