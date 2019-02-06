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
    public GameObject botonPlay;


    public AudioSource sonido_play;
    public AudioSource sonido_ajustes;
    public AudioSource sonido_atras;

    private bool sonidoActivo = true;
    private bool musicaActiva = true;



    // Start is called before the first frame update
    void Start()
    {
       
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Ajustes()
    {
        sonido_ajustes.Play(0);

        Debug.Log("ajustes");
        anim_UIajustes.SetBool("activar", true);
        anim_MenuLogros.SetBool("activar", false);
    }

    public void Menulogros()
    {

        anim_UIajustes.SetBool("activar", false);
        anim_MenuLogros.SetBool("activar", true);
        
    }
    public void SonidoAdelante()
    {
        sonido_play.Play(0);
        Debug.Log("suena");
    }
    public void SonidoAtras()
    {
        sonido_atras.Play(0);
        Debug.Log("suena");
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
