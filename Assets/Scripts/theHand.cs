using UnityEngine;

public class theHand : MonoBehaviour
{
    private void Start() {
        EventSystem.Instance.OnShoot += kickAnim;
    }

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
        transform.position = mousePosition;
    }

    public void kickAnim()
    {
        Debug.Log("kickin");
    }
}
