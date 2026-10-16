using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement; // Necesario para detectar el cambio de nivel

public class HUDManager : MonoBehaviour
{
    [Header("Lista de Corazones de la UI")]
    public Image[] corazones;

    [Header("Referencia al Texto del Contador")]
    public TextMeshProUGUI textoInterfaz;

    [Header("Configuración Gráfica por Nivel")]
    public Image imagenContadorUI;  // Objeto "Hongo" de tu Canvas
    public Sprite spriteHongo;      // Dibujo del hongo para Nivel_1 y Nivel_2
    public Sprite spriteMuñecoNieve; // Dibujo del muñeco de nieve para Nivel_3

    private Canvas canvasComponente;

    private void Awake()
    {
        // Mantiene la interfaz viva durante todo el juego
        DontDestroyOnLoad(gameObject);
        canvasComponente = GetComponentInChildren<Canvas>();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += AlCambiarDeNivel;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= AlCambiarDeNivel;
    }

    // Esta función se ejecuta de golpe apenas entras a cualquier nivel
    private void AlCambiarDeNivel(Scene escena, LoadSceneMode modo)
    {
        // 1. CONDICIÓN PARA EL NIVEL 4 (O SUPERIORES): Se oculta todo el contador por completo
        if (escena.name == "Nivel_4" || escena.buildIndex >= 4)
        {
            if (textoInterfaz != null) textoInterfaz.gameObject.SetActive(false);
            if (imagenContadorUI != null) imagenContadorUI.gameObject.SetActive(false);

            Debug.Log("Nivel_4 detectado: Se ocultó por completo el contador y su imagen.");
            return; // Salimos de la función
        }
        else
        {
            // Nos aseguramos de que el contador sea visible en los niveles anteriores (1, 2 y 3)
            if (textoInterfaz != null) textoInterfaz.gameObject.SetActive(true);
            if (imagenContadorUI != null) imagenContadorUI.gameObject.SetActive(true);
        }

        // 2. CONDICIÓN PARA EL NIVEL 3: Cambiar el hongo por el muñeco de nieve
        if (escena.name == "Nivel_3")
        {
            if (imagenContadorUI != null && spriteMuñecoNieve != null)
            {
                imagenContadorUI.sprite = spriteMuñecoNieve;
                Debug.Log("Nivel_3 detectado: Interfaz cambiada al Muñeco de Nieve.");
            }
        }
        else
        {
            // Para Nivel_1 y Nivel_2 se mantiene el hongo clásico de la interfaz
            if (imagenContadorUI != null && spriteHongo != null)
            {
                imagenContadorUI.sprite = spriteHongo;
            }
        }
    }

    public void ActualizarCorazonesUI(int vidas)
    {
        for (int i = 0; i < corazones.Length; i++)
        {
            if (corazones[i] != null)
            {
                corazones[i].enabled = (i < vidas);
            }
        }
    }

    public void ActualizarTextoHongos(int actuales, int totales)
    {
        if (textoInterfaz != null)
        {
            textoInterfaz.text = actuales + "/" + totales;
        }
    }
}
