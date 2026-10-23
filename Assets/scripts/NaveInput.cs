using UnityEngine;
using UnityEngine.InputSystem;

// Reto final — Versión de NaveEquilibrio migrada al New Input System.
// Ya no se usa Input.GetAxisRaw(): la dirección llega desde la acción "Move".
public class NaveInput : MonoBehaviour
{
    public float fuerza = 8f;

    private Rigidbody2D rb;
    private Vector2 movimiento;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnMove(InputValue value)
    {
        movimiento = value.Get<Vector2>();
    }

    void FixedUpdate()
    {
        rb.AddForce(movimiento * fuerza);
    }
}
