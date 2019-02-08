using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController_ingame : MonoBehaviour
{

    public static int estrellas = 0;
    public int totalFantasmasNivel = 0 ;
    public int numerodeestrellas;


    public Animator anim_UIingame;
    public Animator anim_pausa;
    public Animator anim_victoria;

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
    }
    public void VolverMenu()
    {
        SceneManager.LoadScene(sceneName: "Menu_seleccion_nivel");
        Time.timeScale = 1f;
    }
    public void Nivel1_2()
    {
        SceneManager.LoadScene(sceneName: "Nivel1_2");
    }
    public void Nivel2_1()
    {
        SceneManager.LoadScene(sceneName: "Nivel2_1");
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
