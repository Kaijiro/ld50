using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Precious : MonoBehaviour
{

    private void OnDestroy()
    {
        SceneManager.LoadScene("GameOver") ;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "deathvoid")
        {
            StaticScore.CrossSceneInformation = collision.gameObject.name;
            Destroy(this.gameObject);  
        }

    }
}
