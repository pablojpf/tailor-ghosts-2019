using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class SonidoFantasmas : MonoBehaviour
{
    public AudioClip sonidoMovimiento;
    AudioSource fuenteSonido;

    private int numeroPrivado = 1;
    public int numeroPublico = 1;
    public static int numeroEstatico = 1;

    private void Start()
    {
        //Le decimos que la variable de audiosource es el audiosource que lleva el objeto de este script
        fuenteSonido = GetComponent<AudioSource>();
    }

    public void SonidoMover()
    {
        fuenteSonido.clip = sonidoMovimiento;
        fuenteSonido.Play();
    }

    private void Update()
    {
        numeroEstatico = numeroPublico;
    }
    public static void Hola()
    {
        Debug.Log("Hola");
    }
}
