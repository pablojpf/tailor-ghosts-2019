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
    public float volumenMusicaActual;
    public float volumenFxActual;

    private bool sonidoActivo = true;
    private bool musicaActiva = true;
    private bool musica_menu = true;

    public AudioMixer audioM;
    public AudioMixerGroup Musica;
    public AudioMixerGroup Fx;

    public static GameController_inicio instance = null;

    void Start()
    {
        if (PlayerPrefs.HasKey("volumenFX"))
        {
            volumenFxActual = PlayerPrefs.GetFloat("volumenFX");
            
        }
        else
        {
            volumenFxActual = 0f;
            audioM.SetFloat("volumenFX", volumenFxActual);
            PlayerPrefs.Save();
        }

        if (PlayerPrefs.HasKey("volumenMusica"))
        {
            volumenMusicaActual = PlayerPrefs.GetFloat("volumenMusica");

        }
        else
        {
            volumenMusicaActual = 0f;
            audioM.SetFloat("volumenFX", volumenFxActual);
            PlayerPrefs.Save();
        }

      

        audioM.SetFloat("volumenFX", volumenFxActual);
        audioM.SetFloat("volumenMusica", volumenMusicaActual);


        if(volumenFxActual == 0)
        {
            sonidoActivo = true;
           
        }
        else
        {
            sonidoActivo = false;
        }

        if (volumenMusicaActual== 0)
        {
            musicaActiva = true;

        }
        else
        {
            musicaActiva = false;
        }

        anim_SonidoOnOff.SetBool("activar", sonidoActivo);
        anim_MusicaOnOff.SetBool("activar", musicaActiva);
       
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
            volumenFxActual = 0f;
            audioM.SetFloat("volumenFX", volumenFxActual);
        }
        else
        {
            volumenFxActual = -80f;
            audioM.SetFloat("volumenFX", volumenFxActual);
        }
        PlayerPrefs.SetFloat("volumenFX", volumenFxActual);
        PlayerPrefs.Save();
    }

    public void Musicaonoff()
    {
        musicaActiva = !musicaActiva;
        anim_MusicaOnOff.SetBool("activar", musicaActiva);

        if(musicaActiva)
        {
            volumenMusicaActual = 0f;
            audioM.SetFloat("volumenMusica", volumenMusicaActual);
        }
        else
        {
            volumenMusicaActual = -80f;
            audioM.SetFloat("volumenMusica", volumenMusicaActual);
        }
        PlayerPrefs.SetFloat("volumenMusica", volumenMusicaActual);
        PlayerPrefs.Save();
    }

    private void OnDestroy()
    {
        PlayerPrefs.Save();
    }
}

    
   
    
   

    
    



