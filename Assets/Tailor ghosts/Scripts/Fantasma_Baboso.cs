using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SonidoFantasmas))]
public class Fantasma_Baboso: MonoBehaviour
{

    SonidoFantasmas sonido;

    public GameObject fantasmaNormal;
    Rigidbody2D rb;
    public GameObject gc;

    //Variables de los Controles
    Vector3 pincho;
    Vector3 suelto;
    public float velocidad = 10f;
    public bool puedoMoverme = true;
    public static bool baja = false;
    public static bool sube = false;
    public static bool izda = false;
    public static bool dcha = false;


    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        sonido = GetComponent<SonidoFantasmas>();

    }
    // Update is called once per frame
    void Update()
    {


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

        sonido.SonidoMover();
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.CompareTag("Player"))
        {
            rb.velocity = Vector2.zero;

            if (!col.transform.parent == transform)
            {
                //Debug.Log("hijobasoso");
                Instantiate(fantasmaNormal, transform.position, transform.rotation);
                gc.GetComponent<GameController_ingame>().RestarFantasmas();
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

}
