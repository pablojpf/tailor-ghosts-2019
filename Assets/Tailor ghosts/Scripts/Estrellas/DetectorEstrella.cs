using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorEstrella : MonoBehaviour
{
    //
    //Controlamos las animaciones de las estrellas ingame, si un player toca la estrella esta se ilumina
    //y nos suma + 1 al contador
    //Cuando sale de la estrella esta se desactiva y cambia el numero de estrellas
    //



    bool estrellaActiva = false;
    Animator anim_estrellas;

    // Start is called before the first frame update
    void Start()
    {
        GameController_ingame.estrellas = 0;
        anim_estrellas = GetComponent<Animator>();
        anim_estrellas.SetBool("activar", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") && !estrellaActiva)
        {
            if(estrellaActiva == false)
            {
                anim_estrellas.SetBool("activar", true);
                GameController_ingame.estrellas++;
            }
            estrellaActiva = true;
            
            
            
            
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            estrellaActiva = false;
            GameController_ingame.estrellas--;
            anim_estrellas.SetBool("activar", false);
        }
    }
}
