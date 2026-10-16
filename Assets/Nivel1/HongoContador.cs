using UnityEngine;

public class HongoContador : MonoBehaviour
{
    // Variables globales estáticas comunes para todo el juego
    public static int hongosAgarrados = 0;
    public static int totalHongosEnNivel = 3;

    private HUDManager hudManager;

    private void Start()
    {
        // Buscamos el UIManager permanente en la escena actual
        hudManager = Object.FindAnyObjectByType<HUDManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            hongosAgarrados++;

            // Le ordenamos al HUDManager permanente que actualice la interfaz
            if (hudManager != null)
            {
                hudManager.ActualizarTextoHongos(hongosAgarrados, totalHongosEnNivel);
            }

            Destroy(gameObject);
        }
    }
}
