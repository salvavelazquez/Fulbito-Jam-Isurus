using TMPro;
using UnityEngine;

public class MostrarPuntajeFinal : MonoBehaviour
{
    public TextMeshProUGUI textoPuntaje;

    void Start()
    {
        textoPuntaje.text =
            "Puntaje "
            + GameManager.puntajeFinal;
    }

    public void SalirJuego()
    {
        Application.Quit();
    }
}