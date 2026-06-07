using UnityEngine;

public class MovimientoPlayer : MonoBehaviour
{
    [SerializeField] Transform posicionParent;
    [SerializeField] Transform[] arrayPosicionesHijos;

    [SerializeField] Transform posicionActual;
    [SerializeField] int indexPosicionActual=1;
    [SerializeField] float velocidadMovimiento;

    //Salto
     [SerializeField] float fuerzaSalto;
     [SerializeField] bool enSuelo;
     [SerializeField] LayerMask capaSuelo;
     [SerializeField] Transform comprobadorSuelo;
     Rigidbody rb;

    public bool esGrande; //USALO CUANDO EL PLAYER SEA GRANDOTE COSA QUE NO MUERAS CON LOS OBSTACULOS
    void Awake()
     {
        rb= GetComponent<Rigidbody>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        arrayPosicionesHijos= new Transform[posicionParent.childCount];
        for (int i = 0; i < posicionParent.childCount; i++)
        {
            arrayPosicionesHijos[i] = posicionParent.GetChild(i);
        }
        posicionActual= arrayPosicionesHijos[indexPosicionActual];
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A) && indexPosicionActual>0)
        {
            indexPosicionActual--;
        }
        if(Input.GetKeyDown(KeyCode.D) && indexPosicionActual<arrayPosicionesHijos.Length-1)
        {
            indexPosicionActual++;
        }
        posicionActual= arrayPosicionesHijos[indexPosicionActual];
        Vector3 posicionObjetivo = new Vector3(posicionActual.position.x, transform.position.y, posicionActual.position.z);
        transform.position= Vector3.MoveTowards(transform.position, posicionObjetivo, velocidadMovimiento*Time.deltaTime);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Salto();
        }
    }

    public void Salto()
    {
        enSuelo= Physics.CheckSphere(comprobadorSuelo.position, 0.1f, capaSuelo);
        if(enSuelo)
        {
            rb.AddForce(Vector3.up*fuerzaSalto, ForceMode.Impulse);
        }
    }
}
