using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fantasma_dormido : MonoBehaviour
{
    
    Fantasma_dormido scriptFantasmaDormido;
    public AudioController_InGame scriptACUnion;

    private void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.CompareTag("Player"))
        {
            scriptACUnion.AudioUnion();
            transform.SetParent(col.transform);           
            Destroy(scriptFantasmaDormido);
        }
    }

    
}
