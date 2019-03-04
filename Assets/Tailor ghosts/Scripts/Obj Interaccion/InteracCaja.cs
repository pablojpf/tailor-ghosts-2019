using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteracCaja : MonoBehaviour
{

    //
    //Descaramos dos variables que son el humo y las partículas
    //Que se instanciará al destruirse la caja
    //Se las pasaremos por el inspector
    //


    public static bool left = false;
    public static bool right = false;
    public static bool top = false;
    public static bool bot = false; 


    public GameObject humo;
    public GameObject particulas;

    public Transform trLeft;
    public Transform trRight;
    public Transform trTop;
    public Transform trBot; 
    SpriteRenderer sr;
   

    //
    //Al comenzar el nivel llamamos al sprite renderer
    //

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

  
    //
    //Si alguien colisiona con nosotros nos autodestruimos
    //


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Autodestruccion();
    }


    //
    //Instanciamos el humo y las partículas y luego las desactivamos
    //Destruimos el objeto
    //

    public void Autodestruccion()
    {
        GameObject copiaHumo;
        GameObject copiaParticulas;
        sr.enabled = false;

        Destroy(gameObject, 1f);
        /*
                if (left == true)
                {
                    copiaHumo = Instantiate(humo, trRight.position, trRight.rotation);
                    copiaParticulas = Instantiate(particulas, trRight.position, trRight.rotation);
                    copiaHumo.transform.SetParent(transform);
                    copiaParticulas.transform.SetParent(transform);
                }
                if (right == true)
                {
                    copiaHumo = Instantiate(humo, trLeft.position, trLeft.rotation);
                    copiaParticulas = Instantiate(particulas, trRight.position, trRight.rotation);
                    copiaHumo.transform.SetParent(transform);
                    copiaParticulas.transform.SetParent(transform);
                }
                if (top == true)
                {
                    copiaHumo = Instantiate(humo, trBot.position, trBot.rotation);
                    copiaParticulas = Instantiate(particulas, trRight.position, trRight.rotation);
                    copiaHumo.transform.SetParent(transform);
                    copiaParticulas.transform.SetParent(transform);
                }
                if (bot == true)
                {
                    copiaHumo = Instantiate(humo, trTop.position, trTop.rotation);
                    copiaParticulas = Instantiate(particulas, trRight.position, trRight.rotation);
                    copiaHumo.transform.SetParent(transform);
                    copiaParticulas.transform.SetParent(transform);
                }
                */

    }
}
