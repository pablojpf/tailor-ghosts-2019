using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteracCaja : MonoBehaviour
{
    public static bool left = false;
    public static bool right = false;
    public static bool top = false;
    public static bool bot = false;
    public GameObject humo;
    public GameObject particulas;
    public Transform trLeft;
    public Transform trRight;
    public Transform trTop;
    public Transform trBot;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        GameObject copiaHumo;
        GameObject copiaParticulas;
        sr.enabled = false;
        Invoke("Autodestruccion", 1f);
        col.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        if(left == true)
        {
            copiaHumo = Instantiate(humo, trRight.position, trRight.rotation);
            copiaParticulas = Instantiate(particulas, trRight.position, trRight.rotation);
            copiaHumo.transform.SetParent(transform);
            copiaParticulas.transform.SetParent(transform);
        }
        if (right == true)
        {
            copiaHumo = Instantiate(humo, trLeft.position, trLeft.rotation);
            copiaParticulas = Instantiate(particulas, trRight.position, trRight.rotation);
            copiaHumo.transform.SetParent(transform);
            copiaParticulas.transform.SetParent(transform);
        }
        if (top == true)
        {
            copiaHumo = Instantiate(humo, trBot.position, trBot.rotation);
            copiaParticulas = Instantiate(particulas, trRight.position, trRight.rotation);
            copiaHumo.transform.SetParent(transform);
            copiaParticulas.transform.SetParent(transform);
        }
        if (bot == true)
        {
            copiaHumo = Instantiate(humo, trTop.position, trTop.rotation);
            copiaParticulas = Instantiate(particulas, trRight.position, trRight.rotation);
            copiaHumo.transform.SetParent(transform);
            copiaParticulas.transform.SetParent(transform);
        }
    }
    public void Autodestruccion()
    {
        Destroy(gameObject);
    }
}
