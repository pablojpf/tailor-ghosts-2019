using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController_menuseleccion : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Nivel1()
    {
        MusicManager.instance.MusicaM1();
        SceneManager.LoadScene(sceneName: "Nivel1_1");
    }

    public void Nivel1_2()
    {
        SceneManager.LoadScene(sceneName: "Nivel1_2");
    }
    public void Nivel2_1()
    {
        SceneManager.LoadScene(sceneName: "Nivel2_1");
    }

    public void MenuInicial()
    {
        SceneManager.LoadScene(sceneName: "Menu_principal");
    }


    public void MenuSeleccion()
    {
        SceneManager.LoadScene(sceneName: "Menu_seleccion_nivel");
    }

  

}
