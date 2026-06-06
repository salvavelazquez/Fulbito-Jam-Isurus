using UnityEngine;

public class CollisionConAlfajores : MonoBehaviour
{
    public Material sueloHelado;
    public Material sueloRocoso2;
    public SueloEndlessRuner cambioDeMapa;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AlfajorAzul"))
        {
            cambioDeMapa.CambiarMaterial(sueloHelado);
        }
        else if (other.CompareTag("AlfajorMarron"))
        {
            cambioDeMapa.CambiarMaterial(sueloRocoso2);
        }
    }
}
