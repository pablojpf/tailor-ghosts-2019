using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuertote : MonoBehaviour
{
    Rigidbody2D rb;
    public float velocidad = 10f;
    bool puedoMoverme = true;
    float ejeX = 0f;
    float ejeY = 0f;
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
                ejeX = 1f;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                rb.velocity = new Vector2(-1, 0) * velocidad;
                puedoMoverme = false;
                ejeX = -1f;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                rb.velocity = new Vector2(0, -1) * velocidad;
                puedoMoverme = false;
                ejeY = -1f;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                rb.velocity = new Vector2(0, 1) * velocidad;
                puedoMoverme = false;
                ejeY = 1f;
            }
        }

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
}
