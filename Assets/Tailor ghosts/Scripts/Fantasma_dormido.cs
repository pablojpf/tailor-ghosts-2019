using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fantasma_dormido : MonoBehaviour
{

    public GameObject fantasmaNormal;
    public GameObject gc;

    Fantasma_dormido scriptFantasmaDormido;
    //public AudioController_InGame scriptACUnion;

    private void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.CompareTag("Player"))
        {
            GameObject fnuevoNormal;
            Debug.Log("choco"+ col.transform.name);
           // scriptACUnion.AudioUnion();

            fnuevoNormal= Instantiate(fantasmaNormal, transform.position, transform.rotation);
            fnuevoNormal.transform.SetParent(col.transform);
            Destroy(fnuevoNormal.GetComponent<Rigidbody2D>());
            Destroy(fnuevoNormal.GetComponent<Fantasma_normal>());
            gc.GetComponent<GameController_ingame>().RestarFantasmas();
            Destroy(gameObject);
        }
    }

    
}
