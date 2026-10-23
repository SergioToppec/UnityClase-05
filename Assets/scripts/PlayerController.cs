using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movimiento y Salto")]
    [SerializeField] private float velocidad = 8f;
    [SerializeField] private float fuerzaSalto = 12f;

    [Header("Detección de Suelo")]
    [SerializeField] private Transform detectorSuelo;
    [SerializeField] private float radioDeteccion = 0.2f;
    [SerializeField] private LayerMask capaSuelo;

    private Rigidbody2D rb;
    private Vector2 puntoRespawn;
    private bool enSuelo;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        puntoRespawn = transform.position;
    }

    void Update()
    {
        enSuelo = Physics2D.OverlapCircle(detectorSuelo.position, radioDeteccion, capaSuelo);

        if (Input.GetButtonDown("Jump") && enSuelo)
        {
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(horizontal * velocidad, rb.linearVelocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Checkpoint"))
        {
            puntoRespawn = collision.transform.position;
            Debug.Log("Checkpoint alcanzado: " + puntoRespawn);
        }
        else if (collision.CompareTag("ZonaMuerte"))
        {
            Reaparecer();
        }
        else if (collision.CompareTag("Peligro"))
        {
            GameManager.Instancia.MostrarGameOver();
        }
        else if (collision.CompareTag("Meta"))
        {
            GameManager.Instancia.MostrarVictoria();
        }
    }
    public void Reaparecer()
    {
        transform.position = puntoRespawn;
        rb.linearVelocity = Vector2.zero;
    }
    private void OnDrawGizmosSelected()
    {
        if (detectorSuelo != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(detectorSuelo.position, radioDeteccion);
        }
    }
}

