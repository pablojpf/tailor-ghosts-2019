using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cremallera : MonoBehaviour
{
    //Cargamos los dos gameobjects que van a llevar los sprites de cremallera
    public GameObject cremallera;
    public GameObject cremalleraVertical;
    //Mascara para el raycast
    public LayerMask capasRaycast;
    //Raycast en las 4 direcciones
    RaycastHit2D hitRight;
    RaycastHit2D hitLeft;
    RaycastHit2D hitTop;
    RaycastHit2D hitBot;
    //Variables de deteccion del raycast
    public bool right = false;
    public bool left = false;
    public bool top = false;
    public bool bot = false;
    //Variables de union (para no sobreponer cremalleras)
    public bool unidoRight = false;
    public bool unidoLeft = false;
    public bool unidoTop = false;
    public bool unidoBot = false;

    void Start()
    {
        //Justo al empezar comprueba, porque hay niveles que empiezan con los fantasmas ya unidos
        Comprobador();
    }

    void Update()
    {
        
    }

    public void Comprobador()
    {
        //Creamos como con todas las instancias una copia para poder interactuar directamente despues
        GameObject copiaCremallera;
        //RayCast Derecho
        Debug.DrawRay(transform.position + new Vector3(0.6f, 0, 0), transform.right * 0.5f, Color.red);
        hitRight = Physics2D.Raycast(transform.position + new Vector3(0.6f, 0, 0), transform.right, 0.6f, capasRaycast);
        if (hitRight)
        {
            //Si detectamos a un Player con el raycast y no tenemos padre, nos convertimos en su hijo
            if (hitRight.transform.CompareTag("Player") && transform.parent != null)
            {
                //Si nuestro padre es el objeto que ha detectado el raycast
                if (transform.parent == hitRight.transform)
                {
                    //Activamos la colision en la derecha y si no estabamos unidos anteriormente, creamos la cremallera y la hacemos nuestra hija
                    Debug.DrawRay(transform.position, transform.right * 0.6f, Color.green);
                    right = true;
                    if (unidoRight == false)
                    {
                        copiaCremallera = Instantiate(cremallera, transform.position, transform.rotation);
                        copiaCremallera.transform.SetParent(transform);
                        copiaCremallera.transform.localPosition += new Vector3(0.5f, 0, 0);
                        unidoRight = true;
                    }
                }

                
            }
            else
            {
                Debug.LogWarning(transform.name + ":"+hitRight.transform.name);
            }

            //El resto de lineas son iguales que esta pero en las direcciones restantes
        }
        //RayCast Izquierdo
        Debug.DrawRay(transform.position - new Vector3(0.6f, 0, 0), transform.right * -0.5f, Color.red);
        hitLeft = Physics2D.Raycast(transform.position - new Vector3(0.6f, 0, 0), transform.right * -1, 0.6f, capasRaycast);
        if (hitLeft)
        {

            if (hitLeft.transform.CompareTag("Player") && transform.parent != null)
            {
                if (transform.parent == hitLeft.transform)
                {
                    Debug.DrawRay(transform.position, transform.right * -0.6f, Color.green);
                    left = true;
                    if (unidoLeft == false)
                    {
                        copiaCremallera = Instantiate(cremallera, transform.position, transform.rotation);
                        copiaCremallera.transform.SetParent(transform);
                        copiaCremallera.transform.localPosition -= new Vector3(0.5f, 0, 0);
                        unidoLeft = true;
                    }
                }

            }

        }
        //RayCast Superior
        Debug.DrawRay(transform.position + new Vector3(0, 0.6f, 0), transform.up * 0.5f, Color.red);
        hitTop = Physics2D.Raycast(transform.position + new Vector3(0, 0.6f, 0), transform.up, 0.6f, capasRaycast);
        if (hitTop)
        {

            if (hitTop.transform.CompareTag("Player") && transform.parent != null )
            {
                Debug.DrawRay(transform.position, transform.up * 0.6f, Color.green);
                if(transform.parent == hitTop.transform)
                {
                    top = true;
                    if (unidoTop == false)
                    {
                        copiaCremallera = Instantiate(cremalleraVertical, transform.position, transform.rotation);
                        copiaCremallera.transform.SetParent(transform);
                        copiaCremallera.transform.localPosition += new Vector3(0, 0.5f, 0);
                        unidoTop = true;
                    }
                }

            }

        }
        //RayCast Inferior
        Debug.DrawRay(transform.position - new Vector3(0, 0.6f, 0), transform.up * -0.5f, Color.red);
        hitBot = Physics2D.Raycast(transform.position - new Vector3(0, 0.6f, 0), transform.up * -1, 0.6f, capasRaycast);
        if (hitBot)
        {

            if (hitBot.transform.CompareTag("Player") && transform.parent != null)
            {
                if (transform.parent == hitBot.transform)
                {
                    Debug.DrawRay(transform.position, transform.up * -0.6f, Color.green);
                    bot = true;
                    if (unidoBot == false)
                    {
                        copiaCremallera = Instantiate(cremalleraVertical, transform.position, transform.rotation);
                        copiaCremallera.transform.SetParent(transform);
                        copiaCremallera.transform.localPosition -= new Vector3(0, 0.5f, 0);
                        unidoBot = true;
                    }
                }

            }

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Comprobador();
    }
}
