using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fantasma_normal1 : MonoBehaviour
{
    public GameObject gc;

    //Creamos dos vectores, uno para detectar dónde pulso por primera vez
    //y dónde suelto para más tarde calcular la diferencia entre esas posiciones

    Vector3 pincho;
    Vector3 suelto;

    //Declaramos una velocidad 
    //Y un booleano para saber si podemos movernos o no para así impedir
    //que el jugador pueda mover el fantasma mientras este realiza su trayectoria

    public float velocidad = 10f;
    public bool puedoMoverme = true;
    Fantasma_normal scriptFantasma;

    //Declaramos el rb del fantasma
    Rigidbody2D rb;


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
        //Obtenemos el rb de el fantasma
        rb = GetComponent<Rigidbody2D>();
        scriptFantasma = GetComponent<Fantasma_normal>();


    }

    // Update is called once per frame
    void Update()
    {
        if(right == true)
        {
            Debug.DrawRay(transform.position + new Vector3(puntoSalida, 0, 0), transform.right * distancia, Color.red);
            hit = Physics2D.Raycast(transform.position + new Vector3(puntoSalida,0,0), transform.right, distancia);
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
        }

    }

    //Funcion para poder moverme
     void Mover()
     {
        //Declaramos un vector que obtenga la diferencia 
        //Entre la posición donde pinchamos y dónde soltamos
        //para saber la dirección en la que irá nuestro personaje

         Vector3 dif = suelto - pincho;

         if (puedoMoverme)
         {

            //Si el valor absoluto en x es mayor que el valor absoluto en y
            //Entonces la velocidad irá en el eje x
            //dependiendo de si la dirección es positiva o negativa irá hacia arriba o hacia abajo
             if (Mathf.Abs(dif.x) > Mathf.Abs(dif.y))
             {
                 if(dif.x>0)
                 {
                    rb.velocity = new Vector2(1, 0) * velocidad;
                    right = true;
                 }
                 else
                 {
                    rb.velocity = new Vector2(-1, 0) * velocidad;
                    left = true;
                 }

                 puedoMoverme = false;
             }
            //Si no, la velocidad irá en el eje y
            //dependiendo de si la dirección es positiva o negativa irá hacia derecha o izquierda
            else
            {
                 if (dif.y>0)
                 {
                    rb.velocity = new Vector2(0, 1) * velocidad;
                    top = true;
                 }
                 else
                 {
                    rb.velocity = new Vector2(0, -1) * velocidad;
                    bot = true;
                 }

                 puedoMoverme = false;
             }

         }




     }

    //Cuando pincho obtengo la posición donde he pinchado y la guardo en el vector pincho
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

    //Cuando choco con un colider puedo volver a moverme
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player")&&hit)
        {

            if (col.transform.parent!= transform)
            {
                Debug.Log("Ey");
                col.transform.SetParent(transform);
                Destroy(scriptFantasma);
                Destroy(rb);

                //   gc.GetComponent<GameController_ingame>().RestarFantasmas();
            }

            rb.velocity = Vector2.zero;
        }
        else
        {
            puedoMoverme = true;
            right = false;
            left = false;
            top = false;
            bot = false;
            rb.velocity = Vector2.zero;
        }


    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        puedoMoverme = true;
    }
}
