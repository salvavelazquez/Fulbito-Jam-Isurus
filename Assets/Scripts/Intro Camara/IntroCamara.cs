using UnityEngine;
using System.Collections;

public class IntroCamara : MonoBehaviour
{
    public Transform cameraInicio;
    public Transform cameraJuego;

    public float tiempoEspera = 2f;
    public float velocidadTransicion = 2f;

    IEnumerator Start()
    {
        transform.position = cameraInicio.position;
        transform.rotation = cameraInicio.rotation;

        yield return new WaitForSeconds(tiempoEspera);

        float t = 0;

        Vector3 posInicial = transform.position;
        Quaternion rotInicial = transform.rotation;

        while (t < 1)
        {
            t += Time.deltaTime * velocidadTransicion;

            transform.position =
                Vector3.Lerp(
                    posInicial,
                    cameraJuego.position,
                    t
                );

            transform.rotation =
                Quaternion.Lerp(
                    rotInicial,
                    cameraJuego.rotation,
                    t
                );

            yield return null;
        }
    }
}