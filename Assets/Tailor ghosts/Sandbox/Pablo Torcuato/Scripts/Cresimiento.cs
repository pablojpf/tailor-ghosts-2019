using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cresimiento : MonoBehaviour
{
    SpriteRenderer sp;
    Vector4 tamaño = new Vector4(0, 0, 1, 0);
    public float duresa = 1f;
    public float direccion;
    bool cresiendo = true;
    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(cresiendo == true)
        {
        sp.size += new Vector2(duresa, 0);
        transform.position += new Vector3(duresa / 2, 0, 0);
        }
        
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        cresiendo = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        cresiendo = true;
    }
}
