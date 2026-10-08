using UnityEngine;



public class Movement : MonoBehaviour

{

    public float speed = 5f;

    public float jumpForce = 8f;



    private Rigidbody2D rb;

    private float moveX;

    private bool isGrounded; // Te dice si está en el suelo



    void Start()

    {

        rb = GetComponent<Rigidbody2D>();

    }



    void Update()

    {

        // Leer teclas (Izquierda/Derecha o A/D)

        moveX = Input.GetAxis("Horizontal");



        // Saltar con barra espaciadora si está tocando el suelo

        if (Input.GetButtonDown("Jump") && isGrounded)

        {

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

            isGrounded = false; // Bloquea el salto hasta que vuelva a chocar

        }

    }



    void FixedUpdate()

    {

        // Mover horizontalmente

        rb.linearVelocity = new Vector2(moveX * speed, rb.linearVelocity.y);

    }



    // Detecta automáticamente si el personaje aterriza sobre cualquier colisionador

    private void OnCollisionEnter2D(Collision2D collision)

    {

        isGrounded = true;

    }

}