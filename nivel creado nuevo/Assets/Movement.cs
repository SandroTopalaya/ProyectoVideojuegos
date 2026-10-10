using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 8f;

    [Header("Animaciones")]
    public Sprite[] parado;
    public Sprite[] caminando;
    public Sprite[] saltando;
    public float velocidadAnim = 0.1f;

    private Rigidbody2D rb;
    private SpriteRenderer dibujo;
    private float temporizador;
    private int cuadro;
    private float moveX;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dibujo = GetComponent<SpriteRenderer>();

        // ✅ TAMAÑO FIJO IGUAL QUE EN LA IMAGEN: NO CAMBIA NUNCA
        transform.localScale = new Vector3(0.4121f, 0.4121f, 1f);
    }

    void Update()
    {
        moveX = Input.GetAxis("Horizontal");

        // Girar manteniendo el mismo tamaño
        if (moveX > 0.1f) transform.localScale = new Vector3(0.4121f, 0.4121f, 1f);
        if (moveX < -0.1f) transform.localScale = new Vector3(-0.4121f, 0.4121f, 1f);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
        }

        temporizador += Time.deltaTime;
        if (temporizador >= velocidadAnim)
        {
            temporizador = 0;
            cuadro++;

            if (!isGrounded)
            {
                if (saltando.Length > 0)
                {
                    if (cuadro >= saltando.Length) cuadro = 0;
                    dibujo.sprite = saltando[cuadro];
                }
            }
            else if (Mathf.Abs(moveX) > 0.1f)
            {
                if (caminando.Length > 0)
                {
                    if (cuadro >= caminando.Length) cuadro = 0;
                    dibujo.sprite = caminando[cuadro];
                }
            }
            else
            {
                if (parado.Length > 0)
                {
                    if (cuadro >= parado.Length) cuadro = 0;
                    dibujo.sprite = parado[cuadro];
                }
            }
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveX * speed, rb.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;

        if (collision.gameObject.CompareTag("Enemigo"))
        {
            float alturaJugador = transform.position.y;
            float alturaEnemigo = collision.gameObject.transform.position.y;

            if (alturaJugador > alturaEnemigo + 0.05f)
            {
                collision.gameObject.SendMessage("Morir");
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 4f);
            }
            else
            {
                transform.position = new Vector3(-8.246f, 0.82f, 0f);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo") ||
            collision.gameObject.CompareTag("Tumba") ||
            collision.gameObject.CompareTag("Enemigo"))
        {
            isGrounded = false;
        }
    }
}