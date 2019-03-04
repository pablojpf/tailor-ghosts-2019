using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurboDer : MonoBehaviour
{

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
    //Va en direccion derecha
    //


    void OnTriggerEnter2D(Collider2D col)
    {
        rb = col.gameObject.GetComponent<Rigidbody2D>();
        col.transform.position = transform.position;
        rb.velocity = (transform.right * velocidad);
    }
}
