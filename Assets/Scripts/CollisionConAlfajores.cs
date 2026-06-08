using UnityEngine;

public class CollisionConAlfajores : MonoBehaviour
{
    [Header ("Efecto de Alfajor de Blanco")]
    public Material sueloRocoso2;
    public Material paredesMarron;
    [Header("Efecto de Alfajor de Chocolate")]
    public Material sueloBlanco;
    public Material paredesBlanco;
    public IntroCamara introCamara;

    //[Header("Efecto de Alfajor de Rosado")]
    //public Material sueloRosado;
    //public Material paredesRosado;
    [Space]
    public SueloEndlessRuner cambioDeMapa;
    public MovimientoPlayer player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AlfajorBlanco"))
        {
            cambioDeMapa.CambiarMaterial(
                sueloRocoso2,
                paredesMarron
            );

            player.esGrande = true;
            player.TransformarGolem();
            introCamara.MostrarGolem();

            GameManager.instancia.faseActual = 1;

            Destroy(other.gameObject);
        }
        if (other.CompareTag("AlfajorMarron"))
        {
            cambioDeMapa.CambiarMaterial(
                sueloBlanco,
                paredesBlanco
            );

            player.esGrande = false;
            player.TransformarOsito();

            GameManager.instancia.faseActual = 2;

            Destroy(other.gameObject);
        }
        if (other.CompareTag("AlfajorRosado"))
        {
            GameManager.instancia.GanarPartida();
        }
    }
}
