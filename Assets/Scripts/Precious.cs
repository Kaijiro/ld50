using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Precious : MonoBehaviour
{
    public AudioClip preciousSmashedSound;
    private bool falling = false;
    public float chaos_speed = 5f;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "deathvoid")
        {
            StaticScore.CrossSceneInformation = this.gameObject.name;
            StartCoroutine(GameOver());  
        }
    }

    private void FixedUpdate()
    {
        if (falling)
        {
            gameObject.GetComponent<Rigidbody2D>().AddTorque(chaos_speed * Time.deltaTime);
        }        
    }

    public void Touched()
    {
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 2.5f;
        chaos_speed = Random.Range(-20f, 0f);
        falling = true;
        GameObject.Find("World").GetComponent<AudioSource>().PlayOneShot(this.preciousSmashedSound);
    }

    IEnumerator GameOver(){
        while(GameObject.Find("World").GetComponent<AudioSource>().isPlaying){
            yield return new WaitForSeconds(.1f);
        }

        SceneManager.LoadScene("GameOver");
    }

}
