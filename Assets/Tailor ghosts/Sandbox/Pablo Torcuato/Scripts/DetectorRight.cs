using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorRight : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        InteracCaja.right = true;
        Invoke("Retorna", 0.3f);
    }
    public void Retorna()
    {
        InteracCaja.right = false;
    }
}
