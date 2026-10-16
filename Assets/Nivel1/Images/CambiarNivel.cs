using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarNivel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) // Usa OnTriggerEnter si tu juego es 3D
    {
        // Verifica si el objeto que toca la meta es el jugador (asegúrate de que tu personaje tenga el Tag "Player")
        if (other.CompareTag("Player"))
        {
            int escenaActual = SceneManager.GetActiveScene().buildIndex;
            int siguienteEscena = escenaActual + 1;

            // Si hay más niveles en el Build Profiles, los carga
            if (siguienteEscena < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(siguienteEscena);
            }
            else
            {
                Debug.Log("¡Juego completado!");
            }
        }
    }
}