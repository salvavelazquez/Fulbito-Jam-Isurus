using UnityEngine;

public class Alfajor : MonoBehaviour
{
    public AudioClip sonidoAlfajor;
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Choque con: " + other.name);

        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(sonidoAlfajor,transform.position);
            Debug.Log("Reproduciendo sonido del alfajor");
            Debug.Log("Jugador detectado");

            GameManager.instancia.SumarAlfajor();

            Destroy(gameObject);
        }

    }
}