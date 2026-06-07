using UnityEngine;

public class CollisionConAlfajores : MonoBehaviour
{
    [Header ("Efecto de Alfajor de Blanco")]
    public Material sueloBlanco;
    public Material paredesBlanco;
    [Header("Efecto de Alfajor de Chocolate")]
    public Material sueloRocoso2;
    public Material paredesMarron;
    [Header("Efecto de Alfajor de Rosado")]
    public Material sueloRosado;
    public Material paredesRosado;
    [Space]
    public SueloEndlessRuner cambioDeMapa;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AlfajorBlanco"))
        {
            cambioDeMapa.CambiarMaterial(sueloBlanco,paredesBlanco);
        }
        else if (other.CompareTag("AlfajorMarron"))
        {
            cambioDeMapa.CambiarMaterial(sueloRocoso2,paredesMarron);
        }
        else if (other.CompareTag("AlfajorRosado"))
        {
            cambioDeMapa.CambiarMaterial(sueloRosado, paredesRosado);
        }
    }
}
