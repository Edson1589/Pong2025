using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketController : MonoBehaviour
{
    [Header("Controles")]
    public KeyCode upKey = KeyCode.W; // Tecla para mover hacia arriba (W - Up Arrow)
    public KeyCode downKey = KeyCode.S; // Tecla para mover hacia abajo (S - Down Arrow)

    [Header("Movimiento")]
    public float speed = 50f; // Velocidad de movimiento de la raqueta
    public float margin = 0.5f; // Margen para no salirse de la pantalla

    Rigidbody2D rb; // Referncia al cuerpo fisico de la raqueta
    Camera cam; // Referencia a la camara principal
    float halfHeight; // Mitad de la altura del sprite (para calcular limites)

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtiene el Rigidbody 2d
        cam = Camera.main; // Obtiene la camara principal
        halfHeight = GetComponent<SpriteRenderer>().bounds.extents.y; // Calcula mitad de la altura del sprite
    }

    void Update()
    {
        float move = 0f; // Variable para guardar el movimiento vertical

        // Detecta si se presiona la tecla de arriba o abajo
        if (Input.GetKey(upKey)) move = 1f;
        if (Input.GetKey(downKey)) move = -1f;

        // Calcula la nueva posicion de la raqueta
        Vector2 pos = rb.position + Vector2.up * (move * speed * Time.deltaTime);

        // Calcula el limite superior e inferior segun la camara
        float limit = cam.orthographicSize - halfHeight - margin;

        // Limita la posicion de la raqueta dentro de la pantalla
        pos.y = Mathf.Clamp(pos.y, -limit, limit);

        // Mueve la raqueta a la nueva posicion
        rb.MovePosition(pos);
    }
}

