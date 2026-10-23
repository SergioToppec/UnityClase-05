using UnityEngine;
using UnityEngine.InputSystem;

// Alterna el color del sprite entre blanco y rojo con la acción "ChangeColor" (tecla C).
public class CambioColorInput : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private bool colorAlternativo;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnChangeColor(InputValue value)
    {
        if (!value.isPressed)
        {
            return;
        }

        colorAlternativo = !colorAlternativo;

        spriteRenderer.color = colorAlternativo
            ? Color.red
            : Color.white;
    }
}
