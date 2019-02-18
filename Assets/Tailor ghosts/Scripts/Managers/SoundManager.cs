using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour

{

    private bool sonidoActivo = true;
    private bool musicaActiva = true;
    private bool musica_menu = true;

    public AudioMixer audioM;
    public AudioMixerGroup Musica;
    public AudioMixerGroup Fx;
    public AudioClip sonido_play;
    public AudioClip sonido_ajustes;
    public AudioClip sonido_atras;
    AudioSource ManagerSonido;

    public static SoundManager instance = null;

    // Start is called before the first frame update
    void Start()
    {
       ManagerSonido = gameObject.GetComponent<AudioSource>();
       
    }


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SonidoAdelante()
    {
        ManagerSonido.clip = sonido_play;
        ManagerSonido.Play();


    }



    public void SonidoAtras()
    {
        ManagerSonido.clip = sonido_atras;
        ManagerSonido.Play();

    }


    public void Sonidoonoff()
    {

        sonidoActivo = !sonidoActivo;
        

        if (sonidoActivo)
        {
            audioM.SetFloat("volumenFX", 0);
        }
        else
        {
            audioM.SetFloat("volumenFX", -80);
        }
    }

   

}
