using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorLeft : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D col)
    {
        InteracCaja.left = true;
        Invoke("Retorna", 0.3f);
    }
    public void Retorna()
    {
        InteracCaja.left = false;
    }
}
