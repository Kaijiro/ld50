using System;
using UnityEngine;

public class CatAnimationScript : MonoBehaviour {

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private GameObject attackedPrecious;

    private Action animateCatDownCallback;

    private void Start() {
        this.animator = this.GetComponent<Animator>();
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();

        EventSystem.Instance.OnPreciousReached += AnimateGameEnd;
    }

    public void AnimateGameEnd(GameObject smashedPrecious){
        this.attackedPrecious = smashedPrecious;

        this.animator.SetTrigger("IsAttacking");
        this.fixSpriteTransform(new Vector3(0, .25f, 0));
    }

    private void fixSpriteTransform(Vector3 offset){
        Debug.Log("fixing The Transform");
        this.transform.position = this.transform.position - offset;
    }

    public void OnAttackAnimationEnd(){
        this.attackedPrecious.GetComponent<Precious>().Touched();
    }

    public void AnimateCatDown(Action callback){
        this.animateCatDownCallback = callback;

        this.animator.SetTrigger("CatDown");
        this.fixSpriteTransform(new Vector3(0, .4f, 0));
    }

    public void OnCatDownAnimationEnd(){
        Debug.Log("Calling callback");
        this.animateCatDownCallback();
    }

    private void OnDestroy()
    {
        EventSystem.Instance.OnPreciousReached -= AnimateGameEnd;
    }
}