using UnityEngine;
using TMPro; // 📌 NUEVO: Permite al código controlar el texto de TextMeshPro

public class HongoContador2 : MonoBehaviour
{
    // 📌 NUEVO: Variables compartidas para todos los hongos
    public static int hongosAgarrados = 0;
    public static int totalHongosEnNivel = 3; // Pon aquí el número total de hongos que vas a colocar

    // Arrastra aquí tu objeto "TextoContador" en el Inspector
    public TextMeshProUGUI textoInterfaz;

    private void Start()
    {
        hongosAgarrados = 0;
        // Al iniciar el juego, nos aseguramos de que el texto muestre 0/3 (o el total que pongas)
        ActualizarTexto();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // 1. Sumamos un hongo al contador global
            hongosAgarrados++;

            // 2. Actualizamos el texto en la pantalla
            ActualizarTexto();

            // 3. Hacemos desaparecer este hongo
            Destroy(gameObject);
        }
    }

    // Método auxiliar para cambiar el texto en pantalla
    private void ActualizarTexto()
    {
        if (textoInterfaz != null)
        {
            textoInterfaz.text = hongosAgarrados + "/" + totalHongosEnNivel;
        }
    }
}
