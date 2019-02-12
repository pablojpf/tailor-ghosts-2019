using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController_InGame : MonoBehaviour
{
    public AudioSource sonidoPausa;
    AudioSource sonidoUnion;
    // Start is called before the first frame update
    void Start()
    {
        sonidoUnion = GetComponent<AudioSource>();
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
    public void AudioUnion()
    {
        sonidoUnion.Play(0);
    }
}
