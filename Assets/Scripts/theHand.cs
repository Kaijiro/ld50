using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class theHand : MonoBehaviour
{
    public Sprite kicked_sprite;
    public Sprite aiming_sprite;
    private Transform hand;
    public float vertical_limit = 3.73f;

    private void Start() {
        EventSystem.Instance.OnShoot += kickAnim;
        hand = transform.Find("the_hand");
    }

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(mousePosition.y);
        // prevent to aim "too high" so that "cut" part of sprite is not shown
        if (mousePosition.y >= vertical_limit)
        {
            
            mousePosition.y = vertical_limit;
        }
        mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
        transform.position = mousePosition;
        
    }

    public void kickAnim()
    {        
        hand.GetComponent<SpriteRenderer>().sprite = kicked_sprite;
        StartCoroutine(unkick());
    }

    IEnumerator unkick()
    {
        yield return new WaitForSeconds(0.1f);
        hand.GetComponent<SpriteRenderer>().sprite = aiming_sprite;
    }
}
