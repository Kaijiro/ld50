using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class mishchief_little_shit : MonoBehaviour
{
    Rigidbody2D m_Rigidbody;
    public float m_Speed = 0.001f;
    public Sprite lame_animation;

    private bool move = true;

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {       
        if (move)
        {
            m_Rigidbody.MovePosition(transform.position + new Vector3(1, 0, 0) * Time.deltaTime * m_Speed);
        }        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "precious")
        {
            move = false;
            GetComponent<SpriteRenderer>().sprite = lame_animation;
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 3f;
            // Destroy(collision.gameObject); 
        }

    }

}
