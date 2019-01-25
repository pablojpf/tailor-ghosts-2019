using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mech_desnudo : MonoBehaviour
{
    /*La diferencia entre este script y el normal son las que 
     * comentaré a continuacion
     */

    public GameObject playerNormal;
    public float velocidad = 10f;
    public bool puedoMoverme = true;
    Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

  
    void Update()
    {
        Mover();
    }
    void Mover()
    {
        if (puedoMoverme)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rb.velocity = new Vector2(1, 0) * velocidad;
                puedoMoverme = false;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb.velocity = new Vector2(-1, 0) * velocidad;
                puedoMoverme = false;
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb.velocity = new Vector2(0, 1) * velocidad;
                puedoMoverme = false;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                rb.velocity = new Vector2(0, -1) * velocidad;
                puedoMoverme = false;
            }
            //Debug.Log(rb.velocity);
        }

    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        puedoMoverme = true;

        //Si el objeto con el que choco tiene el Tag TELA entonces me convierto en un
        //fantasma de tipo normal, lo instanciamos y destruimos el desnudo
        if (col.gameObject.CompareTag("Tela"))
        {
            Instantiate(playerNormal, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
