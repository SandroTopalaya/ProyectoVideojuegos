using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private Vector3 posicionCheckpoint;
    private Rigidbody2D rb;

    void Start()
    {
        posicionCheckpoint = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    public void ActualizarCheckpoint(Vector3 nuevaPosicion)
    {
        posicionCheckpoint = nuevaPosicion;
    }

    public void Reaparecer()
    {
        // Regresa al gato a la posición guardada
        transform.position = posicionCheckpoint;

        // Resetea la fuerza física en Unity 6 para que no siga cayendo por inercia
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
        }
    }
}
