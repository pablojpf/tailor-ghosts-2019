using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baba : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.transform.CompareTag("Normal"))
        {
            col.gameObject.transform.position = transform.position;
            col.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.rigidbody.velocity = Vector2.zero;
    }

}
