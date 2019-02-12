using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SonidoFantasmas : MonoBehaviour
{
    public AudioClip sonidoMovimiento;
    AudioSource fuenteSonido; //definimos que vamos a usar los sonidos

    private void Start()
    {
        fuenteSonido = GetComponent<AudioSource>();
    }

    public void SonidoMover()
    {
        fuenteSonido.clip = sonidoMovimiento;
        fuenteSonido.Play();
    }

   
}
