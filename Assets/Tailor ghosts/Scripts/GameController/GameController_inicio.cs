using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;


public class GameController_inicio : MonoBehaviour
{
    //
    //Game Controller que nos permite avanzar por el menu de inicio
    //Cambia la música dependiendo del botón que toquemos
    //Controles del audiomixer
    //



    public Animator anim_UIajustes;
    public Animator anim_MenuLogros;
    public Animator anim_MusicaOnOff;
    public Animator anim_SonidoOnOff;
    public Button botonPlay;

    private bool sonidoActivo = true;
    private bool musicaActiva = true;
    private bool musica_menu = true;

    public AudioMixer audioM;
    public AudioMixerGroup Musica;
    public AudioMixerGroup Fx;

    public static GameController_inicio instance = null;

    void Start()
    {
        

    }

    


    // Update is called once per frame
    void Update()
    {
        
    }

   

    public void Ajustes()
    {
       


        anim_UIajustes.SetBool("activar", true);
        anim_MenuLogros.SetBool("activar", false);
        botonPlay.interactable = false;

    }

    public void Menulogros()
    {

        anim_UIajustes.SetBool("activar", false);
        anim_MenuLogros.SetBool("activar", true);
        botonPlay.interactable = true;
    }
    

    

    


    public void Sonidoonoff()
    {

        sonidoActivo = !sonidoActivo;
        anim_SonidoOnOff.SetBool("activar", sonidoActivo);

        if (sonidoActivo)
        {
            audioM.SetFloat("volumenFX", 0);
        }
        else
        {
            audioM.SetFloat("volumenFX", -80);
        }
    }

    public void Musicaonoff()
    {
        musicaActiva = !musicaActiva;
        anim_MusicaOnOff.SetBool("activar", musicaActiva);

        if(musicaActiva)
        {
            audioM.SetFloat("volumenMusica", 0);
        }
        else
        {
            audioM.SetFloat("volumenMusica", -80);
        }
    }


    }

    
   
    
   

    
    



