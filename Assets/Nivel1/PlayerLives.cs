using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLives : MonoBehaviour
{
    [Header("Configuración de Vidas")]
    public int vidasMaximas = 3;

    // 📌 VARIABLE ESTÁTICA: Mantiene el valor exacto a través de los niveles y personajes
    public static int vidasActuales = 3;
    public static bool juegoIniciado = false;

    private HUDManager hudManager;
    private PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();

        // Si es el primer nivel del juego, inicializamos las vidas
        if (!juegoIniciado)
        {
            vidasActuales = vidasMaximas;
            juegoIniciado = true;
        }

        // Buscamos la interfaz del nivel actual y la actualizamos
        BuscarUI();
    }

    void BuscarUI()
    {
        hudManager = Object.FindAnyObjectByType<HUDManager>();
        if (hudManager != null)
        {
            hudManager.ActualizarCorazonesUI(vidasActuales);
        }
    }

    public void RestarVida()
    {
        vidasActuales--;

        if (hudManager != null)
        {
            hudManager.ActualizarCorazonesUI(vidasActuales);
        }

        if (vidasActuales > 0)
        {
            playerHealth.Reaparecer();
        }
        else
        {
            EjecutarGameOver();
        }
    }

    public void AñadirVida()
    {
        if (vidasActuales < vidasMaximas)
        {
            vidasActuales++;

            if (hudManager != null)
            {
                hudManager.ActualizarCorazonesUI(vidasActuales);
            }
        }
    }

    private void EjecutarGameOver()
    {
        Debug.LogError("¡GAME OVER!");
        juegoIniciado = false; // Permitimos que al reiniciar el juego vuelvan a tener 3 vidas
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
