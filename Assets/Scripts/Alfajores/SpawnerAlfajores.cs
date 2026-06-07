using UnityEngine;

public class SpawnerAlfajores : MonoBehaviour
{
    public GameObject alfajorPrefab;
    public GameObject[] alfajoresPoderosos;

    public float tiempoSpawn = 1f;
    public Transform[] puntosSpawn;


    private void Start()
    {
        InvokeRepeating(
            nameof(GenerarAlfajor),
            1f,
            tiempoSpawn
        );
        InvokeRepeating(
            nameof(GenerarAlfajorPoderoso),
            5f,
            10f
        );
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
}