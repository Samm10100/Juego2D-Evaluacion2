using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movimiento y Animación")]
    [SerializeField] private float velocidad = 5f;
    [SerializeField] private Animator animator;

    [Header("Salto y Detección de Suelo")]
    [SerializeField] private float fuerzaSalto = 10f;
    [SerializeField] private float distanciaLineaSuelo = 0.6f; // Ajústalo en el Inspector según el alto de tu personaje
    [SerializeField] private LayerMask capaSuelo;
    [SerializeField] private bool tocandoElSuelo;

    private Rigidbody2D rb;
    private float inputHorizontal;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 1. Leer entrada horizontal (-1 izquierda, 0 quieto, 1 derecha)
        inputHorizontal = Input.GetAxisRaw("Horizontal");

        // 2. Actualizar animación (Mathf.Abs asegura valor positivo al ir a la izquierda)
        if (animator != null)
        {
            animator.SetFloat("isMove", Mathf.Abs(inputHorizontal));
        }

        // 3. Girar el personaje según la dirección
        if (inputHorizontal > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (inputHorizontal < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // 4. Detectar suelo con Raycast hacia abajo
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distanciaLineaSuelo, capaSuelo);
        tocandoElSuelo = hit.collider != null;

        // 5. Saltar solo si está tocando el suelo
        if (Input.GetKeyDown(KeyCode.Space) && tocandoElSuelo)
        {
            // Reiniciamos velocidad vertical para que el salto siempre tenga la misma altura
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            rb.AddForce(new Vector2(0, fuerzaSalto), ForceMode2D.Impulse);

            // Reproduce el sonido de salto
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.ReproducirSalto();
            }
        }
    }

    void FixedUpdate()
    {
        // Aplicamos el movimiento horizontal usando físicas (Unity 6)
        rb.linearVelocity = new Vector2(inputHorizontal * velocidad, rb.linearVelocity.y);
    }

    // Dibuja la línea roja en la ventana Scene para calibrar 'distanciaLineaSuelo'
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * distanciaLineaSuelo);
    }
}