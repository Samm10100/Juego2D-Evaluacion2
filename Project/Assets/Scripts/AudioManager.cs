using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Fuentes de Audio")]
    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private AudioSource sfxSource;

    [Header("Clips de Sonido (SFX)")]
    [SerializeField] private AudioClip sfxSalto;
    [SerializeField] private AudioClip sfxMoneda;
    [SerializeField] private AudioClip sfxDerrota;
    [SerializeField] private AudioClip sfxClickUI;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ReproducirSalto()
    {
        if (sfxSalto != null) sfxSource.PlayOneShot(sfxSalto);
    }

    public void ReproducirMoneda()
    {
        if (sfxMoneda != null) sfxSource.PlayOneShot(sfxMoneda);
    }

    public void ReproducirDerrota()
    {
        if (sfxDerrota != null) sfxSource.PlayOneShot(sfxDerrota);
    }

    public void ReproducirClickUI()
    {
        if (sfxClickUI != null) sfxSource.PlayOneShot(sfxClickUI);
    }
}