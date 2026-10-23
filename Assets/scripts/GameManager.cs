using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instancia { get; private set; }

    [Header("UI")]
    [SerializeField] private GameObject panelGameOver;
    [SerializeField] private GameObject panelVictoria;

    void Awake()
    {
        if (Instancia == null)
        {
            Instancia = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void MostrarGameOver()
    {
        Time.timeScale = 0f; // Congela el juego
        if (panelGameOver != null)
        {
            panelGameOver.SetActive(true);
        }
    }

    public void MostrarVictoria() // <-- NUEVO
    {
        Time.timeScale = 0f;
        if (panelVictoria != null) panelVictoria.SetActive(true);
    }

    public void ReiniciarNivel()
    {
        Time.timeScale = 1f; // Obligatorio: reactivar el tiempo antes de recargar
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}