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
    public Animator animOsito;
    public Animator animGolem;
    public Animator animRosado;
    private Animator anim;
    public GameObject ositoNormal;
    public GameObject golemChocolate;
    public GameObject ositoRosado;

    
    public bool esGrande; //USALO CUANDO EL PLAYER SEA GRANDOTE COSA QUE NO MUERAS CON LOS OBSTACULOS
    void Awake()
     {
        rb= GetComponent<Rigidbody>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = animOsito;
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
        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && indexPosicionActual>0)
        {
            indexPosicionActual--;
        }
        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && indexPosicionActual<arrayPosicionesHijos.Length-1)
        {
            indexPosicionActual++;
        }
        posicionActual= arrayPosicionesHijos[indexPosicionActual];
        Vector3 posicionObjetivo = new Vector3(posicionActual.position.x, transform.position.y, posicionActual.position.z);
        transform.position= Vector3.MoveTowards(transform.position, posicionObjetivo, velocidadMovimiento*Time.deltaTime);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("isJump");
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

    public void TransformarGolem()
    {
        esGrande = true;
        ositoNormal.SetActive(false);
        golemChocolate.SetActive(true);
        ositoRosado.SetActive(false);
        anim = animGolem;
    }

    public void TransformarOsito()
    {
        esGrande = false;
        ositoRosado.SetActive(false);
        golemChocolate.SetActive(false);
        ositoNormal.SetActive(true);
        anim = animOsito;
    }
    public void TransformarOsitoRosado()
    {
        esGrande=false;
        golemChocolate.SetActive(false);
        ositoNormal.SetActive(false);
        ositoRosado.SetActive(true);
        anim = animRosado;
    }
}
