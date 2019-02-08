using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorEstrella : MonoBehaviour
{
    bool estrellaActiva = false;
    
    // Start is called before the first frame update
    void Start()
    {
        GameController_ingame.estrellas = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") && !estrellaActiva)
        {
            GameController_ingame.estrellas++;
          
            estrellaActiva = true;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            estrellaActiva = false;
            GameController_ingame.estrellas--;
        }
    }
}
