using UnityEngine;

public class CambioColor : MonoBehaviour
{
    [SerializeField]
    private Color[] colores = new Color[]
    {
        Color.white,
        Color.cyan,
        Color.magenta,
        Color.yellow,
        Color.green
    };

    private SpriteRenderer spriteRenderer;
    private int indiceActual = 0;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            indiceActual = (indiceActual + 1) % colores.Length;
            spriteRenderer.color = colores[indiceActual];
        }
    }
}