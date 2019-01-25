using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activado : MonoBehaviour
{
    public Animator anim_activar;
    // Start is called before the first frame update
    void Start()
    {
        anim_activar = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        anim_activar.SetTrigger("activar");
        
    }
}
