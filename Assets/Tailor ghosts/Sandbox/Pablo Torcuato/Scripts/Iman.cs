﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SonidoFantasmas))]

public class Iman : MonoBehaviour
{
    public GameObject gc;
    RaycastHit2D hitRight;
    //Con esto hacemos que una variable privada se vea en el editor [SerializeField]
    public LayerMask capas;
    public float distancia = 1f;
    public float velocidad = 5f;
    public float altura;
    public GameObject fantasmaNormal;
    public AudioController_InGame scriptACUnion;

    SonidoFantasmas sonido;

    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.Find("GameController");
        sonido = GetComponent<SonidoFantasmas>();
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
            Debug.Log(col.transform.name);
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
