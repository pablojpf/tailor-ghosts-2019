using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Reposiciona();

    }

    // Update is called once per frame
    void Update()
    {
        
        if(direccion != Vector2.zero)
        {
            rb.velocity = Movimientos.direccion;
        }
        /*
        if (right == true)
        {
            Debug.DrawRay(transform.position + new Vector3(puntoSalida, 0, 0), transform.right * distancia, Color.red);
            hit = Physics2D.Raycast(transform.position + new Vector3(puntoSalida, 0, 0), transform.right, distancia);
            if (hit)
            {
                Debug.Log(hit.transform.name);
                Debug.DrawRay(transform.position + new Vector3(puntoSalida, 0, 0), transform.right * distancia, Color.green);
                colisionRight = true;
            }
        }
        if (left == true)
        {
            Debug.DrawRay(transform.position + new Vector3(-puntoSalida, 0, 0), (transform.right * -1) * distancia, Color.red);
            hit = Physics2D.Raycast(transform.position + new Vector3(-puntoSalida, 0, 0), transform.right * -1, distancia);
            if (hit)
            {
                Debug.Log(hit.transform.name);
                Debug.DrawRay(transform.position + new Vector3(-puntoSalida, 0, 0), (transform.right * -1) * distancia, Color.green);
                colisionLeft = true;
            }
        }
        if (top == true)
        {
            Debug.DrawRay(transform.position + new Vector3(0, puntoSalida, 0), transform.up * distancia, Color.red);
            hit = Physics2D.Raycast(transform.position + new Vector3(0, puntoSalida, 0), transform.up, distancia);
            if (hit)
            {
                Debug.Log(hit.transform.name);
                Debug.DrawRay(transform.position + new Vector3(0, puntoSalida, 0), transform.up * distancia, Color.green);
                colisionTop = true;
            }
        }
        if (bot == true)
        {
            Debug.DrawRay(transform.position + new Vector3(0, -puntoSalida, 0), (transform.up * -1) * distancia, Color.red);
            hit = Physics2D.Raycast(transform.position + new Vector3(0, -puntoSalida, 0), transform.up * -1, distancia);
            if (hit)
            {
                Debug.Log(hit.transform.name);
                Debug.DrawRay(transform.position + new Vector3(0, -puntoSalida, 0), (transform.up * -1) * distancia, Color.green);
                colisionTop = true;
            }
        }*/
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
                //Debug.Log("hijobasoso");
                Debug.Log("CreandoFantasma " + transform.name);
                Reposiciona();
                if(creado == false)
                {
                    GameObject nuevoFantasma;
                    nuevoFantasma = Instantiate(fantasmaNormal, transform.position, transform.rotation);
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
