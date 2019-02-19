using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botonUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SonidoDeAtras()
    {
        SoundManager.instance.SonidoAtras();
    }


    public void SonidoDeAdelante()
    {
        SoundManager.instance.SonidoAdelante();
    }


    

}
