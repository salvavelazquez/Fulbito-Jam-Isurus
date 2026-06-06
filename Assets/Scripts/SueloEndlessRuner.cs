using UnityEngine;

public class SueloEndlessRuner : MonoBehaviour
{
    
    // Puedes ajustar esta velocidad desde el Inspector
    public float velocidadX = 0f;
    public float velocidadY = 0.5f;

    private Renderer miRenderer;

    void Start()
    {
        // Obtenemos el componente Renderer del objeto que tiene este script
        miRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        // Calculamos el desplazamiento continuo usando Time.time
        float offsetX = Time.time * -velocidadX;
        float offsetY = Time.time * -velocidadY;

        // Le asignamos el nuevo desfase a la textura principal del material
        miRenderer.material.mainTextureOffset = new Vector2(0, offsetY);
    }
    public void CambiarMaterial(Material materialSuelo)
    {
        // Cambia el material del suelo al material de hielo
        miRenderer.material = materialSuelo;
    }
}
