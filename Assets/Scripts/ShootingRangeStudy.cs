using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShootingRangeStudy : MonoBehaviour
{
    public int shoot_capacity = 1;
    private float shoot_left = 1f;
    
    // loading UI
    public Slider shoot_loader;
    public TextMeshProUGUI hint_loader;

    public TextMeshProUGUI ui_timer;

    public float loading_velocity = 1f;

    public GameObject reticle;

    public AudioClip shootSound;

    // Start is called before the first frame update
    void Start()
    {
        shoot_left = shoot_capacity;
        StaticScore.CrossSceneTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) )
        {
           if( shoot_left >= 1)
            {
                // manage shooting capacity
                shoot_left--;
                this.UpdateShootLoaderDisplay(shoot_left/shoot_capacity);

                // add some fancy stuff to the gun
                EventSystem.Instance.Shoot();
                this.GetComponent<AudioSource>().PlayOneShot(this.shootSound);

                // did you hit something ? apply stuff then
                Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);



                if (hit.collider != null && hit.collider.gameObject.tag == "cat")
                {
                    //Debug.Log("Clicked on " + hit.collider.name);
                    EventSystem.Instance.CatSplashed();
                }

                if (hit.collider != null && hit.collider.gameObject.tag == "precious")
                {
                    //Destroy(hit.collider.gameObject);
                    hit.collider.gameObject.GetComponent<Precious>().Touched();
                    //GameObject.Find("World").GetComponent<AudioSource>().PlayOneShot(this.preciousSmashedSound);
                    StaticScore.CrossSceneInformation = hit.collider.gameObject.name;
                }
            } 
        }    
    }

    private void FixedUpdate()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mousePosition.y < -4.2f)
        {
            shoot_left = Mathf.Min(shoot_capacity, shoot_left + Time.deltaTime * loading_velocity);
        }

        this.UpdateShootLoaderDisplay(shoot_left / shoot_capacity);
        StaticScore.CrossSceneTimer += Time.deltaTime;
        ui_timer.SetText(StaticScore.CrossSceneTimer.ToString("#.000"));
    }

    private void UpdateShootLoaderDisplay(float shootLeftValue){
        if(this.shoot_loader != null){
            this.shoot_loader.value = shootLeftValue;
        }
        if (this.hint_loader != null)
        {
            if (shootLeftValue < 1f)
            {
                this.hint_loader.SetText("Aim here to reload");
            }
            else
            {
                this.hint_loader.SetText("");
            }
        }     
    }
}
