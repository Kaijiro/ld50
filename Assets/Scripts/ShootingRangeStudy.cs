using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingRangeStudy : MonoBehaviour
{
    public int shoot_capacity = 1;
    private float shoot_left = 1f;
    public Slider shoot_loader;
    public float loading_velocity = 1f;

    // Start is called before the first frame update
    void Start()
    {
        shoot_left = shoot_capacity;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) )
        {
           if( shoot_left >= 1)
            {
                shoot_left--;
                shoot_loader.value = shoot_left/shoot_capacity;

                Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

                if (hit.collider != null)
                {
                    Debug.Log("Clicked on " + hit.collider.name);

                    Destroy(hit.collider.gameObject);
                }
                else
                {
                    Debug.Log("Nothing hit");
                }
            } else
            {
                Debug.Log("RELOAD");
            }
            
        }      

    }

    private void FixedUpdate()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mousePosition.y < -5f)
        {
            shoot_left = Mathf.Min(shoot_capacity, shoot_left + Time.deltaTime * loading_velocity);
            //m_Rigidbody.MovePosition(transform.position + m_Input * Time.deltaTime * m_Speed);
        }

        shoot_loader.value = shoot_left / shoot_capacity;
    }

}
