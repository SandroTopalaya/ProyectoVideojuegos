using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Buscamos el nuevo script de vidas en el jugador
            PlayerLives playerLives = other.GetComponent<PlayerLives>();

            if (playerLives != null)
            {
                playerLives.RestarVida();
            }
            else
            {
                Debug.LogError("El jugador no tiene el script PlayerLives asignado.");
            }
        }
    }
}
