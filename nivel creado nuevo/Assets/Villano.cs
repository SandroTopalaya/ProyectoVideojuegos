using UnityEngine;

public class Villano : MonoBehaviour
{
    [Header("Al morir")]
    public GameObject tumba; // Arrastra la tumba aquí

    private VillanoAnimacion animacion;

    void Start()
    {
        animacion = GetComponent<VillanoAnimacion>();
    }

    public void Morir()
    {
        // Reproducir animación de muerte
        if (animacion != null)
            animacion.Morir();

        // Aparecer la tumba en su lugar
        if (tumba != null)
        {
            Instantiate(tumba, transform.position, Quaternion.identity);
        }

        // Desaparecer al villano después de un momento
        Destroy(gameObject, 0.5f);
    }
}