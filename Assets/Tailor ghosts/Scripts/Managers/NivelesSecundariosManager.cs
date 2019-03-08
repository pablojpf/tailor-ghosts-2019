using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NivelesSecundariosManager : MonoBehaviour
{
    public Button nivel;
    public static int secundariosDesbloqueados;
    public int nivelActual;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        PlayerPrefs.GetInt("NivelesSecundarios");
        Debug.Log("SECUNDARIOS"+PlayerPrefs.GetInt("NivelesSecundarios").ToString());
        secundariosDesbloqueados = PlayerPrefs.GetInt("NivelesSecundarios");

        if(secundariosDesbloqueados >= nivelActual)
        {
            nivel.interactable = true;
        }

        
    }

    public static void SumaSecundario()
    {
        secundariosDesbloqueados = PlayerPrefs.GetInt("NivelesSecundarios");
        ++secundariosDesbloqueados;
        PlayerPrefs.SetInt("NivelesSecundarios", secundariosDesbloqueados);
        PlayerPrefs.Save();
    }


}