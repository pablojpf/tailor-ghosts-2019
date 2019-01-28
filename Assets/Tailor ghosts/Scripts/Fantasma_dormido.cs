using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fantasma_dormido : MonoBehaviour
{
   
    private void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.CompareTag("Player"))
        {
            transform.SetParent(col.transform);
            
        }
    }

    
}
