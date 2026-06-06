using UnityEngine;

public class ObstaculosBehaviour : MonoBehaviour
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
}
