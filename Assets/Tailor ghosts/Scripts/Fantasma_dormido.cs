using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fantasma_dormido : MonoBehaviour
{
    //Si a este fantasma le toca uno normal, este se despierta y se convierte en uno normal
    //si no, no puede moverse


    public GameObject fantasmaNormal;
    GameObject gc;


    Fantasma_dormido scriptFantasmaDormido;
    public AudioController_InGame scriptACUnion;
    private void Awake()
    {
        gc = GameObject.Find("GameController");
        if (gc == null)
        {
            Debug.LogError("No encuntro el GameController");
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.CompareTag("Player"))
        {
            if (!col.transform.parent == transform)
            {
                GameObject nuevoFantasma;
                nuevoFantasma = Instantiate(fantasmaNormal, transform.position, transform.rotation);
                nuevoFantasma.transform.SetParent(col.transform);

                transform.SetParent(col.transform);
                scriptACUnion.AudioUnion();
                Destroy(nuevoFantasma.GetComponent<Rigidbody2D>());


                gc.GetComponent<GameController_ingame>().RestarFantasmas();
                Destroy(gameObject);

            }
        }
    }

    
}
