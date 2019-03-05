using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baba : MonoBehaviour
{
    //Vector de la posicion de la baba para atraer al jugador cuando caiga encima
    Vector2 posicionBaba;
    //Booleana para comprobar si esta tocando al player
    bool toca = false;
    Transform posicionPlayer;
    //Declaramos una tabla para pasar todos los sprites de las babas
    public Sprite[] spritesBabas;
    //Declaramos los raycast que vamos a lanzar en todas las direcciones
    RaycastHit2D hitRight;
    RaycastHit2D hitLeft;
    RaycastHit2D hitTop;
    RaycastHit2D hitBot;
    //
    public bool right = false;
    public bool left = false;
    public bool top = false;
    public bool bot = false;
    SpriteRenderer sr;
    public int colisiones = 0;
    bool colRight = false;
    bool colLeft = false;
    bool colTop = false;
    bool colBot = false;
    public static bool comprueba = false;

    // Start is called before the first frame update
    void Start()
    {
        posicionBaba = transform.position;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (toca == true && posicionPlayer.parent == null)
        {
            posicionPlayer.position = Vector2.MoveTowards(posicionPlayer.position, posicionBaba, 0.05f);
            Invoke("Despega", 0.5f);

        }
        if (comprueba == true)
        {
            Comprobador();
            Invoke("Desactiva", 0.4f);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        //Si detecta a un player y este esta dentro de la baba activa toca y el vector para hacer el moveTowards pasa a ser el del player que detecta
        if (col.gameObject.transform.CompareTag("Player") && BabaController.dentro == false)
        {
            posicionPlayer = col.gameObject.transform;
            toca = true;

            Rigidbody2D rbTemp = col.GetComponent<Rigidbody2D>();
            if(rbTemp != null)
            {
                //Si se esta moviendo lo para
                rbTemp.velocity = Vector2.zero;
            }
            //Le decimos al controlador de las babas que hay alguien dentro   
            BabaController.dentro = true;

        }

    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            //Cuando salimos del collider, llamamos a la funcion que indica que estamos fuera de la baba pero queremos que tenga un poco de delay y ponemos 1 segundo
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


    public void Comprobador()
    {
        //Comprobador es una funcion que se activa desde la booleana "Comprueba" y esta a su vez desde el baba controller cada vez que se instancia una baba.

        //RayCast Derecho
        Debug.DrawRay(transform.position + new Vector3(0.6f, 0, 0), transform.right * 0.5f, Color.red);
        hitRight = Physics2D.Raycast(transform.position + new Vector3(0.6f, 0, 0), transform.right, 0.6f);
        if (hitRight)
        {
            //Lanza un raycast a la derecha para comprobar si tiene una baba justo a su derecha, los siguientes raycast hacen lo mismo en las direcciones restantes.
            if (hitRight.transform.CompareTag("Baba"))
            {
                Debug.DrawRay(transform.position, transform.right * 0.6f, Color.green);
                right = true;
                if (colRight == false)
                {
                    //Si detecta una baba y no tenía ninguna anteriormente detectada, suma a 1 al numero de babas que esta baba esta detectando para simplificar el cambio de sprite
                    colisiones++;
                    colRight = true;
                }
            }

        }
        //RayCast Izquierdo
        Debug.DrawRay(transform.position - new Vector3(0.6f, 0, 0), transform.right * -0.5f, Color.red);
        hitLeft = Physics2D.Raycast(transform.position - new Vector3(0.6f, 0, 0), transform.right * -1, 0.6f);
        if (hitLeft)
        {

            if (hitLeft.transform.CompareTag("Baba"))
            {
                Debug.DrawRay(transform.position, transform.right * -0.6f, Color.green);
                left = true;
                if (colLeft == false)
                {
                    colisiones++;
                    colLeft = true;
                }
            }

        }
        //RayCast Superior
        Debug.DrawRay(transform.position + new Vector3(0, 0.6f, 0), transform.up * 0.5f, Color.red);
        hitTop = Physics2D.Raycast(transform.position + new Vector3(0, 0.6f, 0), transform.up, 0.6f);
        if (hitTop)
        {

            if (hitTop.transform.CompareTag("Baba"))
            {
                Debug.DrawRay(transform.position, transform.up * 0.6f, Color.green);
                top = true;
                if (colTop == false)
                {
                    colisiones++;
                    colTop = true;
                }
            }

        }
        //RayCast Inferior
        Debug.DrawRay(transform.position - new Vector3(0, 0.6f, 0), transform.up * -0.5f, Color.red);
        hitBot = Physics2D.Raycast(transform.position - new Vector3(0, 0.6f, 0), transform.up * -1, 0.6f);
        if (hitBot)
        {

            if (hitBot.transform.CompareTag("Baba"))
            {
                Debug.DrawRay(transform.position, transform.up * -0.6f, Color.green);
                bot = true;
                if (colBot == false)
                {
                    colisiones++;
                    colBot = true;
                }
            }

        }

        //Cuando ya hemos terminado de comprobar en todas las direcciones procedemos a hacer el cambio de sprite (si procede)
        CambiaBabas();
    }

    public void CambiaBabas()
    {
        //Para simplificar los cambios de sprite, creamos la condicion dependiendo del numero de babas que haya alrededor de la nuestra,
        //Es decir, si hay 1 baba en nuestro alrededor, solo puede ser arriba, abajo, izquierda o derecha y nunca vamos a ser, por ejemplo, una esquina.
        //Después comprueba la direccion y cambia el sprite que le hemos pasado a la tabla desde el editor (los numeros se ponen de acuerdo con el sprite)

        //1 colision

        if (colisiones == 1)
        {
            if (left == true)
            {
                sr.sprite = spritesBabas[1];
            }
            if (right == true)
            {
                sr.sprite = spritesBabas[2];
            }
            if (top == true)
            {
                sr.sprite = spritesBabas[3];
            }
            if (bot == true)
            {
                sr.sprite = spritesBabas[4];
            }
        }

        //2 colisiones

        if (colisiones == 2)
        {
            //Intermedias
            if (left == true && right == true)
            {
                sr.sprite = spritesBabas[0];
            }
            if (top == true && bot == true)
            {
                sr.sprite = spritesBabas[5];
            }

            //Esquinas
            if (right == true && bot == true)
            {
                sr.sprite = spritesBabas[6];
            }
            if (left == true && bot == true)
            {
                sr.sprite = spritesBabas[7];
            }
            if (right == true && top == true)
            {
                sr.sprite = spritesBabas[8];
            }
            if (left == true && top == true)
            {
                sr.sprite = spritesBabas[9];
            }
        }

        //3 colisiones

        if (colisiones == 3)
        {
            sr.sprite = spritesBabas[11];


            //4 colisiones
            if (right == true && left == true && bot == true && top == true)
            {
                sr.sprite = spritesBabas[10];
            }
        }

    }
    public void Desactiva()
    {
        comprueba = false;
    }
}

