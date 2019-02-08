using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZonaDeMuerte : MonoBehaviour
{
    public GameObject panelGameOver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        Debug.Log("GAME OVER");
        Invoke("ReiniciaNivel", 1f);
        panelGameOver.SetActive(true);

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        Debug.Log("GAME OVER");
        Invoke("ReiniciaNivel", 1f);
        panelGameOver.SetActive(true);
    }
    void ReiniciaNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
