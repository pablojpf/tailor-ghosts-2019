using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fantasma_Baboso: MonoBehaviour
{
    public GameObject baba;
    public GameObject fantasmaNormal;
    Vector2 posicionActual;
    Vector2 posicionInicial;
    Rigidbody2D rb;
    GameObject nuevaBaba;
    
    //Variables de los Controles
    Vector3 pincho;
    Vector3 suelto;
    public float velocidad = 10f;
    public bool puedoMoverme = true;
    public bool baja = false;
    public bool sube = false;
    public bool izda = false;
    public bool dcha = false;

    public bool encima = false;
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
        {
            if (posicionActual.x >= posicionInicial.x + 1 && dcha)
            {

                if (encima == false)
                {
                    nuevaBaba = Instantiate(baba, transform.position - new Vector3(0.2f, 0, 0), transform.rotation);
                }
                posicionInicial.x = posicionInicial.x + 1;
            }

            if (posicionActual.x <= posicionInicial.x - 1 && izda)
            {
                if (encima == false)
                {                   
                    nuevaBaba = Instantiate(baba, transform.position + new Vector3(0.2f, 0, 0), transform.rotation);
                }
                posicionInicial.x = posicionInicial.x - 1;
            }
            if (posicionActual.y >= posicionInicial.y + 1 && sube)
            {
                if (encima == false)
                {
                    nuevaBaba = Instantiate(baba, transform.position - new Vector3(0,0.2f,0), transform.rotation);
                }
                posicionInicial.y = posicionInicial.y + 1;
            }

            if (posicionActual.y <= posicionInicial.y - 1 && baja)
            {
                if (encima == false)
                {
                    nuevaBaba = Instantiate(baba, transform.position + new Vector3(0, 0.2f, 0), transform.rotation);
                }
                posicionInicial.y = posicionInicial.y - 1;
            }
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
                Instantiate(fantasmaNormal, transform.position, transform.rotation);
                Destroy(gameObject);
            }


        }
        else
        {
            puedoMoverme = true;

        }
        if(rb.velocity == Vector2.zero)
        {
            baja = false;
            sube = false;
            izda = false;
            dcha = false;
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Baba"))
        {
            encima = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Baba"))
        {
            encima = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Baba"))
        {
            encima = false;
        }
    }
}
