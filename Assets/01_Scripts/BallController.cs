using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class BallController : MonoBehaviour
{
    [Header("Controles")]
    public float speed = 12f; // Velocidad de la pelota
    Rigidbody2D rb; // referencia al cuerpo fisico de la pelota
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtiene el Rigidbody 2d
        Launch(); // Saque Inicial
    }

    // Metodo para lanzar la pelota desde el centro; si dir = 0, escoge izquierda o derecha al azar
    public void Launch(int dir = 0)
    {
        transform.position = Vector3.zero; // Reinicia posicion al centro

        float x = dir != 0 ? dir : (Random.value < 0.5f ? -1f : 1f); // -1 = izquierda, 1 = derecha
        float y = Random.Range(-0.6f, 0.6f); // Pequeña variacion vertical

        rb.velocity = new Vector2(x, y).normalized * speed; // Aplica velocidad con magnitud fija
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Tras cualquier choque (pared/raqueta), normaliza para mantener la misma rapidez
        rb.velocity = rb.velocity.normalized * speed;
    }
}
