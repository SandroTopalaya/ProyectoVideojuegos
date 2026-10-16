using UnityEngine;

public class Camera3 : MonoBehaviour
{
    public Transform personaje;
    public float suavizado = 5f;
    private float distanciaZ = -10f;

    // 📌 NUEVO: Variables para controlar los límites de la pantalla
    [Header("Límites del Nivel")]
    public float minX; // Límite izquierdo
    public float maxX; // Límite derecho
    public float minY; // Límite inferior
    public float maxY; // Límite superior

    void LateUpdate()
    {
        if (personaje != null)
        {
            // 1. Calculamos la posición del gato
            float objetivoX = personaje.position.x;
            float objetivoY = personaje.position.y;

            // 2. 📌 CLAVE: Limitamos la posición para que no se salga de los bordes
            objetivoX = Mathf.Clamp(objetivoX, minX, maxX);
            objetivoY = Mathf.Clamp(objetivoY, minY, maxY);

            // 3. Movemos la cámara de forma suave
            Vector3 posicionObjetivo = new Vector3(objetivoX, objetivoY, distanciaZ);
            transform.position = Vector3.Lerp(transform.position, posicionObjetivo, suavizado * Time.deltaTime);
        }
    }
}
