using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorMuelle : MonoBehaviour
{
    public bool top = false;
    public bool bot = false;
    public bool right = false;
    public bool left = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))

        {
            if (top == true)
            {
                Muelle.top = true;
            }
            if (bot == true)
            {
                Muelle.bot = true;
            }
            if (right == true)
            {
                Muelle.right = true;
            }
            if (left == true)
            {
                Muelle.left = true;
            }
        }
    }
}
