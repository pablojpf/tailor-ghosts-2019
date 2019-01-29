using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baboso : MonoBehaviour
{
    public GameObject baba;
    Vector2 posicionActual;
    Vector2 posicionInicial;
    Rigidbody2D rb;
    GameObject nuevaBaba;

    //Variables de los Controles
    Vector3 pincho;
    Vector3 suelto;
    public float velocidad = 10f;
    public bool puedoMoverme = true;
    bool baja = false;
    bool sube = false;
    bool izda = false;
    bool dcha = false;

    // Start is called before the first frame update
    void Start()
    {
        posicionInicial = transform.position;
        rb = GetComponent<Rigidbody2D>();
        nuevaBaba = Instantiate(baba, transform.position, transform.rotation);
    }
    // Update is called once per frame
    void Update()
    {
        posicionActual = transform.position;

        if (posicionActual.x >= posicionInicial.x + 1&&dcha)
        {
            nuevaBaba = Instantiate(baba, transform.position, transform.rotation);
            posicionInicial.x = posicionInicial.x + 1;
        }

        if (posicionActual.x <= posicionInicial.x - 1 &&izda)
        {
            nuevaBaba = Instantiate(baba, transform.position, transform.rotation);
            posicionInicial.x = posicionInicial.x - 1;
        }
        if (posicionActual.y >= posicionInicial.y + 1&&sube)
        {
            nuevaBaba = Instantiate(baba, transform.position, transform.rotation);
            posicionInicial.y = posicionInicial.y + 1;
        }

        if (posicionActual.y <= posicionInicial.y - 1 &&baja)
        {
            nuevaBaba = Instantiate(baba, transform.position, transform.rotation);
            posicionInicial.y = posicionInicial.y - 1;
        }

    }
    void OnMouseDown()
    {
        pincho = Input.mousePosition;
    }
    //Cuando suelto obtengo la posición donde he soltado y la guardo en el vector suelto
    void OnMouseUp()
    {
        suelto = Input.mousePosition;
        Mover();

    }
    void Mover()
    {
        Vector3 dif = suelto - pincho;
        if (puedoMoverme)
        {

            //Si el valor absoluto en x es mayor que el valor absoluto en y
            //Entonces la velocidad irá en el eje x
            //dependiendo de si la dirección es positiva o negativa irá hacia arriba o hacia abajo
            if (Mathf.Abs(dif.x) > Mathf.Abs(dif.y))
            {
                if (dif.x > 0)
                {
                    rb.velocity = new Vector2(1, 0) * velocidad;
                    dcha = true;
                }
                else
                {
                    rb.velocity = new Vector2(-1, 0) * velocidad;
                    izda = true;
                }

                puedoMoverme = false;
            }
            //Si no, la velocidad irá en el eje y
            //dependiendo de si la dirección es positiva o negativa irá hacia derecha o izquierda
            else
            {
                if (dif.y > 0)
                {
                    rb.velocity = new Vector2(0, 1) * velocidad;
                    sube = true;
                }
                else
                {
                    rb.velocity = new Vector2(0, -1) * velocidad;
                    baja = true;
                }

                puedoMoverme = false;
            }

        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.CompareTag("Player"))
        {
            if (!col.transform.parent == transform)
            {
                transform.SetParent(col.transform);
                Destroy(GetComponent<Baboso>());
                Destroy(rb);
            }


        }
        else
        {
            puedoMoverme = true;

        }
        bool baja = false;
        bool sube = false;
        bool izda = false;
        bool dcha = false;

    }

}
