using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreaBabas : MonoBehaviour
{
    public GameObject baba;
    Vector3 posicionActual;
    Vector3 posicionInicial;
    GameObject nuevaBaba;

    public bool encima = false;
    // Start is called before the first frame update
    void Start()
    {
        posicionInicial = transform.position;
        nuevaBaba = Instantiate(baba, transform.position + new Vector3(0, 0, 1), transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        posicionActual = transform.position;

        if (posicionActual.x >= posicionInicial.x + 1 && Fantasma_Baboso.dcha)
        {

            if (encima == false)
            {
                nuevaBaba = Instantiate(baba, posicionInicial + new Vector3(1, 0, 1), transform.rotation);

                Debug.Log("Creando Baba:" + posicionInicial.x + " " + posicionInicial.y);
            }
            posicionInicial.x = posicionInicial.x + 1;
        }

        if (posicionActual.x <= posicionInicial.x - 1 && Fantasma_Baboso.izda)
        {
            if (encima == false)
            {
                nuevaBaba = Instantiate(baba, posicionInicial + new Vector3(-1, 0, 1), transform.rotation);
                Debug.Log("Creando Baba:" + posicionInicial.x + " " + posicionInicial.y);
            }
            posicionInicial.x = posicionInicial.x - 1;
        }
        if (posicionActual.y >= posicionInicial.y + 1 && Fantasma_Baboso.sube)
        {
            if (encima == false)
            {
                nuevaBaba = Instantiate(baba, posicionInicial + new Vector3(0, 1, 1), transform.rotation);
                Debug.Log("Creando Baba:" + posicionInicial.x + " " + posicionInicial.y);
            }
            posicionInicial.y = posicionInicial.y + 1;
        }

        if (posicionActual.y <= posicionInicial.y - 1 && Fantasma_Baboso.baja)
        {
            if (encima == false)
            {
                nuevaBaba = Instantiate(baba, posicionInicial + new Vector3(0, -1, 1), transform.rotation);
                Debug.Log("Creando Baba:" + posicionInicial.x + " " + posicionInicial.y);
            }
            posicionInicial.y = posicionInicial.y - 1;
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
