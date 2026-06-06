using TMPro;
using UnityEngine;

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
    }
}