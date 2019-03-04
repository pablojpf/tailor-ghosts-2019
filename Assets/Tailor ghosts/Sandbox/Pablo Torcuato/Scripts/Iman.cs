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
        Debug.DrawRay(transform.position + new Vector3(0f, altura / 10, 0f), transform.right * distancia, Color.red);
        hitRight = Physics2D.Raycast(transform.position + new Vector3 (0f,altura/10,0f), transform.right, distancia, capas);
        if (hitRight)
        {
            if (hitRight.transform.CompareTag("Player"))
            {
                
                

                hitRight.rigidbody.velocity = Vector2.zero;
                Debug.DrawRay(transform.position, transform.right * distancia, Color.green);
                Vector2 miPosicion = new Vector2(transform.position.x +0.91f, hitRight.transform.position.y);
                Vector2 posicionDelNormal = new Vector2(hitRight.transform.position.x, hitRight.transform.position.y);
               
                hitRight.transform.position = Vector2.MoveTowards(posicionDelNormal, miPosicion, velocidad * Time.deltaTime);
            }
          
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            scriptACUnion.AudioUnion();
            if (col.transform.parent != transform)
            {
                GameObject copiaNormal;
                copiaNormal = Instantiate(fantasmaNormal, transform.position, transform.rotation);
                copiaNormal.transform.SetParent(col.transform);
                copiaNormal.GetComponent<Rigidbody2D>().simulated = false;
                gc.GetComponent<GameController_ingame>().RestarFantasmas();
                Destroy(gameObject);
                //Si no desactivamos el rigidbody del fantasma al que nos unimos, solo se moverá 1
            }
        }
    }
}
