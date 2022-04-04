using UnityEngine;

public class SwitchPositionOnUserInputBehaviourScript : MonoBehaviour
{
    // This behavior make the object switch its position to the given positions each time the player hit the configured key

    [SerializeField]
    public Transform[] objectsToSwitch;

    public KeyCode forward;
    public KeyCode backward;

    private int actualIndex;

    // Start is called before the first frame update
    void Start()
    {
        if(this.objectsToSwitch.Length > 0){
            this.MoveAtObjectWithIndex(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(this.forward))
            {
                int nextIndex = this.actualIndex == this.objectsToSwitch.Length - 1 ? 0 : this.actualIndex + 1;

                this.MoveAtObjectWithIndex(nextIndex);
            }
            if (Input.GetKeyDown(this.backward))
            {
                int nextIndex = this.actualIndex == 0 ? this.objectsToSwitch.Length - 1 : this.actualIndex - 1;

                this.MoveAtObjectWithIndex(nextIndex);
            }
        }
    }

    private void MoveAtObjectWithIndex(int objectIndexToMoveAt){
        this.actualIndex = objectIndexToMoveAt;

        float currentZ = this.transform.position.z;
        Vector3 objectPosition = this.objectsToSwitch[objectIndexToMoveAt].position;
        this.transform.position = new Vector3(objectPosition.x, objectPosition.y, currentZ);
    }
}
