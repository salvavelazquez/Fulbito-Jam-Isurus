using UnityEngine;

public class PozoBehaviour : MonoBehaviour
{
    private float speed = 30f;
    private float downBound = -21;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        if (transform.position.z < downBound)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Aquí puedes agregar la lógica para lo que sucede cuando el jugador entra en el pozo.
            // Por ejemplo, podrías reiniciar el nivel, reducir la vida del jugador, etc.
            Debug.Log("¡El jugador ha caído en el pozo!");
            Collider player=other.GetComponent<Collider>();
            player.enabled = false; // Desactiva el collider del jugador para evitar colisiones adicionales
        }
    }
}
