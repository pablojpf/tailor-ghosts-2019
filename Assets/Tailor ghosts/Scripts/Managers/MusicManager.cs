using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{

    //Declaramos las funciones que nos dirán si la música está activada o no en cada modo
    private bool musicaActiva = true;
    private bool musica_menu = true;

    //Aquí declaramos el audioMixer para poder jugar con los valores del volumen, va acompañado de su grupo.
    public AudioMixer audioM;
    public AudioMixerGroup Musica;

    //Aquí declaramos todos los clips de audio que va a reproducir nuestro audioSource
    public AudioClip musica_menus;
    public AudioClip musica_mundo1;
    public AudioClip musica_mundo2;
    public AudioClip musica_mundo3;
    public AudioClip musica_mundo4;
    public AudioClip musica_mundo5;

    //Este es el que va a reproducir los clips de audio (es, de algún modo, el altavoz)
    AudioSource ManagerMusica;

    public static MusicManager instance = null;


    // Start is called before the first frame update
    void Start()
    {
        //Obtenemos el audioSource del objeto que lleva el script
        ManagerMusica = gameObject.GetComponent<AudioSource>();
        //Le pasamos el clip de musica del menú y lo reproducimos al empezar
        ManagerMusica.clip = musica_menus;
        ManagerMusica.Play();
        
    }


    void Awake()
    {
        //Si el music Manager no existe en la escena, pasa a ser el que hay, si no, lo destruye y mantiene el que hay entre escenas.
        if (instance == null)
        {
            instance = this;
        }else if (instance != this)
        {
            Destroy(gameObject);
        }  
        DontDestroyOnLoad(gameObject);
    }




    // Update is called once per frame
    void Update()
    {
        
    }


    //En las siguientes funciones se hace lo mismo, se cambia el audioClip que se va a reproducir según el nivel y se reproduce.

    public void MusicaM1()
    {
        ManagerMusica.clip = musica_mundo1;
        ManagerMusica.Play();
    }


    public void MusicaM2()
    {
        ManagerMusica.clip = musica_mundo2;
        ManagerMusica.Play();
    }


    public void MusicaM3()
    {
        ManagerMusica.clip = musica_mundo3;
        ManagerMusica.Play();
    }


    public void MusicaM4()
    {
        ManagerMusica.clip = musica_mundo4;
        ManagerMusica.Play();
    }


    public void MusicaM5()
    {
        ManagerMusica.clip = musica_mundo5;
        ManagerMusica.Play();
    }

    public void MusicaMenu()
    {
        ManagerMusica.clip = musica_menus;
        ManagerMusica.Play();
    }



    public void Musicaonoff()
    {
        //Alterna el valor de la booleana activada cada vez que se llama a la funcion, sería como darle a un interruptor de la luz: enciende/apaga.
        musicaActiva = !musicaActiva;

        //Comprueba si la música está activada, y si lo está, accede a una variable pública que anteriormente se ha creado desde el audioMixer en el editor y ajusta su volumen normal (0 dB).Si está desactivada, le pone -80dB (le quita el volumen).
        if (musicaActiva)
        {
            audioM.SetFloat("volumenMusica", 0);
        }
        else
        {
            audioM.SetFloat("volumenMusica", -80);
        }
    }
}
