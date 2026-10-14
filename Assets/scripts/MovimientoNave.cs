using UnityEngine;

public class MovimientoNave : MonoBehaviour
{
    public float velocidad = 8f;
    public SpriteRenderer spritePropulsor;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Si no se asignó en el Inspector, busca el SpriteRenderer en los hijos
        if (spritePropulsor == null)
        {
            SpriteRenderer[] hijos = GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer sr in hijos)
            {
                if (sr.gameObject != this.gameObject)
                {
                    spritePropulsor = sr;
                    break;
                }
            }
        }
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(h, v).normalized;

        // Mueve la nave con físicas sin importar la versión de Unity
        rb.linearVelocity = dir * velocidad;

        // Cambia el color del propulsor
        if (spritePropulsor != null)
        {
            if (h < -0.1f)
            {
                spritePropulsor.color = Color.red;       // Izquierda
            }
            else if (h > 0.1f)
            {
                spritePropulsor.color = Color.blue;      // Derecha
            }
            else if (v > 0.1f)
            {
                spritePropulsor.color = Color.yellow;    // Arriba
            }
            else if (v < -0.1f)
            {
                spritePropulsor.color = new Color(1f, 0.5f, 0f); // Abajo (Naranja)
            }
            else
            {
                spritePropulsor.color = Color.gray;      // Quieto
            }
        }
    }
}