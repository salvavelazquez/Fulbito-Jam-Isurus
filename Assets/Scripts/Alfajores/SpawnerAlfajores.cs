using UnityEngine;

public class SpawnerAlfajores : MonoBehaviour
{
    public GameObject alfajorPrefab;

    public float tiempoSpawn = 1f;
    public Transform[] puntosSpawn;


    private void Start()
    {
        InvokeRepeating(
            nameof(GenerarAlfajor),
            1f,
            tiempoSpawn
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
}