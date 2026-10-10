using UnityEngine;

public class VillanoAnimacion : MonoBehaviour
{
    [Header("Animación")]
    public Sprite[] parado;      // imágenes "Idle"
    public Sprite[] caminando;   // imágenes "Walk"
    public Sprite[] muriendo;    // imágenes "Dead"
    public float velocidadCambio = 0.12f;

    private SpriteRenderer dibujo;
    private int cuadroActual;
    private float temporizador;
    private bool estaVivo = true;

    void Start()
    {
        dibujo = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!estaVivo) return;

        temporizador += Time.deltaTime;
        if (temporizador >= velocidadCambio)
        {
            temporizador = 0;
            cuadroActual++;

            // Se anima en su lugar con las de caminar
            if (caminando.Length > 0)
            {
                if (cuadroActual >= caminando.Length)
                    cuadroActual = 0;

                dibujo.sprite = caminando[cuadroActual];
            }
            // Si no hay de caminar, usa las de estar parado
            else if (parado.Length > 0)
            {
                if (cuadroActual >= parado.Length)
                    cuadroActual = 0;

                dibujo.sprite = parado[cuadroActual];
            }
        }
    }

    public void Morir()
    {
        estaVivo = false;

        // Reproducir animación de muerte
        if (muriendo.Length > 0)
        {
            dibujo.sprite = muriendo[0];
            // Aquí puedes poner secuencia de muerte si quieres
        }
    }
}