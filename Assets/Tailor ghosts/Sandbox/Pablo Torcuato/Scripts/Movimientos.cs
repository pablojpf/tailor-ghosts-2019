using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SonidoFantasmas))]

public class Movimientos : MonoBehaviour
{
    public float velocidad = 10f;
    Rigidbody2D rb;
    bool puedoMoverme = true;
    //Hacemos una variable estática de tipo vector2 para que sea compatible con el rigidbody.velocity del script "Coordinados"
    public static Vector2 direccion;
    //Variables Controles
    Vector3 pincho;
    Vector3 suelto;
    public GameObject fantasmaNormal;
    bool creado = false;
    GameObject gc;
    RaycastHit2D hit;
    public LayerMask capas;
    public float distancia = 1f;
    public float velocidadRayo = 5f;
    public float puntoSalida = 0.51f;
    // Variables de dirección para el raycast
    public bool top = false;
    public bool bot = false;
    public bool right = false;
    public bool left = false;

    public bool colisionTop = false;
    public bool colisionBot = false;
    public bool colisionRight = false;
    public bool colisionLeft = false;

    SonidoFantasmas sonido;

    private void Awake()
    {
        gc = GameObject.Find("GameController");
        if (gc == null)
        {
            Debug.LogError("No encuntro el GameController");
        }
    }
    void Start()
    {
        direccion = Vector2.zero;
        rb = GetComponent<Rigidbody2D>();
        Reposiciona();
        sonido = GetComponent<SonidoFantasmas>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(direccion != Vector2.zero)
        {
            rb.velocity = Movimientos.direccion;
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
                    direccion = Vector2.zero;
                    direccion = rb.velocity;
                    right = true;
                }
                else
                {
                    rb.velocity = new Vector2(-1, 0) * velocidad;
                    direccion = Vector2.zero;
                    direccion = rb.velocity;
                    left = true;
                }

                puedoMoverme = false;
            }

            else
            {
                if (dif.y > 0)
                {
                    rb.velocity = new Vector2(0, 1) * velocidad;
                    direccion = Vector2.zero;
                    direccion = rb.velocity;
                    top = true;
                }
                else
                {
                    rb.velocity = new Vector2(0, -1) * velocidad;
                    direccion = Vector2.zero;
                    direccion = rb.velocity;
                    bot = true;
                }

                puedoMoverme = false;
            }

        }

        sonido.SonidoMover();




    }



    private void OnCollisionEnter2D(Collision2D col)
    {

        puedoMoverme = true;
        direccion = Vector2.zero;
        rb.velocity = Vector2.zero;
        Reposiciona();
        if (col.gameObject.CompareTag("Player"))//&&hit)
        {
            col.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            if (!col.transform.parent == transform)
            {
                rb.velocity = Vector2.zero;
                
                Reposiciona();

                if(creado == false)
                {
                    GameObject nuevoFantasma;
                    nuevoFantasma = Instantiate(fantasmaNormal, transform.position, transform.rotation);
                    gc.GetComponent<GameController_ingame>().RestarFantasmas();

                    nuevoFantasma.transform.SetParent(col.transform);
                    Destroy(nuevoFantasma.GetComponent<Rigidbody2D>());
                    creado = true;
                }
                
            //  gc.GetComponent<GameController_ingame>().RestarFantasmas();
                Destroy(gameObject);
            }
            /*   Debug.Log("Ey");
               Fantasma_normal scriptFantasma;
               scriptFantasma = nuevoFantasma.GetComponent<Fantasma_normal>();
               nuevoFantasma.transform.SetParent(col.transform);
               rb = nuevoFantasma.GetComponent<Rigidbody2D>();

               Destroy(scriptFantasma);
               Destroy(rb);*/
            //   gc.GetComponent<GameController_ingame>().RestarFantasmas();


          
           
        }
        else
        {
            right = false;
            left = false;
            top = false;
            bot = false;
        }
    }

    public void Reposiciona()
    {
        transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
    }

}
