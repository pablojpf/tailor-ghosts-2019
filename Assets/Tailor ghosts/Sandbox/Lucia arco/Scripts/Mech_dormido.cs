using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mech_dormido : MonoBehaviour
{
    /*La diferencia entre este script y el normal son las que 
     * comentaré a continuacion
     */
    //public float distancia = 1;
   // public LayerMask capas;
    public float velocidad = 10f;
    public bool puedoMoverme = false;

    //Nuevo Booleano para saber si estoy despierto o no, es decir
    //saber si puedo moverme o no junto a el normal
    public bool estoyDespierto = false;
    Rigidbody2D rb;


    /*RaycastHit2D hitUp;
    RaycastHit2D hitDown;
    RaycastHit2D hitLeft;
    RaycastHit2D hitRight;*/

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //Nada mas comenzar el juego no estoy despierto, es decir, no puedo moverme
        estoyDespierto = false;
        puedoMoverme = false;

        //Nada mas empezar el juego no puedo moverme
        EstoyQuieto();

    }

 
    void Update()
    {
        /*hitUp = Physics2D.Raycast(transform.position,transform.up, distancia, capas);
        hitDown = Physics2D.Raycast(transform.position, -transform.up, distancia, capas);
        hitRight = Physics2D.Raycast(transform.position, transform.right, distancia, capas);
        hitLeft = Physics2D.Raycast(transform.position, -transform.right, distancia, capas);*/

        //Tocado();
        Mover();
    }

    void Mover()
    {
        //Si puedo moverme y estoy despierto, puedo moverme 
        if (puedoMoverme && estoyDespierto==true)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rb.velocity = new Vector2(1, 0) * velocidad;
                puedoMoverme = false;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb.velocity = new Vector2(-1, 0) * velocidad;
                puedoMoverme = false;
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb.velocity = new Vector2(0, 1) * velocidad;
                puedoMoverme = false;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                rb.velocity = new Vector2(0, -1) * velocidad;
                puedoMoverme = false;
            }
            //Debug.Log(rb.velocity);
        }


    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        puedoMoverme = true;

        //Si el objeto con el que colisiono es el Player principal me despierto y me puedo mover
        //mi rigidbody se vuelve kinematic
        if (col.gameObject.CompareTag("Player"))
        {
            estoyDespierto = true;
            puedoMoverme = true;
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    //Mientras ningun player me toque, mi rigibody es static
    void EstoyQuieto()
    {
        rb.isKinematic = true;
    }

   /* void Tocado()
    {
        if (hitUp)
        {
            Debug.DrawRay(transform.position, transform.up *distancia, Color.green);
            rb.bodyType = RigidbodyType2D.Dynamic;
            estoyDespierto = true;
            puedoMoverme = true;
        }
        if (hitDown)
        {
            Debug.DrawRay(transform.position, -transform.up * distancia, Color.green);
            rb.bodyType = RigidbodyType2D.Dynamic;
            estoyDespierto = true;
            puedoMoverme = true;
        }
        if (hitRight)
        {
            Debug.DrawRay(transform.position, transform.right * distancia, Color.green);
            rb.bodyType = RigidbodyType2D.Dynamic;
            estoyDespierto = true;
            puedoMoverme = true;
        }
        if (hitLeft)
        {
            Debug.DrawRay(transform.position, -transform.right * distancia, Color.green);
            rb.bodyType = RigidbodyType2D.Dynamic;
            estoyDespierto = true;
            puedoMoverme = true;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.up * distancia, Color.red);
            Debug.DrawRay(transform.position, -transform.up * distancia, Color.red);
            Debug.DrawRay(transform.position, transform.right * distancia, Color.red);
            Debug.DrawRay(transform.position, -transform.right * distancia, Color.red);
        }
        
        

    }*/
}
