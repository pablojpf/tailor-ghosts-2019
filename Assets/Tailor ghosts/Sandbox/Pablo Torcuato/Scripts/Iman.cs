using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SonidoFantasmas))]

public class Iman : MonoBehaviour
{
    public GameObject gc;
    //Variable del raycast
    RaycastHit2D hitRight;
    //Con esto hacemos que una variable privada se vea en el editor [SerializeField]
    //Esta es una variable que se le pasa al raycast para que ignore colisiones en ciertas capas
    public LayerMask capas;
    //Distancia del rayo del raycast
    public float distancia = 1f;
    //Velocidad de atracción a la costurera
    public float velocidad = 5f;
    //Altura a la que se lanza el raycast para que detecte al jugador antes o después
    public float altura;
    //Prefab del normal para crearlo cuando te unes
    public GameObject fantasmaNormal;
    //Script con el que reproducimos el sonido de unión
    public AudioController_InGame scriptACUnion;
    //Sonido de la costurera
    SonidoFantasmas sonido;

    // Start is called before the first frame update
    void Start()
    {
        //Busca el gameController en la escena
        gc = GameObject.Find("GameController");
        //Sonido es un script que lleva el gameobject que posee este script
        sonido = GetComponent<SonidoFantasmas>();
        //Activa una funcion del Script "Sonido"
        sonido.SonidoMover();
    }

    // Update is called once per frame
    void Update()
    {
        //Cada frame, muestra un rayo de color rojo para demostrar que NO esta detectando nada
        Debug.DrawRay(transform.position + new Vector3(0f, altura / 10, 0f), transform.right * distancia, Color.red);
        //Aqui lanzamos un raycast de verdad de la misma distancia que el rojo mostrado antes
        hitRight = Physics2D.Raycast(transform.position + new Vector3 (0f,altura/10,0f), transform.right, distancia, capas);
        if (hitRight)
        {
            //Si detecta una colisión, comprueba si el que detecta tiene el tag de player
            if (hitRight.transform.CompareTag("Player"))
            {
                
                
                //Detiene al objeto que detecta 
                hitRight.rigidbody.velocity = Vector2.zero;
                //Muestra un rayo verde en el editor
                Debug.DrawRay(transform.position, transform.right * distancia, Color.green);
                //Establece 2 vectores, uno de la posicion de la costurera y otro del player que detecta su imán para hacer un MoveTowards
                Vector2 miPosicion = new Vector2(transform.position.x +0.91f, hitRight.transform.position.y);
                Vector2 posicionDelNormal = new Vector2(hitRight.transform.position.x, hitRight.transform.position.y);
                //Une al jugador con la costurera a traves de un MoveTowards
                hitRight.transform.position = Vector2.MoveTowards(posicionDelNormal, miPosicion, velocidad * Time.deltaTime);
            }
          
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        //Esto está, para cuando termine de atraer al player y choque con la costurera, que ejecute lo siguiente:
        if (col.gameObject.CompareTag("Player"))
        {
            //Activa el sonido de la union
            scriptACUnion.AudioUnion();
            //Si el padre del transform del objeto con el que choco es distinto al mio...
            if (col.transform.parent != transform)
            {
                //Creamos una variable de gameobject para mas tarde interactuar directamente con ella
                GameObject copiaNormal;
                //Hacemos una copia del fantasma normal
                copiaNormal = Instantiate(fantasmaNormal, transform.position, transform.rotation);
                //Convertimos la copia en hijo del Player con el que inicialmente hemos chocado
                copiaNormal.transform.SetParent(col.transform);
                //Obtenemos el rigidbody del fantasma normal y lo desactivamos
                copiaNormal.GetComponent<Rigidbody2D>().simulated = false;
                //Restamos un fantasma al gamecontroller para poder terminar el nivel
                gc.GetComponent<GameController_ingame>().RestarFantasmas();
                //Destruimos a la costurera
                Destroy(gameObject);
                //Si no desactivamos el rigidbody del fantasma al que nos unimos, solo se moverá 1
            }
        }
    }
}
