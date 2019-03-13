using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Divisor : MonoBehaviour
{
    //Le pasamos un fantasma normal para hacer las copias
    public GameObject fantasmaNormal;
    //Velocidad a la que lanza la copia
    public float velocidadLanzador = 6f;
    //Mascara de capas del Raycast
    public LayerMask capas;

    //Variables de los Raycast
    RaycastHit2D hitRight;
    RaycastHit2D hitTop;
    RaycastHit2D hitLeft;
    RaycastHit2D hitBot;

    //Variables que se activan en oncollision
    public bool chocoTop = false;
    public bool chocoBot = false;
    public bool chocoRight = false;
    public bool chocoLeft = false;

    //Variables de deteccion del Raycast
    bool derecho = false;
    bool izquierdo = false;
    bool arriba = false;
    bool abajo = false;

    //Llamamos al Gamecontroller para aumentar el numero maximo de fantasmas cuando creamos nuevos
    public GameObject gc;

    //Creamos una variable que sirve para comprobar que el objeto que choca con nosotros es el mismo que ha detectado el raycast
    GameObject quienChoca;


    private void Awake()
    {
        gc = GameObject.Find("GameController");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        //Para facilitar el entendimiento del código, voy a enumerar los pasos que sigue la ejecución de este en el juego

        if (col.gameObject.transform.CompareTag("Player"))
        {

            //Si un player choca con nosotros, lo pasamos a la variable quienChoca y llamamos a la funcion Check
            quienChoca = col.gameObject;
            //1
            Check();

            //4
            //Cuando ya hemos hecho todas las comprobaciones lo destruimos
            Destroy(col.gameObject);
            Invoke("RestaF", 0.5f);
        }
    }



    public void Check()
    {
        //Lanzamos un raycast en cada direccion

        //RayCast Superior
        hitTop = Physics2D.Raycast(transform.position + new Vector3(0, 0.5f, 0), transform.up, 0.1f, capas);
        if (hitTop)
        {
            //Activamos la variable de que estamos detectando a alquien arriba y comprobamos que el objeto que detectamos es el que ha chocado con nosotros antes
            chocoTop = true;
            if (hitTop.transform.gameObject == quienChoca)
            {
                //Como se ha comprobado que si lo es, le decimos que efectivamente viene de arriba
                arriba = true;
            }

        }
        //Si no detecta nada, lo volvemos false, esto lo hacemos por si en algun otro check habia un objeto pero en este ya no esta
        else { chocoTop = false; }

        //RayCast Inferior
        hitBot = Physics2D.Raycast(transform.position - new Vector3(0, 0.5f, 0), transform.up * -1, 0.1f, capas);
        if (hitBot)
        {
            chocoBot = true;
            if (hitBot.transform.gameObject == quienChoca)
            {
                abajo = true;
            }

        }
        else { chocoBot = false; }

        //RayCast Derecho
        hitRight = Physics2D.Raycast(transform.position + new Vector3(0.5f, 0, 0), transform.right, 0.1f, capas);
        if (hitRight)
        {
            chocoRight = true;
            if (hitRight.transform.gameObject == quienChoca)
            {
                derecho = true;
            }

        }
        else { chocoRight = false; }

        //RayCast Izquierdo
        hitLeft = Physics2D.Raycast(transform.position - new Vector3(0.5f, 0, 0), transform.right *-1, 0.1f, capas);
        if (hitLeft)
        {
            chocoLeft = true;
            if (hitLeft.transform.gameObject == quienChoca)
            {
                izquierdo = true;
            }

        }
        else { chocoLeft = false; }

        //2
        //LLamamos a la funcion que lanza los fantasmas si es que ha detectado a alguno
        ControlaLanzadores();
    }

    public void ControlaLanzadores()
    {
        //Va comprobando la direccion por la que ha llegado el fantasma, si es true, lanza fantasmas por las direcciones restantes
        if (arriba == true)
        {
            //3
            //Activamos las funciones que lanzan los fantasmas
            LanzadorAbajo();
            LanzadorIzquierdo();
            LanzadorDerecho();

            //Lo vuelve false para que solo lance 1 vez
            arriba = false;
        }
        if (abajo == true)
        {
            LanzadorDerecho();
            LanzadorIzquierdo();
            LanzadorArriba();

            abajo = false;
        }
        if (izquierdo == true)
        {
            LanzadorAbajo();
            LanzadorDerecho();
            LanzadorArriba();

            izquierdo = false;
        }
        if (derecho == true)
        {
            LanzadorAbajo();
            LanzadorIzquierdo();
            LanzadorArriba();

            derecho = false;
        }

    }

    public void LanzadorArriba()
    {
        //Cada vez que lanza a un fantasma, antes comprueba que no haya fantasmas en la salida del divisor para que no se colapse
        if(chocoTop == false)
        {
            //Crea un fantasma nuevo y le aplica una fuerza hacia la direccion en la que sale
            GameObject nuevofantasma;
            nuevofantasma = Instantiate(fantasmaNormal, transform.position + new Vector3(0, 1, 0), transform.rotation);
            nuevofantasma.GetComponent<Rigidbody2D>().velocity = new Vector2(0, velocidadLanzador);
            gc.GetComponent<GameController_ingame>().SumarFantasmas();
        }

    }

    public void LanzadorAbajo()
    {
        if (chocoBot == false)
        {
            GameObject nuevofantasma;
            nuevofantasma = Instantiate(fantasmaNormal, transform.position - new Vector3(0, 1, 0), transform.rotation);
            nuevofantasma.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -velocidadLanzador);
            gc.GetComponent<GameController_ingame>().SumarFantasmas();
        }
    }

    public void LanzadorIzquierdo()
    {
        if (chocoLeft == false)
        {
            GameObject nuevofantasma;
            nuevofantasma = Instantiate(fantasmaNormal, transform.position - new Vector3(1, 0, 0), transform.rotation);
            nuevofantasma.GetComponent<Rigidbody2D>().velocity = new Vector2(-velocidadLanzador, 0);
            gc.GetComponent<GameController_ingame>().SumarFantasmas();
        }
    }

    public void LanzadorDerecho()
    {
        if (chocoRight == false)
        {
            GameObject nuevofantasma;
            nuevofantasma = Instantiate(fantasmaNormal, transform.position + new Vector3(1, 0, 0), transform.rotation);
            nuevofantasma.GetComponent<Rigidbody2D>().velocity = new Vector2(velocidadLanzador, 0);
            gc.GetComponent<GameController_ingame>().SumarFantasmas();
        }
    }
    public void RestaF()
    {
        gc.GetComponent<GameController_ingame>().RestarFantasmas();
        gc.GetComponent<GameController_ingame>().nivelDivisor = false;
    }
}
