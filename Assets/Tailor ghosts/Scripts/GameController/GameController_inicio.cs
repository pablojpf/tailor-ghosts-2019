using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameController_inicio : MonoBehaviour
{
    public Animator anim_UIajustes;
    public Animator anim_MenuLogros;
    public Animator anim_MusicaOnOff;
    public Animator anim_SonidoOnOff;
    public Button botonPlay;

    private bool sonidoActivo = true;
    private bool musicaActiva = true;


    public AudioSource sonido_play;
    public AudioSource sonido_ajustes;
    public AudioSource sonido_atras;


    void Start()
    {
        DontDestroyOnLoad(gameObject);
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Ajustes()
    {
        sonido_ajustes.Play(0);

        
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
    public void SonidoAdelante()
    {
        sonido_play.Play(0);
       
    }
    public void SonidoAtras()
    {
        sonido_atras.Play(0);
        
    }

    
    public void Sonidoonoff()
    {

        sonidoActivo = !sonidoActivo;
        anim_SonidoOnOff.SetBool("activar", sonidoActivo);
    }

    public void Musicaonoff()
    {
        musicaActiva = !musicaActiva;
        anim_MusicaOnOff.SetBool("activar", musicaActiva);
     
    }


    


}
