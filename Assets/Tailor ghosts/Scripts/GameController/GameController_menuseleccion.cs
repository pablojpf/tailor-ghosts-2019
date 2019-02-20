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



    public void Mundo1()
    {
        SceneManager.LoadScene(sceneName: "Mundo1");
    }

    public void Mundo2()
    {
        SceneManager.LoadScene(sceneName: "Mundo2");
    }

    public void Mundo3()
    {
        SceneManager.LoadScene(sceneName: "Mundo3");
    }

    public void Mundo4()
    {
        SceneManager.LoadScene(sceneName: "Mundo4");
    }

    public void Mundo5()
    {
        SceneManager.LoadScene(sceneName: "Mundo5");
    }

    public void Nivel1_1()
    {
        MusicManager.instance.MusicaM1();
        SceneManager.LoadScene(sceneName: "Nivel1_1");
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

    public void MenuInicial()
    {
        SceneManager.LoadScene(sceneName: "Menu_principal");
    }


    public void MenuSeleccion()
    {
        SceneManager.LoadScene(sceneName: "Menu_seleccion_mundo");
    }

  

}
