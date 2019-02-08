using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorEstrella : MonoBehaviour
{
    bool estrellaActiva = false;
    
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
        if (col.gameObject.CompareTag("Player") && !estrellaActiva)
        {
            GameController_ingame.estrellas++;
            Debug.Log("unaestrella");
            estrellaActiva = true;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
<<<<<<< HEAD:Assets/Tailor ghosts/Scripts/Estrellas/DetectorEstrella.cs
            estrellaActiva = false;
            GameController_ingame.estrellas--;
=======
            CuentaEstrellas.estrellas--;

>>>>>>> dcd064b538dd734818fe7c323ffa9e4dea463edb:Assets/Tailor ghosts/Sandbox/Pablo Torcuato/Scripts/DetectorEstrella.cs
        }
    }
}
