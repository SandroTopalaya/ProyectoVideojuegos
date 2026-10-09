using UnityEngine;
using TMPro;
using UnityEngine.Video;

public class EsferasManager : MonoBehaviour
{
    public static EsferasManager instancia;

    public TextMeshProUGUI textoContador;
    public int totalEsferas = 7;

    public GameObject pantallaFinal;
    public VideoPlayer videoFinal;
    public AudioSource musicaFondo;

    private int esferasRecogidas = 0;
    private bool finalIniciado = false;

    private void Awake()
    {
        instancia = this;
        esferasRecogidas = 0;
        finalIniciado = false;
    }

    private void Start()
    {
        if (pantallaFinal != null)
            pantallaFinal.SetActive(false);

        if (videoFinal != null)
            videoFinal.playOnAwake = false;

        ActualizarContador();
    }

    public void RecogerEsfera()
    {
        if (finalIniciado || esferasRecogidas >= totalEsferas)
            return;

        esferasRecogidas++;
        ActualizarContador();

        if (esferasRecogidas >= totalEsferas)
            ReproducirFinal();
    }

    private void ActualizarContador()
    {
        if (textoContador != null)
            textoContador.text =
                "Esferas: " + esferasRecogidas + "/" + totalEsferas;
    }

    private void ReproducirFinal()
{
finalIniciado = true;

// Detener todos los sonidos del juego.
foreach (AudioSource audio in FindObjectsByType<AudioSource>(FindObjectsSortMode.None))
{
    if (audio != null)
        audio.Stop();
}

// Desactivar el movimiento del personaje.
GameObject jugador = GameObject.FindGameObjectWithTag("Player");

if (jugador != null)
{
    Movement movimiento = jugador.GetComponent<Movement>();

    if (movimiento != null)
        movimiento.enabled = false;

    Rigidbody2D rb = jugador.GetComponent<Rigidbody2D>();

    if (rb != null)
    {
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.simulated = false;
    }
}

// Pausar el juego.
Time.timeScale = 0f;

// Mostrar el video final.
if (pantallaFinal != null)
    pantallaFinal.SetActive(true);

if (videoFinal != null)
{
    videoFinal.playOnAwake = false;
    videoFinal.timeUpdateMode = VideoTimeUpdateMode.UnscaledGameTime;
    videoFinal.Play();
}
else
{
    Debug.LogError("Falta conectar Video Final.");
}

}
}