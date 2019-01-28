using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baboso : MonoBehaviour
{
    public GameObject baba;
    Vector2 posicionActual;
    Vector2 posicionInicial;
    Rigidbody2D rb;
    GameObject nuevaBaba;
    // Start is called before the first frame update
    void Start()
    {
        posicionInicial = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        posicionActual = transform.position;
        if (Input.GetKeyDown(KeyCode.S))
        {
            rb.velocity = Vector2.down;


            nuevaBaba = Instantiate(baba, transform.position, transform.rotation);
            
        }
        if(posicionActual.y <= posicionInicial.y -1)
        {
            nuevaBaba = Instantiate(baba, transform.position, transform.rotation);
            posicionInicial.y = posicionInicial.y - 1;
        }
    }
}
