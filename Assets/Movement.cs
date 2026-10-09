using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 8f;

    // Se llena en el paso siguiente (forma SSJ)
    public RuntimeAnimatorController controllerSSJ;


    public AudioClip sonidoTransformacion;
    private AudioSource audioSource;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;
    private float moveX;
    private bool isGrounded;
    private bool transformando;
    private bool esSSJ;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Durante la transformación no se mueve ni salta
        if (transformando)
        {
            moveX = 0;
            return;
        }

        moveX = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
        }

        // Transformarse con la tecla T
       if (Input.GetKeyDown(KeyCode.T) && isGrounded && !esSSJ)
{
    transformando = true;
    moveX = 0;
    anim.SetFloat("Speed", 0);
    if (sonidoTransformacion != null)
        audioSource.PlayOneShot(sonidoTransformacion);
    anim.SetTrigger("Transformar");
    return;
}

        anim.SetFloat("Speed", Mathf.Abs(moveX));
        anim.SetBool("Grounded", isGrounded);

        if (moveX > 0.01f) sr.flipX = false;
        else if (moveX < -0.01f) sr.flipX = true;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveX * speed, rb.linearVelocity.y);
    }

    // Se llama desde un Animation Event al final del clip Goku_Transform
    public void TerminarTransformacion()
    {
        esSSJ = true;
        transformando = false;
        if (controllerSSJ != null)
            anim.runtimeAnimatorController = controllerSSJ;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.GetContact(0).normal.y > 0.5f)
            isGrounded = true;
    }
}