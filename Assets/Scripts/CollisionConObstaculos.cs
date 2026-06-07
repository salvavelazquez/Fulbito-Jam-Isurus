using System.Collections;
using UnityEngine;

public class CollisionConObstaculos : MonoBehaviour
{
    public ParticleSystem collisionEffect01;
    public ParticleSystem collisionEffect02;
    public ParticleSystem collisionEffect03;
    MovimientoPlayer playerChocolate;
    private void Awake()
    {
        playerChocolate = GetComponent<MovimientoPlayer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstaculo")&& !playerChocolate.esGrande)
        {
            Debug.Log("Colision Con Tronco");
            //Explosion o efecto de muerte aquí
            collisionEffect01.Play();
            collisionEffect02.Play();
            collisionEffect03.Play();
            StartCoroutine(EsperarYMorir());
        }
    }
    IEnumerator EsperarYMorir()
    {
        yield return new WaitForSeconds(0.4f); // Espera 1 segundo antes de ejecutar el código siguiente
        GameManager.instancia.PerderPartida(); // Llama al método para perder la partida
    }
}
