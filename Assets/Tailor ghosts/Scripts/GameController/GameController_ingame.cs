using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GameController_ingame : MonoBehaviour
{

    public static int estrellas = 0;
    public int totalFantasmasNivel = 0 ;
    public int numerodeestrellas;


    public Animator anim_UIingame;
    public Animator anim_pausa;
    public Animator anim_victoria;

    public AudioSource musica;


    void Awake()
    {

    }



    // Start is called before the first frame update
    void Start()
    {



        anim_UIingame.SetBool("activar", false);
        anim_victoria.SetBool("activar", false);
    }

    // Update is called once per frame
    void Update()
    {
        numerodeestrellas = estrellas;
         
        if (totalFantasmasNivel <= 1)
        {
            FinalNivel();
        }
    }

    public void Pausa()
    {
      
        anim_UIingame.SetBool("activar",true);
        anim_pausa.SetBool("activar",true);
        Time.timeScale = 0f;
    }
    public void Play()
    {
        anim_UIingame.SetBool("activar",false);
        anim_pausa.SetBool("activar", false);
        Time.timeScale = 1f;
    }

    public void ReiniciarNivel()
    {
        anim_pausa.SetBool("activar", false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;

        estrellas --;
    }
    public void VolverMenu()
    {
        MusicManager.instance.MusicaMenu();
        SceneManager.LoadScene(sceneName: "Menu_seleccion_mundo");
        Time.timeScale = 1f;
    }
    public void Nivel1_2()
    {
        MusicManager.instance.MusicaM1();
        SceneManager.LoadScene(sceneName: "Nivel1_2");
    }
    public void Nivel2_1()
    {
        MusicManager.instance.MusicaM2();
        SceneManager.LoadScene(sceneName: "Nivel2_1");
    }
    public void Nivel2_2()
    {
        MusicManager.instance.MusicaM2();
        SceneManager.LoadScene(sceneName: "Nivel2_2");
    }
    public void Nivel3_1()
    {
        MusicManager.instance.MusicaM3();
        SceneManager.LoadScene(sceneName: "Nivel3_1");
    }
    public void Nivel3_2()
    {
        MusicManager.instance.MusicaM3();
        SceneManager.LoadScene(sceneName: "Nivel3_2");
    }
    public void Nivel4_1()
    {
        MusicManager.instance.MusicaM4();
        SceneManager.LoadScene(sceneName: "Nivel4_1");
    }
    public void Nivel4_2()
    {
        MusicManager.instance.MusicaM4();
        SceneManager.LoadScene(sceneName: "Nivel4_2");
    }
    public void Nivel5_1()
    {
        MusicManager.instance.MusicaM5();
        SceneManager.LoadScene(sceneName: "Nivel5_1");
    }
    public void Nivel5_2()
    {
        MusicManager.instance.MusicaM5();
        SceneManager.LoadScene(sceneName: "Nivel5_2");
    }

    public void FinalNivel()
    {
        
        anim_victoria.SetBool("activar",true);
        anim_victoria.SetInteger("contar", estrellas);
    }

    public void RestarFantasmas()
    {
        totalFantasmasNivel--;
        
    }
}
