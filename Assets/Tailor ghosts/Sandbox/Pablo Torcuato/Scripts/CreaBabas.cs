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

    void Start()
    {
        //Retrasamos la declaracion de la posicion inicial para que no de fallos al recuadrar el sprite
        Invoke("Retarda", 0.1f);
    }

    void Update()
    {
        //Cada frame, la variable de posicionActual pasa a ser la posicion del creaBabas
        posicionActual = transform.position;

        //Cada vez que superamos en 1 cualquier direccion a la que vamos, comprobamos que efectivamente el fantasma baboso esta yendo a la direccion superada (por seguridad)
        if (posicionActual.x >= posicionInicial.x + 1 && Fantasma_Baboso.dcha)
        {
            //Si no estamos encima de una baba (Para no superponer babas)
            if (encima == false)
            {
                //Creamos las babas por detras (en el eje Z) y en la posicion inicial que es entera para que esten cuadradas pero le sumamos 1 unidad en la direccion que va, ya que aun no se ha actualizado
                nuevaBaba = Instantiate(baba, posicionInicial + new Vector3(1, 0, 1), transform.rotation);
                Baba.comprueba = true;
                Debug.Log("Creando Baba:" + posicionInicial.x + " " + posicionInicial.y);
            }
            posicionInicial.x = posicionInicial.x + 1;
            //Reiniciamos la posicion inicial incrementando o restando una unidad en la direccion a la que vamos para que empiece a contar desde esta
        }

        //Las siguientes lineas son exactamente iguales pero para las demas direcciones
        if (posicionActual.x <= posicionInicial.x - 1 && Fantasma_Baboso.izda)
        {
            if (encima == false)
            {
                nuevaBaba = Instantiate(baba, posicionInicial + new Vector3(-1, 0, 1), transform.rotation);
                Baba.comprueba = true;
                Debug.Log("Creando Baba:" + posicionInicial.x + " " + posicionInicial.y);
            }
            posicionInicial.x = posicionInicial.x - 1;
        }
        if (posicionActual.y >= posicionInicial.y + 1 && Fantasma_Baboso.sube)
        {
            if (encima == false)
            {
                nuevaBaba = Instantiate(baba, posicionInicial + new Vector3(0, 1, 1), transform.rotation);
                Baba.comprueba = true;
                Debug.Log("Creando Baba:" + posicionInicial.x + " " + posicionInicial.y);
            }
            posicionInicial.y = posicionInicial.y + 1;
        }

        if (posicionActual.y <= posicionInicial.y - 1 && Fantasma_Baboso.baja)
        {
            if (encima == false)
            {
                nuevaBaba = Instantiate(baba, posicionInicial + new Vector3(0, -1, 1), transform.rotation);
                Baba.comprueba = true;
                Debug.Log("Creando Baba:" + posicionInicial.x + " " + posicionInicial.y);
            }
            posicionInicial.y = posicionInicial.y - 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Baba"))
        {
            //Si el creababas esta encima de una, activa la variable encima para no superponer babas
            encima = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Baba"))
        {
            //Esta la sigue activando por seguridad
            encima = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Cuando sale la desactiva
        if (collision.gameObject.CompareTag("Baba"))
        {
            encima = false;
        }
    }
    public void Retarda()
    {
        posicionInicial = transform.position;
        nuevaBaba = Instantiate(baba, transform.position + new Vector3(0, 0, 1), transform.rotation);
    }
}