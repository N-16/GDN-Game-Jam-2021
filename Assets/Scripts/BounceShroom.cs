using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceShroom : MonoBehaviour
{
    [SerializeField] BoxCollider2D bounceRegion;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] float bounceForce = 200f;
    [SerializeField] Animator bounceAnimation;

    bool onBounceCoolDown = false;

    private void Update() {
        Collider2D  col = Physics2D.OverlapBox(bounceRegion.transform.position, bounceRegion.bounds.size, 0f, playerLayer);
        if (col && !onBounceCoolDown){
            //col.GetComponent<Rigidbody2D>().velocity = new Vector2(col.GetComponent<Rigidbody2D>().velocity.x, bounceForce);
            col.GetComponent<Rigidbody2D>().velocity = transform.up * bounceForce;
            StartCoroutine(BounceCoolDownRoutine());
            bounceAnimation.SetTrigger("bounce");
            SoundManager.Instance.PlaySound(soundsType.MushroomBounce);
        }
    }

    IEnumerator BounceCoolDownRoutine() {
        onBounceCoolDown = true;
        yield return new WaitForSeconds(0.25f);
        onBounceCoolDown = false;
    }
}
