using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Divisor : MonoBehaviour
{
    public GameObject fantasmaNormal;
    public float velocidadLanzador = 6f;
    public LayerMask capas;

    RaycastHit2D hitRight;
    RaycastHit2D hitTop;
    RaycastHit2D hitLeft;
    RaycastHit2D hitBot;

    public bool chocoTop = false;
    public bool chocoBot = false;
    public bool chocoRight = false;
    public bool chocoLeft = false;

    bool derecho = false;
    bool izquierdo = false;
    bool arriba = false;
    bool abajo = false;

    GameObject quienChoca;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.transform.CompareTag("Player"))
        {

            quienChoca = col.gameObject;
            Check();
            Destroy(col.gameObject);          
        }
    }



    public void Check()
    {

       
        Debug.Log("COMPROBADOR");
        //RayCast Superior
        hitTop = Physics2D.Raycast(transform.position + new Vector3(0, 0.5f, 0), transform.up, 0.1f, capas);
        if (hitTop)
        {
            Debug.Log(hitTop.transform.name);
            chocoTop = true;
            if (hitTop.transform.gameObject == quienChoca)
            {
                arriba = true;
            }

        }
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

        ControlaLanzadores();
    }

    public void ControlaLanzadores()
    {
        if (arriba == true)
        {
            LanzadorAbajo();
            LanzadorIzquierdo();
            LanzadorDerecho();

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
        if(chocoTop == false)
        {
            GameObject nuevofantasma;
            nuevofantasma = Instantiate(fantasmaNormal, transform.position + new Vector3(0, 1, 0), transform.rotation);
            nuevofantasma.GetComponent<Rigidbody2D>().velocity = new Vector2(0, velocidadLanzador);
        }

    }

    public void LanzadorAbajo()
    {
        if (chocoBot == false)
        {
            GameObject nuevofantasma;
            nuevofantasma = Instantiate(fantasmaNormal, transform.position - new Vector3(0, 1, 0), transform.rotation);
            nuevofantasma.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -velocidadLanzador);
        }
    }

    public void LanzadorIzquierdo()
    {
        if (chocoLeft == false)
        {
            GameObject nuevofantasma;
            nuevofantasma = Instantiate(fantasmaNormal, transform.position - new Vector3(1, 0, 0), transform.rotation);
            nuevofantasma.GetComponent<Rigidbody2D>().velocity = new Vector2(-velocidadLanzador, 0);
        }
    }

    public void LanzadorDerecho()
    {
        if (chocoRight == false)
        {
            GameObject nuevofantasma;
            nuevofantasma = Instantiate(fantasmaNormal, transform.position + new Vector3(1, 0, 0), transform.rotation);
            nuevofantasma.GetComponent<Rigidbody2D>().velocity = new Vector2(velocidadLanzador, 0);
        }
    }
}
