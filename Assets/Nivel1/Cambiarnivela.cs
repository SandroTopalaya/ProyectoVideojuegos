using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarNivela : MonoBehaviour
{
    private void Start()
    {
        // 📌 REGLA DE ORO: Cada vez que empiece un nivel, el contador de la meta se limpia a 0
        HongoContador.hongosAgarrados = 0;

        // Buscamos el HUDManager permanente de la pantalla y lo obligamos a ponerse en 0/3
        HUDManager hudManager = Object.FindAnyObjectByType<HUDManager>();
        if (hudManager != null)
        {
            hudManager.ActualizarTextoHongos(0, HongoContador.totalHongosEnNivel);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (HongoContador.hongosAgarrados >= HongoContador.totalHongosEnNivel)
            {
                int escenaActual = SceneManager.GetActiveScene().buildIndex;
                int siguienteEscena = escenaActual + 1;

                if (siguienteEscena < SceneManager.sceneCountInBuildSettings)
                {
                    SceneManager.LoadScene(siguienteEscena);
                }
                else
                {
                    Debug.Log("¡Juego completado!");
                }
            }
            else
            {
                Debug.LogWarning("No puedes pasar todavía. Te faltan hongos por recolectar.");
            }
        }
    }
}
