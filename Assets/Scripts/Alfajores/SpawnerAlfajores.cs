using UnityEngine;

public class SpawnerAlfajores : MonoBehaviour
{
    public GameObject alfajorPrefab;
    public GameObject[] alfajoresPoderosos;

    public float tiempoSpawn = 1f;
    public Transform[] puntosSpawn;

    public GameObject alfajorBlanco;
    public GameObject alfajorMarron;
    public GameObject alfajorRosado;

    private float temporizadorEspecial = 0f;
    public float intervaloEspecial = 5f;


    private void Start()
    {
        InvokeRepeating(
            nameof(GenerarAlfajor),
            1f,
            tiempoSpawn
        );
        /*InvokeRepeating(
            nameof(GenerarAlfajorPoderoso),
            5f,
            10f
        );*/
    }

    void Update()
    {
        temporizadorEspecial += Time.deltaTime;

        if (temporizadorEspecial >= intervaloEspecial)
        {
            temporizadorEspecial = 0f;

            VerificarEspeciales();
        }
    }

    void VerificarEspeciales()
    {
        int cantidad = GameManager.instancia.ObtenerCantidadAlfajores();

        if (cantidad >= 5 && GameManager.instancia.faseActual == 0)
        {
            SpawnearAlfajorBlanco();
        }
        else if (cantidad >= 15 && GameManager.instancia.faseActual == 1)
        {
            SpawnearAlfajorMarron();
        }
        else if (cantidad >= 20 && GameManager.instancia.faseActual == 2)
        {
            SpawnearAlfajorRosado();
        }
    }

    void GenerarAlfajor()
    {
        int indice = Random.Range(0, puntosSpawn.Length);

        Instantiate(
            alfajorPrefab,
            puntosSpawn[indice].position,
            Quaternion.identity
        );
    }

    public void GenerarAlfajorPoderoso()
    {
        int indice = Random.Range(0, alfajoresPoderosos.Length);
        int posicionIndice = Random.Range(0, puntosSpawn.Length);
        Instantiate(
            alfajoresPoderosos[indice],
            puntosSpawn[posicionIndice].position,
            Quaternion.identity
        );
    }

    public void SpawnearAlfajorBlanco()
    {
        SpawnEspecial(alfajorBlanco);
    }

    public void SpawnearAlfajorMarron()
    {
        SpawnEspecial(alfajorMarron);
    }

    public void SpawnearAlfajorRosado()
    {
        SpawnEspecial(alfajorRosado);
    }

    void SpawnEspecial(GameObject prefab)
    {
        int posicionIndice =
            Random.Range(0, puntosSpawn.Length);

        Instantiate(
            prefab,
            puntosSpawn[posicionIndice].position,
            Quaternion.identity
        );
    }
}