using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposicionador : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Reposiciona();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reposiciona()
    {
        if (transform.parent != null)
        {

            transform.localPosition = new Vector3(Mathf.Round(transform.localPosition.x), Mathf.Round(transform.localPosition.y), Mathf.Round(transform.localPosition.z));
        }
        else
        {
            transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
        }

    }
}
