using UnityEngine;
using System.Collections;

public class IntroCamara : MonoBehaviour
{
    public Transform camaraFrontalOsito;
    public Transform camaraFrontalGolem;
    public Transform camaraJuego;

    public float tiempoEspera = 2f;
    public float velocidadTransicion = 2f;

    private bool transicionActiva = false;

    void Start()
    {
        StartCoroutine(TransicionDesde(camaraFrontalOsito));
    }

    public void MostrarGolem()
    {
        if (!transicionActiva)
            StartCoroutine(TransicionDesde(camaraFrontalGolem));
    }

    IEnumerator TransicionDesde(Transform origen)
    {
        transicionActiva = true;

        transform.position = origen.position;
        transform.rotation = origen.rotation;

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
                    camaraJuego.position,
                    t
                );

            transform.rotation =
                Quaternion.Lerp(
                    rotInicial,
                    camaraJuego.rotation,
                    t
                );

            yield return null;
        }

        transicionActiva = false;
    }
}