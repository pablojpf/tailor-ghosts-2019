using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coordinados : MonoBehaviour
{
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Abajo, la dirección y velocidad del rb que lleve el script, será igual que la del primero de los gameObjects que sea movido
    void Update()
    {
        //rb.velocity = Movimientos.direccion;
    }


}
