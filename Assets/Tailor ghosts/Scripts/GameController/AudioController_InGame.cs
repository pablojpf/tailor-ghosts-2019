using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController_InGame : MonoBehaviour
{
    public AudioSource sonidoPausa;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AudioPausa()
    {
        sonidoPausa.enabled = true;
        sonidoPausa.Play(0);
        
    }
}
