using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class mishchief_little_shit : MonoBehaviour
{
    public float m_Speed = 0.001f;
    private Rigidbody2D rigidBody;
    private bool move = true;

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        this.rigidBody = this.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {       
        if (move)
        {
            this.rigidBody.MovePosition(transform.position + new Vector3(1, 0, 0) * Time.deltaTime * m_Speed);
        }        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "precious")
        {
            Debug.Log("Collided !");
            move = false;
            // prevent cat to be pushed by rotating falling precious
            gameObject.GetComponent<BoxCollider2D>().enabled = false;

            EventSystem.Instance.PreciousReached(collision.gameObject);
        }
    }
}
