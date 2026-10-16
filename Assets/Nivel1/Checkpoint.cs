using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si lo que entró en el trigger es el jugador
        if (other.CompareTag("Player"))
        {
            // Busca el script de control del jugador y actualiza el checkpoint
            PlayerHealth player = other.GetComponent<PlayerHealth>();
            if (player != null)
            {
                player.ActualizarCheckpoint(transform.position);
                Debug.Log("¡Checkpoint guardado!");
            }
        }
    }
}
