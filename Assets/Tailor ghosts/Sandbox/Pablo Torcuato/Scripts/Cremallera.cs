using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cremallera : MonoBehaviour
{
    public GameObject cremallera;
    public GameObject cremalleraVertical;
    RaycastHit2D hitRight;
    RaycastHit2D hitLeft;
    RaycastHit2D hitTop;
    RaycastHit2D hitBot;
    public bool right = false;
    public bool left = false;
    public bool top = false;
    public bool bot = false;
    public bool unidoRight = false;
    public bool unidoLeft = false;
    public bool unidoTop = false;
    public bool unidoBot = false;
    // Start is called before the first frame update
    void Start()
    {
        Comprobador();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Comprobador()
    {
        GameObject copiaCremallera;
        //RayCast Derecho
        Debug.DrawRay(transform.position + new Vector3(0.6f, 0, 0), transform.right * 0.5f, Color.red);
        hitRight = Physics2D.Raycast(transform.position + new Vector3(0.6f, 0, 0), transform.right, 0.6f);
        if (hitRight)
        {

            if (hitRight.transform.CompareTag("Player") && transform.parent != null)
            {
                Debug.DrawRay(transform.position, transform.right * 0.6f, Color.green);
                right = true;
                if(unidoRight == false)
                {
                    copiaCremallera = Instantiate(cremallera, transform.position + new Vector3(0.5f, 0, 0), transform.rotation);
                    copiaCremallera.transform.SetParent(hitRight.transform);
                    unidoRight = true;
                }
               
            }

        }
        //RayCast Izquierdo
        Debug.DrawRay(transform.position - new Vector3(0.6f, 0, 0), transform.right * -0.5f, Color.red);
        hitLeft = Physics2D.Raycast(transform.position - new Vector3(0.6f, 0, 0), transform.right * -1, 0.6f);
        if (hitLeft)
        {

            if (hitLeft.transform.CompareTag("Player") && transform.parent != null)
            {
                Debug.DrawRay(transform.position, transform.right * -0.6f, Color.green);
                left = true;
                if (unidoLeft == false)
                {
                    copiaCremallera = Instantiate(cremallera, transform.position - new Vector3(0.5f, 0, 0), transform.rotation);
                    copiaCremallera.transform.SetParent(hitLeft.transform);
                    unidoLeft = true;
                }
            }

        }
        //RayCast Superior
        Debug.DrawRay(transform.position + new Vector3(0, 0.6f, 0), transform.up * 0.5f, Color.red);
        hitTop = Physics2D.Raycast(transform.position + new Vector3(0, 0.6f, 0), transform.up, 0.6f);
        if (hitTop)
        {

            if (hitTop.transform.CompareTag("Player") && transform.parent != null && transform.parent.transform.parent == null)
            {
                Debug.DrawRay(transform.position, transform.up * 0.6f, Color.green);
                top = true;
                if (unidoTop == false)
                {
                    copiaCremallera = Instantiate(cremalleraVertical, transform.position + new Vector3(0, 0.5f, 0), transform.rotation);
                    copiaCremallera.transform.SetParent(hitTop.transform);
                    unidoTop = true;
                }
            }

        }
        //RayCast Inferior
        Debug.DrawRay(transform.position - new Vector3(0, 0.6f, 0), transform.up * -0.5f, Color.red);
        hitBot = Physics2D.Raycast(transform.position - new Vector3(0, 0.6f, 0), transform.up * -1, 0.6f);
        if (hitBot)
        {

            if (hitBot.transform.CompareTag("Player") && transform.parent != null)
            {
                Debug.DrawRay(transform.position, transform.up * -0.6f, Color.green);
                bot = true;
                if (unidoBot == false)
                {
                    copiaCremallera = Instantiate(cremalleraVertical, transform.position - new Vector3(0, 0.5f, 0), transform.rotation);
                    copiaCremallera.transform.SetParent(hitBot.transform);
                    unidoBot = true;
                }
            }

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Comprobador();
    }
}
