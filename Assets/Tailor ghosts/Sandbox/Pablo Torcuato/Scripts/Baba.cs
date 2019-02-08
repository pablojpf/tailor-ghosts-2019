using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baba : MonoBehaviour
{
    Vector2 posicionBaba;
    bool toca = false;
    Transform posicionPlayer;
    // Start is called before the first frame update
    void Start()
    {
        posicionBaba = transform.position;
       
    }

    // Update is called once per frame
    void Update()
    {
        if(toca == true )
        {
      
            posicionPlayer.position = Vector2.MoveTowards(posicionPlayer.position, posicionBaba, 0.01f);
            Invoke("Despega", 0.5f);
                
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject.transform.CompareTag("Player")&&BabaController.dentro==false)
        {           
            posicionPlayer = col.gameObject.transform;
            toca = true;
            col.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            BabaController.dentro = true;

        }
       
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
            {
            Invoke("Fuera", 1f);
            }
    }

    void Despega()
    {
        toca = false;
    }
    void Fuera()
    {
        BabaController.dentro = false;
    }

}
