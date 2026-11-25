using UnityEngine;

public class rings : MonoBehaviour
{
    [Header("Configuración de Moneda")]
    [SerializeField] private int valorMoneda = 1; // Configurable desde el Inspector

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // 1. Sumamos el puntaje en el GameManager
            if (GameManager.Instance != null)
            {
                GameManager.Instance.SumarMoneda(valorMoneda);
            }

            // 2. (Aquí conectaremos el sonido SFX en el Paso 8)

            // 3. Destruimos la moneda después de recogerla
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.ReproducirMoneda();
            }
            Destroy(gameObject);
        }
    }
}
