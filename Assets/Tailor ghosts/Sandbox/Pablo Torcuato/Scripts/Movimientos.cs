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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (puedoMoverme)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                rb.velocity = new Vector2(1, 0) * velocidad;
                puedoMoverme = false;              
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                rb.velocity = new Vector2(-1, 0) * velocidad;
                puedoMoverme = false;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                rb.velocity = new Vector2(0, -1) * velocidad;
                puedoMoverme = false;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                rb.velocity = new Vector2(0, 1) * velocidad;
                puedoMoverme = false;
            }
        }
        //La variable dirección se declara como la dirección de nuestro objeto
        direccion = rb.velocity;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        puedoMoverme = true;
    }
}
