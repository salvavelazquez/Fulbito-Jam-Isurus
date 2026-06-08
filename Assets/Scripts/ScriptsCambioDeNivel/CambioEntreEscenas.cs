using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CambioEntreEscenas : MonoBehaviour
{
    // 1. LA INSTANCIA SINGLETON
    // Accesible desde cualquier lugar, pero solo modificable por este mismo script.
    public static CambioEntreEscenas Instance { get; private set; }

    [Header("Referencias UI")]
    [SerializeField] private GameObject panelPausa;
    [SerializeField] private GameObject panelInicio;
    [SerializeField] private GameObject panelComoJuegar;
    private bool enPausa = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        // Control de pausa (solo si no estamos en el menú principal - buildIndex 0)
        if (SceneManager.GetActiveScene().buildIndex != 0&& SceneManager.GetActiveScene().buildIndex!=2)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                AlternarPausa();
            }
        }
    }

    public void AlternarPausa()
    {
        enPausa = !enPausa;
        panelPausa.SetActive(enPausa);
        Time.timeScale = enPausa ? 0f : 1f;
    }

    public void IniciarJuego()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
        panelInicio.SetActive(false);
    }
    public void Creditos()
    {
        Time.timeScale = 1f;
        panelInicio.SetActive(false);
        SceneManager.LoadScene(2);
    }

    public void VolverAlMenuPrincipal()
    {
        Time.timeScale = 1f;
        enPausa = false;
        panelInicio.SetActive(true);
        panelPausa.SetActive(false);
        SceneManager.LoadScene(0);
    }

    public void SalirDelJuego()
    {
        Application.Quit();
        Debug.Log("Saliendo del juego...");
    }
    public void DesactivarPanel()
    {
        panelComoJuegar.SetActive(false);
        panelInicio.SetActive(true);
    }
    public void ActivarPanel()
    {
        panelComoJuegar.SetActive(true);
        panelInicio.SetActive(false);
    }
}
