using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;

    public TextMeshProUGUI textoAlfajores;

    private int cantidadAlfajores = 0;

    private void Awake()
    {
        instancia = this;
    }

    public void SumarAlfajor()
    {
        cantidadAlfajores++;

        textoAlfajores.text = "Alfajores: " + cantidadAlfajores;
        if (cantidadAlfajores >= 5)
        {
            GanarPartida();
        }
    }
    public void GanarPartida()
    {
        Debug.Log("¡Has ganado la partida! Has recolectado " + cantidadAlfajores + " alfajores.");
        SceneManager.LoadScene(3);
    }

    public void PerderPartida()
    {
        SceneManager.LoadScene(4);
    }
}