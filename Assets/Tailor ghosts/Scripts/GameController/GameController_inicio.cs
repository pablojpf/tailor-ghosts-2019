using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameController_inicio : MonoBehaviour
{
    public Animator anim_UIajustes;


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
        Time.timeScale = 0f;
    }
}
