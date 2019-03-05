using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesbloqueEstrellas : MonoBehaviour
{
    public int mundo = 1;
    public int estrellas = 0;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        if (PlayerPrefs.HasKey("nivel"+mundo))
        {
            estrellas = PlayerPrefs.GetInt("nivel"+mundo);
           

        }
        else
        {
            estrellas = 0;
            PlayerPrefs.SetInt("nivel" + mundo, estrellas);
            PlayerPrefs.Save();
        }
        anim.SetInteger("estrellas", estrellas);
    }
    
}
