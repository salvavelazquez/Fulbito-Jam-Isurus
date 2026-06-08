using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;

    public TextMeshProUGUI textoAlfajores;
    public int faseActual = 0;
    private int cantidadAlfajores = 0;
    public SpawnerAlfajores spawner;
    public static int puntajeFinal;

    private void Awake()
    {
        instancia = this;
    }

    public void SumarAlfajor()
    {
        cantidadAlfajores++;

        textoAlfajores.text = "Alfajores: " + cantidadAlfajores;
        if (cantidadAlfajores>=30)
        {
            GanarPartida();
        }
    }

    public int ObtenerCantidadAlfajores()
    {
        return cantidadAlfajores;
    }

    public void GanarPartida()
    {
        Debug.Log("¡Has ganado la partida! Has recolectado " + cantidadAlfajores + " alfajores.");
        puntajeFinal = cantidadAlfajores;
        SceneManager.LoadScene(3);
    }

    public void PerderPartida()
    {
        SceneManager.LoadScene(4);
    }
}