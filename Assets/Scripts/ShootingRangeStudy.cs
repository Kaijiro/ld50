using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingRangeStudy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
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
        }
    }

}
