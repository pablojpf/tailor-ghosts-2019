using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fantasma_Vikingo : MonoBehaviour
{
    //
    //Este personaje se mueve tal y como un personaje normal 
    //Pero si choca con un bloque lo mueve una unidad de unity en esa direccion
    //Si el objeto con el que choca es un fantasma normal instanciamos un fantasma normal
    //y destruye el mismo
    //



    public float ejeX = 0f;
    public float ejeY = 0f;

    Fantasma_normal1 scriptFantasmaNormal;
    public GameObject fantasmaNormal;
    GameObject gc;
    private void Awake()
    {
        gc = GameObject.Find("GameController");
        if (gc == null)
        {
            Debug.LogError("No encuntro el GameController");
        }
    }
    private void Start()
    {
        scriptFantasmaNormal = GetComponent<Fantasma_normal1>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
      
        if (col.gameObject.CompareTag("Bloque"))
        {
            if (scriptFantasmaNormal.direccion.x > 0)
            {
                ejeX = 1;
            }else if(scriptFantasmaNormal.direccion.x < 0)
            {
                ejeX = -1;
            }
            else if (scriptFantasmaNormal.direccion.y > 0)
            {
                ejeY = 1;
            }
            else if (scriptFantasmaNormal.direccion.y < 0)
            {
                ejeY = -1;
            }

            col.gameObject.transform.position = col.gameObject.transform.position + new Vector3(ejeX, ejeY, 0f);
            //ejeX = 0f;
            //ejeY = 0f;
        }
        else if (col.gameObject.CompareTag("Player"))
        {
           
             col.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            


            if (col.transform.parent != transform)
            {

                GameObject nuevoFantasma;
                nuevoFantasma = Instantiate(fantasmaNormal, transform.position, transform.rotation);
                nuevoFantasma.transform.SetParent(col.transform);

                Destroy(nuevoFantasma.GetComponent<Rigidbody2D>());


                
                Destroy(gameObject);
            }


        }
        
       
    }

    
 
    
}
