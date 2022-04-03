using UnityEngine;

public class CatAnimationScript : MonoBehaviour {

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private GameObject attackedPrecious;

    private void Start() {
        this.animator = this.GetComponent<Animator>();
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();

        EventSystem.Instance.OnPreciousSmashed += AnimateGameEnd;
    }

    public void AnimateGameEnd(GameObject smashedPrecious){
        this.attackedPrecious = smashedPrecious;

        this.animator.SetTrigger("IsAttacking");
        this.fixSpriteTransform();
    }

    private void fixSpriteTransform(){
        Debug.Log("fixing The Transform");
        this.transform.position = this.transform.position - new Vector3(0, .25f, 0);
    }

    public void TipObject(){
        this.attackedPrecious.GetComponent<Rigidbody2D>().gravityScale = 3f;
    }

    private void OnDestroy()
    {
        EventSystem.Instance.OnPreciousSmashed -= AnimateGameEnd;
    }
}