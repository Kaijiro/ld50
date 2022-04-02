using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mishchief_little_shit : MonoBehaviour
{
    Rigidbody2D m_Rigidbody;
    public float m_Speed = 0.001f;

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //Store user input as a movement vector
        Vector3 m_Input = new Vector3(1,0,0);

        //Apply the movement vector to the current position, which is
        //multiplied by deltaTime and speed for a smooth MovePosition
        m_Rigidbody.MovePosition(transform.position + m_Input * Time.deltaTime * m_Speed);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision!!");

        if (collision.gameObject.tag == "precious")
        {
            Destroy(collision.gameObject);
        }
        
    }

}
