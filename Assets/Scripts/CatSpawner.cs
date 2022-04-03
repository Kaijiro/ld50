using System.Collections;
using UnityEngine;

public class CatSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn;

    [Range(0, 100)]
    public float catSpawnChance;

    [Min(0.01f)]
    public float furryCoefficient;

    private int hitCount;

    private GameObject[] precious;

    public GameObject debugPrecious;

    private GameObject catInstance = null;

    private bool isCatInvincible = false;

    // Start is called before the first frame update
    void Start()
    {
        this.precious = GameObject.FindGameObjectsWithTag("precious");
        Debug.Log("Found " + this.precious.Length + "precious in the scene.");
        
        Debug.Log("Starting Coroutine");
        StartCoroutine(DoCheck());

        EventSystem.Instance.OnPreciousSmashed += BecomeInvincible;
        EventSystem.Instance.OnCatSplashed += OnCatSplashed;
    }

    private void OnCatSplashed(){
        if(!isCatInvincible)
        {
            IncreaseFurry();
            DespawnCat();
        }
    }

    private void IncreaseFurry(){
        Debug.Log("Furry Increased !");
        this.hitCount++;
    }

    private void BecomeInvincible(GameObject precious){
        Debug.Log("I AM INVINCIBLE !");
        this.isCatInvincible = true;
    }

    private bool CatShouldSpawn(){
        return this.catInstance == null && Random.Range(0, 100) <= catSpawnChance;
    }

    private void DespawnCat(){
        Debug.Log("Destroying the cat.");
        Destroy(this.catInstance);
        this.catInstance = null;
    }

    IEnumerator DoCheck(){ // TODO Poor method name
        for(;;){
            if(CatShouldSpawn()){
                Debug.Log("Spawning the cat !");

                GameObject targetedPrecious;
                if(debugPrecious != null){
                    targetedPrecious = this.debugPrecious;
                } else {
                    int preciousIndex = Mathf.FloorToInt(Random.Range(0, this.precious.Length - 1));
                    targetedPrecious = this.precious[preciousIndex];
                }
                
                Vector3 spawnerPosition = targetedPrecious.GetComponentsInChildren<Transform>()[1].position;
                this.catInstance = GameObject.Instantiate(this.prefabToSpawn, spawnerPosition, Quaternion.identity, this.transform);

                bool spawnerIsPlacedAtTheRightOfThePrecious = spawnerPosition.x > targetedPrecious.transform.position.x;

                mishchief_little_shit catWalkingBehavior = this.catInstance.GetComponent<mishchief_little_shit>();
                catWalkingBehavior.m_Speed = (catWalkingBehavior.m_Speed + (this.furryCoefficient * this.hitCount));

                if(spawnerIsPlacedAtTheRightOfThePrecious){
                    catWalkingBehavior.m_Speed = catWalkingBehavior.m_Speed * -1;
                    this.catInstance.GetComponentInChildren<SpriteRenderer>().flipX = true;
                }
            }

            yield return new WaitForSeconds(1f);
        }
    }
}
