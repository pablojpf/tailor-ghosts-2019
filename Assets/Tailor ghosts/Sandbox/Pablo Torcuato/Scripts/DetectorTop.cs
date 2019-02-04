using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorTop : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        InteracCaja.top = true;
        Invoke("Retorna", 0.3f);
    }
    public void Retorna()
    {
        InteracCaja.top = false;
    }
}
