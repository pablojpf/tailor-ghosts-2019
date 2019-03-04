using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;



[RequireComponent(typeof(SonidoFantasmas))]
public class Fantasma_normal : MonoBehaviour
{
    public GameObject gc;

    //Creamos dos vectores, uno para detectar dónde pulso por primera vez
    //y dónde suelto para más tarde calcular la diferencia entre esas posiciones

    Vector3 pincho;
    Vector3 suelto;


    public AudioController_InGame scriptACUnion;

    SonidoFantasmas sonido;

    //Declaramos una velocidad 
    //Y un booleano para saber si podemos movernos o no para así impedir
    //que el jugador pueda mover el fantasma mientras este realiza su trayectoria

    public float velocidad = 10f;
    public bool puedoMoverme = true;

    Fantasma_normal scriptFantasma;

    //Declaramos el rb del fantasma
    Rigidbody2D rb;

    void Start()
    {
        //Obtenemos el rb de el fantasma
        rb = GetComponent<Rigidbody2D>();
        scriptFantasma = GetComponent<Fantasma_normal>();
        sonido = GetComponent<SonidoFantasmas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Funcion para poder moverme
     void Mover()
     {

        //Declaramos un vector que obtenga la diferencia 
        //Entre la posición donde pinchamos y dónde soltamos
        //para saber la dirección en la que irá nuestro personaje

         Vector3 dif = suelto - pincho;

         if (puedoMoverme)
         {

            //Si el valor absoluto en x es mayor que el valor absoluto en y
            //Entonces la velocidad irá en el eje x
            //dependiendo de si la dirección es positiva o negativa irá hacia arriba o hacia abajo
             if (Mathf.Abs(dif.x) > Mathf.Abs(dif.y))
             {
                 if(dif.x>0){
                     rb.velocity = new Vector2(1, 0) * velocidad;
                 }
                 else
                 {
                     rb.velocity = new Vector2(-1, 0) * velocidad;
                 }

                 puedoMoverme = false;
             }
            //Si no, la velocidad irá en el eje y
            //dependiendo de si la dirección es positiva o negativa irá hacia derecha o izquierda
            else
            {
                 if (dif.y>0)
                 {
                     rb.velocity = new Vector2(0, 1) * velocidad;
                 }
                 else
                 {
                     rb.velocity = new Vector2(0, -1) * velocidad;
                 }

                 puedoMoverme = false;
             }

         }


        sonido.SonidoMover();


     }

    //Cuando pincho obtengo la posición donde he pinchado y la guardo en el vector pincho
    void OnMouseDown()
    {
        pincho = Input.mousePosition;
    }
    //Cuando suelto obtengo la posición donde he soltado y la guardo en el vector suelto
    void OnMouseUp()
    {
        suelto = Input.mousePosition;
        Mover();
       
    }

    //Cuando choco con un colider puedo volver a moverme
    //Si este collider es de tipo Player lo convierto en mi hijo si no lo es en ese instante
    //le destruyo a mi hijo el rb y el script para que sea un sprite 
    //resto del numero de fantasmas en pantalla y puedo volver a moverme


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (!col.transform.parent==transform)
            {
                transform.SetParent(col.transform);
                Destroy(scriptFantasma);
                Destroy(rb);
                Debug.Log("me resto");
                gc.GetComponent<GameController_ingame>().RestarFantasmas();
            }
            //scriptACUnion.AudioUnion();
            rb.velocity = Vector2.zero;
        }
        else
        {
            puedoMoverme = true;
            rb.velocity = Vector2.zero;
        }


    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        puedoMoverme = true;
    }
}
