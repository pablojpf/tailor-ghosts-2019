using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController_ingame : MonoBehaviour
{

    public Animator anim_UIingame;
    public Animator anim_pausa;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
