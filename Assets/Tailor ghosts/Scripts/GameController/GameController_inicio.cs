using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameController_inicio : MonoBehaviour
{
    public Animator anim_UIajustes;
    public Animator anim_MenuLogros;
    public GameObject botonPlay;


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
        anim_UIajustes.SetBool("activar", true);
        anim_MenuLogros.SetBool("activar", false);
    }

    public void Menulogros()
    {

        anim_UIajustes.SetBool("activar", false);
        anim_MenuLogros.SetBool("activar", true);
        
    }

}
