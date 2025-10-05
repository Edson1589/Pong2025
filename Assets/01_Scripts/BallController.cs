using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class BallController : MonoBehaviour
{
    [Header("Controles")]
    public float speed = 12f; // Velocidad de la pelota
    public float baseSpeed; // Velocidad inicial para reiniciar
    Rigidbody2D rb; // referencia al cuerpo fisico de la pelota
    void Start()
    {
        baseSpeed = speed; // Guardar la velocidad base al iniciar
        rb = GetComponent<Rigidbody2D>(); // Obtiene el Rigidbody 2d
        Launch(); // Saque Inicial
    }

    // Metodo para incrementar la velocidad de la pelota
    public void IncreaseSpeed(float amount = 1f)
    {
        speed += amount;
        rb.velocity = rb.velocity.normalized * speed;
    }

    // Metodo para reiniciar la velocidad de la pelota si se anota un punto
    public void ResetSpeed()
    {
        speed = baseSpeed;
        rb.velocity = rb.velocity.normalized * speed;
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

        // Si colisiona con la raqueta sube la velocidad de la pelota
        if (collision.collider.CompareTag("Racket"))
        {
            IncreaseSpeed(1f);
        }
    }
}
