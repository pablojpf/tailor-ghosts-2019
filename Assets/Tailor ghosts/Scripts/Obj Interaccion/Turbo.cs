using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turbo : MonoBehaviour
{

    //
    //Declaramos una direccion
    //una velocidad y el rigidbody
    //


    public Vector3 vectorTurbo;
    public float velocidad = 15f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //
    //Cuando un objeto entra en nuestro trigger le añadimos 
    //la velocidad en la dirección en la que está apuntando 
    //

    void OnTriggerEnter2D(Collider2D col)
    {
        rb=col.gameObject.GetComponent<Rigidbody2D>();
        col.transform.position = transform.position;
        rb.velocity=(transform.up * -velocidad);
    }
}
