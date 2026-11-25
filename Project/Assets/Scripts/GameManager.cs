using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI y Puntaje")]
    [SerializeField] private TextMeshProUGUI textoMonedas;
    [SerializeField] private int monedasParaGanar = 5;

    [Header("Escenas")]
    [SerializeField] private string nombreEscenaVictoria = "Victory";
    [SerializeField] private string nombreEscenaDerrota = "GameOver";

    private int monedasActuales = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        ActualizarUI();
    }

    public void SumarMoneda(int cantidad)
    {
        monedasActuales += cantidad;
        ActualizarUI();

        if (monedasActuales >= monedasParaGanar)
        {
            SceneManager.LoadScene(nombreEscenaVictoria);
        }
    }

    public void PerderJuego()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.ReproducirDerrota();
        }

        SceneManager.LoadScene(nombreEscenaDerrota);
    }

    private void ActualizarUI()
    {
        if (textoMonedas != null)
        {
            textoMonedas.text = "Monedas: " + monedasActuales + " / " + monedasParaGanar;
        }
    }
}