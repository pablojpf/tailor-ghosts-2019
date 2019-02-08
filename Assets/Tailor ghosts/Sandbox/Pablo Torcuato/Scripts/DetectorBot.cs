using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorBot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        InteracCaja.bot = true;
        Invoke("Retorna", 0.3f);
    }
    public void Retorna()
    {
        InteracCaja.bot = false;
    }
}
