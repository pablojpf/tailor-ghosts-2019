using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuertote : MonoBehaviour
{
    //Variables del personaje
    Rigidbody2D rb;
    public float velocidad = 10f;
    bool puedoMoverme = true;

    //Variables de la acción
    float ejeX = 0f;
    float ejeY = 0f;

    //Variables de los Controles
    new Vector3 pincho;
    new Vector3 suelto;





    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        puedoMoverme = true;
        rb.velocity = Vector2.zero;
        if (col.gameObject.CompareTag("Bloque"))
        {
            col.gameObject.transform.Translate(new Vector3(ejeX ,ejeY , 0f));
            ejeX = 0f;
            ejeY = 0f;
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
}
