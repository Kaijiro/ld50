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
        Debug.Log("fixingTheTransform");
        
        this.spriteRenderer.sharedMaterial.mainTextureOffset = new Vector2(0, - 0.5f);
    }

    public void TipObject(){
        this.attackedPrecious.GetComponent<Rigidbody2D>().gravityScale = 3f;
    }

    private void OnDestroy()
    {
        EventSystem.Instance.OnPreciousSmashed -= AnimateGameEnd;
    }
}