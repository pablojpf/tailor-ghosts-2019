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
    public int numeroMundo = 1;
    public int numeroNivel;

    public Animator anim_UIingame;
    public Animator anim_pausa;
    public Animator anim_victoria;

    public AudioSource musica;

    bool completado = false;
    public bool nivel2 = false;
    void Awake()
    {

    }



    // Start Activamos la UI dentro del juego y el panel de victoria esta desactivado

    void Start()
    {



        anim_UIingame.SetBool("activar", false);
        anim_victoria.SetBool("activar", false);
    }

    // Update la variable que cuenta las estrellas se va actualizando cada frame
    //Si el total de fantasmas baja de 1 se ejecuta la pantalla de victoria
   
    void Update()
    {
        numerodeestrellas = estrellas;
         
        if (totalFantasmasNivel <= 1)
        {
            FinalNivel();
        }
    }

    //La pantalla ingame se desactiva
    //el menu de pausa aparece y paramos el tiempo

    public void Pausa()
    {
      
        anim_UIingame.SetBool("activar",true);
        anim_pausa.SetBool("activar",true);
        Time.timeScale = 0f;
    }

    //Activamos el tiempo y viceversa respecto a la pausa
    //

    public void Play()
    {
        anim_UIingame.SetBool("activar",false);
        anim_pausa.SetBool("activar", false);
        Time.timeScale = 1f;
    }

    //Recargamos el nivel, activamos el tiempo de nuevo y el contado de estrellas vuelve a cero
    //

    public void ReiniciarNivel()
    {
        anim_pausa.SetBool("activar", false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;

        estrellas --;
    }

    //Volver al menu

    public void VolverMenu()
    {
        MusicManager.instance.MusicaMenu();
        SceneManager.LoadScene(sceneName: "Menu_seleccion_mundo");
        Time.timeScale = 1f;
    }

    //Funciones para ir de un nivel a otro

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

    //Activar la pantalla de victoria

    public void FinalNivel()
    {
        PlayerPrefs.SetInt("nivel" + numeroMundo, estrellas);
        anim_victoria.SetBool("activar",true);
        anim_victoria.SetInteger("contar", estrellas);
        if(completado == false)
        {
            if (nivel2 == true)
            {
                if(numeroNivel > PlayerPrefs.GetInt("Niveles"))
                {
                    MundosManager.SumaNivel();
                }
                
            }
            else
            {
                NivelesSecundariosManager.SumaSecundario();
            }
            
            
            completado = true;
        }
        
    }

    //Resta el numero de fantasmas

    public void RestarFantasmas()
    {
        totalFantasmasNivel--;
        
    }
}
