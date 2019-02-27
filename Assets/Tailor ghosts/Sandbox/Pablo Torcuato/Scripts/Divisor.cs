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
    public bool chocoTop = false;
    public bool chocoBot = false;
    public bool chocoRight = false;
    public bool chocoLeft = false;

    bool derecho = false;
    bool izquierdo = false;
    bool arriba = false;
    bool abajo = false;
    Transform quienChoca;
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
            Comprobador();
            quienChoca = col.transform;
            Destroy(col.gameObject);          
        }
    }



    public void Comprobador()
    {

        ControlaLanzadores();
        Debug.Log("COMPROBADOR");
        //RayCast Superior
        hitTop = Physics2D.Raycast(transform.position + new Vector3(0, 0.5f, 0), transform.up, capas);
        if (hitTop)
        {
            chocoTop = true;
            if (hitTop.transform == quienChoca)
            {
                Debug.Log("ARRIBA ES TRUE");
                arriba = true;
            }

        }
        else { chocoTop = false; }
        //RayCast Derecho

        hitRight = Physics2D.Raycast(transform.position + new Vector3(0.5f, 0, 0), transform.right, capas);
        if (hitRight)
        {
            chocoRight = true;
            if (hitRight.transform == quienChoca)
            {
                derecho = true;
            }

        }
        else { chocoRight = false; }


    }

    public void ControlaLanzadores()
    {
        if(derecho == true)
        {
            LanzadorAbajo();

            LanzadorIzquierdo();

            LanzadorArriba();

            derecho = false;
        }
        if (arriba == true)
        {
            LanzadorAbajo();

            LanzadorIzquierdo();

            LanzadorDerecho();

            arriba = false;
        }

    }

    public void LanzadorArriba()
    {
        GameObject nuevofantasma;
        if(chocoTop == false)
        {
            nuevofantasma = Instantiate(fantasmaNormal, transform.position + new Vector3(0, 1, 0), transform.rotation);
            nuevofantasma.GetComponent<Rigidbody2D>().velocity = new Vector2(0, velocidadLanzador);
        }

    }

    public void LanzadorAbajo()
    {

        GameObject nuevofantasma;
        if (chocoBot == false)
        {
            nuevofantasma = Instantiate(fantasmaNormal, transform.position - new Vector3(0, 1, 0), transform.rotation);
            nuevofantasma.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -velocidadLanzador);
        }
    }

    public void LanzadorIzquierdo()
    {
        GameObject nuevofantasma;
        if (chocoLeft == false)
        {
            nuevofantasma = Instantiate(fantasmaNormal, transform.position - new Vector3(1, 0, 0), transform.rotation);
            nuevofantasma.GetComponent<Rigidbody2D>().velocity = new Vector2(-velocidadLanzador, 0);
        }
    }

    public void LanzadorDerecho()
    {
        GameObject nuevofantasma;
        if (chocoRight == false)
        {
            nuevofantasma = Instantiate(fantasmaNormal, transform.position + new Vector3(1, 0, 0), transform.rotation);
            nuevofantasma.GetComponent<Rigidbody2D>().velocity = new Vector2(velocidadLanzador, 0);
        }
    }
}
