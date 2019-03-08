using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MundosManager : MonoBehaviour
{
    public Button[] botones;
    public static int nivelesDesbloqueados;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        PlayerPrefs.GetInt("Niveles");
        Debug.Log(PlayerPrefs.GetInt("Niveles").ToString());
        nivelesDesbloqueados = PlayerPrefs.GetInt("Niveles");

        for (int i = 0; i < nivelesDesbloqueados; ++i)
        {
            botones[i].interactable = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void SumaNivel()
    {
        nivelesDesbloqueados = PlayerPrefs.GetInt("Niveles");
        ++nivelesDesbloqueados;
        PlayerPrefs.SetInt("Niveles", nivelesDesbloqueados);
        PlayerPrefs.Save();
    }


}
