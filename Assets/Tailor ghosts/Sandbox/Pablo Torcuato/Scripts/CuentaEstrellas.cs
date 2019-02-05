using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CuentaEstrellas : MonoBehaviour
{
    public static int estrellas = 0;
    public bool puedesGanar = false;
    public Text cantidad;
    // Start is called before the first frame update
    void Start()
    {
        cantidad.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        if(estrellas == 3)
        {
            puedesGanar = true;
        }
        cantidad.text = estrellas.ToString();
    }
}
