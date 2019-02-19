using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{


    private bool musicaActiva = true;
    private bool musica_menu = true;

    public AudioMixer audioM;
    public AudioMixerGroup Musica;
    public AudioClip musica_menus;

    AudioSource ManagerMusica;

    public static MusicManager instance = null;


    // Start is called before the first frame update
    void Start()
    {
        ManagerMusica = gameObject.GetComponent<AudioSource>();
        ManagerMusica.clip = musica_menus;
        ManagerMusica.Play();
    }


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }else if (instance != this)
        {
            Destroy(gameObject);
        }  
        DontDestroyOnLoad(gameObject);
    }




    // Update is called once per frame
    void Update()
    {
        
    }

    public void Musicaonoff()
    {
        musicaActiva = !musicaActiva;


        if (musicaActiva)
        {
            audioM.SetFloat("volumenMusica", 0);
        }
        else
        {
            audioM.SetFloat("volumenMusica", -80);
        }
    }
}
