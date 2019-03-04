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

    //Este es
    AudioSource ManagerMusica;

    public static MusicManager instance = null;


    // Start is called before the first frame update
    void Start()
    {
        ManagerMusica = gameObject.GetComponent<AudioSource>();
        ManagerMusica.clip = musica_menus;
        ManagerMusica.Play();
    }


    void Awake()
    {
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
        musicaActiva = !musicaActiva;


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
