using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Precious : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "deathvoid")
        {
            StaticScore.CrossSceneInformation = this.gameObject.name;
            StartCoroutine(GameOver());  
        }
    }

    IEnumerator GameOver(){
        while(GameObject.Find("World").GetComponent<AudioSource>().isPlaying){
            yield return new WaitForSeconds(.1f);
        }

        SceneManager.LoadScene("GameOver");
    }
}
