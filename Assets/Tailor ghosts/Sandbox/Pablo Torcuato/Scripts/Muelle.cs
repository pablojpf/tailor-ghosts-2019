using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SonidoFantasmas))]

public class Muelle : MonoBehaviour
{
    public static bool top = false;
    public static bool bot = false;
    public static bool left = false;
    public static bool right = false;

    bool paRiba = false;
    bool paBajo = false;
    bool paDerecha = false;
    bool paIzquierda = false;

    GameObject quienChoca;
    Vector2 posInicial;

    Vector2 posFinalTop;
    Vector2 posFinalBot;
    Vector2 posFinalRight;
    Vector2 posFinalLeft;

    SonidoFantasmas sonido;

    // Start is called before the first frame update
    void Start()
    {
        sonido = GetComponent<SonidoFantasmas>();
    }

    // Update is called once per frame
    void Update()
    {
        if (paRiba == true)
        {
            quienChoca.transform.position = Vector2.MoveTowards(quienChoca.transform.position, posFinalTop, 10 * Time.deltaTime);
            if(new Vector2(quienChoca.transform.position.x, quienChoca.transform.position.y) == posFinalTop)
            {
                paRiba = false;
                top = false;
            }
        }
        if (paBajo == true)
        {
            quienChoca.transform.position = Vector2.MoveTowards(quienChoca.transform.position, posFinalBot, 10 * Time.deltaTime);
            if (new Vector2(quienChoca.transform.position.x, quienChoca.transform.position.y) == posFinalBot)
            {
                paBajo = false;
                bot = false;
            }
        }
        if (paDerecha == true)
        {
            quienChoca.transform.position = Vector2.MoveTowards(quienChoca.transform.position, posFinalRight, 10 * Time.deltaTime);
            if (new Vector2(quienChoca.transform.position.x, quienChoca.transform.position.y) == posFinalRight)
            {
                paDerecha = false;
                right = false;
            }
        }
        if (paIzquierda == true)
        {
            quienChoca.transform.position = Vector2.MoveTowards(quienChoca.transform.position, posFinalLeft, 10 * Time.deltaTime);
            if (new Vector2(quienChoca.transform.position.x, quienChoca.transform.position.y) == posFinalLeft)
            {
                paIzquierda = false;
                left = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {

        quienChoca = col.gameObject;
        posInicial = quienChoca.transform.position;
        
        if (/*col.gameObject.CompareTag("Player")&&*/ top == true)
        {
            posFinalTop = new Vector2(quienChoca.transform.position.x, Mathf.Round(quienChoca.transform.position.y + 1));
            paRiba = true;

            sonido.SonidoMover();
        }
        if (/*col.gameObject.CompareTag("Player") &&*/ bot == true)
        {
            posFinalBot = new Vector2(quienChoca.transform.position.x, Mathf.Round(quienChoca.transform.position.y - 1));
            paBajo = true;

            sonido.SonidoMover();
        }
        if (/*col.gameObject.CompareTag("Player") &&*/ right == true)
        {
            posFinalRight = new Vector2(Mathf.Round(quienChoca.transform.position.x + 1), quienChoca.transform.position.y);
            paDerecha = true;

            sonido.SonidoMover();
        }
        if (/*col.gameObject.CompareTag("Player") &&*/ left == true)
        {
            posFinalLeft = new Vector2(Mathf.Round(quienChoca.transform.position.x - 1), quienChoca.transform.position.y);
            paIzquierda = true;

            sonido.SonidoMover();
        }
    }

}
