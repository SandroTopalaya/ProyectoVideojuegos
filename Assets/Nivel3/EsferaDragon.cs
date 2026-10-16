
using UnityEngine;

public class EsferaDragon : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (EsferasManager.instancia != null)
            {
                EsferasManager.instancia.RecogerEsfera();
            }

            Destroy(gameObject);
            Debug.Log("¡Esfera recogida!");
        }
    }
}
