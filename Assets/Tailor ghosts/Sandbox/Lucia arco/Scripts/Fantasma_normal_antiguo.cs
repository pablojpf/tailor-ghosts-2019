﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mech_normal1 : MonoBehaviour
{
    //Creamos dos vectores, uno para detectar dónde pulso por primera vez
    //y dónde suelto para más tarde calcular la diferencia entre esas posiciones

    new Vector3 pincho;
    new Vector3 suelto;

    //Declaramos una velocidad 
    //Y un booleano para saber si podemos movernos o no para así impedir
    //que el jugador pueda mover el fantasma mientras este realiza su trayectoria

    public float velocidad = 10f;
    public bool puedoMoverme = true;

    //Declaramos el rb del fantasma
    Rigidbody2D rb;

    void Start()
    {
        //Obtenemos el rb de el fantasma
        rb = GetComponent<Rigidbody2D>();
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
    private void OnCollisionEnter2D(Collision2D col)
    {
        puedoMoverme = true;
        
    }
}
