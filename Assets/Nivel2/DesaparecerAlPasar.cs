using UnityEngine;

public class DesaparecerAlPasar : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D otro)
    {
        // Solo reacciona cuando toca al jugador
        if (otro.CompareTag("Player"))
        {
            // Desaparece al pasar
            gameObject.SetActive(false);
        }
    }
}