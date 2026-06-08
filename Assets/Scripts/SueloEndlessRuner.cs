using UnityEngine;

public class SueloEndlessRuner : MonoBehaviour
{
    public Renderer paredIzquierda;
    public Renderer paredDerecha;
    public Renderer paredFrontal1;
    public Renderer paredFrontal2;

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
        miRenderer.material.mainTextureOffset = new Vector2(offsetX, offsetY);
    }
    public void CambiarMaterial(
    Material materialSuelo,
    Material materialParedes)
    {
        miRenderer.material = materialSuelo;

        paredIzquierda.material = materialParedes;
        paredDerecha.material = materialParedes;
        paredFrontal1.material = materialParedes;
        paredFrontal2.material = materialParedes;
    }
}
