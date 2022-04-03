using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class mishchief_little_shit : MonoBehaviour
{
    Rigidbody2D m_Rigidbody;
    public float m_Speed = 0.001f;
    private bool move = true;
    private Animator animator;
    private GameObject attackedPrecious;

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody2D>();
        this.animator = this.GetComponent<Animator>();
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
            Debug.Log("Collided !");
            move = false;
            this.animator.SetTrigger("IsAttacking");
            this.attackedPrecious = collision.gameObject;
        }
    }

    public void TipObject(){
        this.attackedPrecious.GetComponent<Rigidbody2D>().gravityScale = 3f;
    }
}
