using UnityEngine;
using UnityEngine.EventSystems;

public class MobileTouchZone : MonoBehaviour, IPointerDownHandler
{
    public enum TipoZona
    {
        Izquierda,
        Derecha,
        Salto
    }

    [SerializeField] private TipoZona tipoZona;
    [SerializeField] private MovimientoPlayer player;

    public void OnPointerDown(PointerEventData eventData)
    {
        switch (tipoZona)
        {
            case TipoZona.Izquierda:
                player.MoverIzquierda();
                break;

            case TipoZona.Derecha:
                player.MoverDerecha();
                break;

            case TipoZona.Salto:
                player.Salto();
                break;
        }
    }
}