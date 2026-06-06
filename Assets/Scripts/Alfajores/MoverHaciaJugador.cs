using UnityEngine;

public class MoverHaciaJugador : MonoBehaviour
{
    public float velocidad = 8f;

    void Update()
    {
        transform.Translate(
            Vector3.back * velocidad * Time.deltaTime
        );

        if (transform.position.z < -30)
        {
            Destroy(gameObject);
        }
    }
}