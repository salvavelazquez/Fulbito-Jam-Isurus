using UnityEngine;

public class Alfajor : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Choque con: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Jugador detectado");

            GameManager.instancia.SumarAlfajor();

            Destroy(gameObject);
        }

    }
}