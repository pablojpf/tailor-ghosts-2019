using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muelle : MonoBehaviour
{
    public static bool top = false;
    public static bool bot = false;
    public static bool left = false;
    public static bool right = false;

    public GameObject fantasma;

    public GameObject detectadoTop;
    public GameObject detectadoBot;
    public GameObject detectadoRight;
    public GameObject detectadoLeft;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player")&& top == true)
        {
            col.transform.position = new Vector2(col.transform.position.x, col.transform.position.y + 1);
            top = false;
        }
        if (col.gameObject.CompareTag("Player") && bot == true)
        {
            col.transform.position = new Vector2(col.transform.position.x, col.transform.position.y - 1);
            bot = false;
        }
        if (col.gameObject.CompareTag("Player") && right == true)
        {
            col.transform.position = new Vector2(col.transform.position.x + 1, col.transform.position.y);
            right = false;
        }
        if (col.gameObject.CompareTag("Player") && left == true)
        {
            col.transform.position = new Vector2(col.transform.position.x - 1, col.transform.position.y);
            left = false;
        }
    }
}
