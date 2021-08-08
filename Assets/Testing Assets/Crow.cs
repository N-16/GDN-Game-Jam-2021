using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crow : MonoBehaviour
{
    [SerializeField] LayerMask playerLayer, scareCrowLayer;
    [SerializeField] Animator crowAnimator;
    [SerializeField] float flyToIdleTransitionTime = 0.25f;
    [SerializeField] Animator crowSpriteAnimator;
    [SerializeField] CircleCollider2D crowTerritoryTile;
    [SerializeField] BoxCollider2D crowScaringRegion;
    [SerializeField] float comeDownCoolDown = 2.5f; 

    bool onFlight = false;

    private void Update() {
            if (Physics2D.OverlapBox(crowTerritoryTile.transform.position, crowTerritoryTile.bounds.size, 0f, playerLayer)) {
                AttackPlayer();

            }
            if (!onFlight) {
                if (Physics2D.OverlapBox(crowScaringRegion.transform.position, crowScaringRegion.bounds.size, 0f, scareCrowLayer)) {
                    StopCoroutine(ComeDownCoroutine());
                    StopCoroutine(FlyToIdleTransition());
                    PlayAnimation(CrowAnimations.Fly);
                    crowSpriteAnimator.SetBool("flying", true);
                    onFlight = true;
                }
            }
            else {
                if (!Physics2D.OverlapBox(crowScaringRegion.transform.position, crowScaringRegion.bounds.size, 0f, scareCrowLayer)) {
                    StartCoroutine(ComeDownCoroutine());
                    onFlight = false;
                }
            }
        
    }

    private void AttackPlayer() {
        if (!PlayerManager.Instance.IsDead()) {
            StopCoroutine(ComeDownCoroutine());
            StopCoroutine(FlyToIdleTransition());
            crowSpriteAnimator.SetBool("flying", true);
            PlayAnimation(CrowAnimations.Attack);
            PlayerManager.Instance.OnPlayerDeath();
            Debug.Log("Calling dead");
        }
        
    }

    void PlayAnimation(CrowAnimations animation) {
        crowAnimator.SetInteger("animationID", (int) animation);
    }

    IEnumerator ComeDownCoroutine() {
        yield return new WaitForSeconds(comeDownCoolDown);
        if (!Physics2D.OverlapBox(crowScaringRegion.transform.position, crowScaringRegion.bounds.size, 0f, scareCrowLayer)) {
            PlayAnimation(CrowAnimations.ComeBack);
            StartCoroutine(FlyToIdleTransition());
        }
    }

    IEnumerator FlyToIdleTransition() {
        yield return new WaitForSeconds(flyToIdleTransitionTime);
        crowSpriteAnimator.SetBool("flying", false);
    }


}

public enum CrowAnimations {
    ComeBack, Fly, Attack 
}
