using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimientos : MonoBehaviour
{
    public float velocidad = 10f;
    Rigidbody2D rb;
    bool puedoMoverme = true;
    //Hacemos una variable estática de tipo vector2 para que sea compatible con el rigidbody.velocity del script "Coordinados"
    public static Vector2 direccion;
    //Variables Controles
    Vector3 pincho;
    Vector3 suelto;
    public GameObject fantasmaNormal;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
      
    }

    // Update is called once per frame
    void Update()
    {

    }
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
    void Mover()
    {
        Vector3 dif = suelto - pincho;

        if (puedoMoverme)
        {

            if (Mathf.Abs(dif.x) > Mathf.Abs(dif.y))
            {
                if (dif.x > 0)
                {
                    rb.velocity = new Vector2(1, 0) * velocidad;
                    direccion = Vector2.zero;
                    direccion = rb.velocity;
                }
                else
                {
                    rb.velocity = new Vector2(-1, 0) * velocidad;
                    direccion = Vector2.zero;
                    direccion = rb.velocity;
                }

                puedoMoverme = false;
            }

            else
            {
                if (dif.y > 0)
                {
                    rb.velocity = new Vector2(0, 1) * velocidad;
                    direccion = Vector2.zero;
                    direccion = rb.velocity;
                }
                else
                {
                    rb.velocity = new Vector2(0, -1) * velocidad;
                    direccion = Vector2.zero;
                    direccion = rb.velocity;
                }

                puedoMoverme = false;
            }

        }




    }



    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (!col.transform.parent == transform)
            {
                Instantiate(fantasmaNormal, transform.position, transform.rotation);
                Destroy(gameObject);
            }


        }
        else
        {
            puedoMoverme = true;

        }


    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        puedoMoverme = true;
    }
}
