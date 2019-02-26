using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SonidoFantasmas))]

public class Fantasma_Vikingo : MonoBehaviour
{
    //Variables del personaje
    Rigidbody2D rb;
    public float velocidad = 10f;
    bool puedoMoverme = true;
    public GameObject fantasmaNormal;
    //Variables de la acción
    float ejeX = 0f;
    float ejeY = 0f;

    //Variables de los Controles
    Vector3 pincho;
    Vector3 suelto;


    public AudioController_InGame scriptACUnion;

    SonidoFantasmas sonido;

    // Start is called before the first frame update
    void Start()
    {
        Reposiciona();
        rb = GetComponent<Rigidbody2D>();
        sonido = GetComponent<SonidoFantasmas>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        Reposiciona();
        rb.velocity = Vector2.zero;
        if (col.gameObject.CompareTag("Bloque"))
        {
            col.gameObject.transform.Translate(new Vector3(ejeX, ejeY, 0f));
            ejeX = 0f;
            ejeY = 0f;
        }
        if (col.gameObject.CompareTag("Player"))
        {
            if (!col.transform.parent == transform)
            {
                scriptACUnion.AudioUnion();
                Instantiate(fantasmaNormal, transform.position, transform.rotation);
                Destroy(gameObject);
            }


        }
        else
        {
            puedoMoverme = true;

        }
    }

    void Mover()
    {
        /*Declaramos un vector que obtenga la diferencia 
        Entre la posición donde pinchamos y dónde soltamos
        para saber la dirección en la que irá nuestro personaje*/

        Vector3 dif = suelto - pincho;

        if (puedoMoverme)
        {

            /*Si el valor absoluto en x es mayor que el valor absoluto en y
            Entonces la velocidad irá en el eje x
            dependiendo de si la dirección es positiva o negativa irá hacia arriba o hacia abajo*/
            if (Mathf.Abs(dif.x) > Mathf.Abs(dif.y))
            {
                if (dif.x > 0)
                {
                    rb.velocity = new Vector2(1, 0) * velocidad;
                    ejeX = 1f;
                }
                else
                {
                    rb.velocity = new Vector2(-1, 0) * velocidad;
                    ejeX = -1f;
                }

                puedoMoverme = false;
            }
            //Si no, la velocidad irá en el eje y
            //dependiendo de si la dirección es positiva o negativa irá hacia derecha o izquierda
            else
            {
                if (dif.y > 0)
                {
                    rb.velocity = new Vector2(0, 1) * velocidad;
                    ejeY = 1f;
                }
                else
                {
                    rb.velocity = new Vector2(0, -1) * velocidad;
                    ejeY = -1f;
                }

                puedoMoverme = false;
            }
        }

        sonido.SonidoMover();

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

    public void Reposiciona()
    {
        if (transform.parent != null)
        {

            transform.localPosition = new Vector3(Mathf.Round(transform.localPosition.x), Mathf.Round(transform.localPosition.y), Mathf.Round(transform.localPosition.z));
        }
        else
        {
            transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
        }

    }
}
