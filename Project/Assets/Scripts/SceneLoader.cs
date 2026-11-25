using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void CargarEscena(string nombreEscena)
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.ReproducirClickUI();
        }

        SceneManager.LoadScene(nombreEscena);
    }

    public void SalirDelJuego()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.ReproducirClickUI();
        }

        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}