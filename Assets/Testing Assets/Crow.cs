using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crow : MonoBehaviour
{
    [SerializeField] LayerMask playerLayer, scareCrowLayer;
    [SerializeField] Animator crowAnimator;
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
                PlayAnimation(CrowAnimations.Fly);
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
        PlayAnimation(CrowAnimations.Attack);
        GameManager.Instance.OnPlayerDeath();
    }

    void PlayAnimation(CrowAnimations animation) {
        crowAnimator.SetInteger("animationID", (int) animation);
    }

    IEnumerator ComeDownCoroutine() {
        yield return new WaitForSeconds(comeDownCoolDown);
        if (!Physics2D.OverlapBox(crowScaringRegion.transform.position, crowScaringRegion.bounds.size, 0f, scareCrowLayer))
            PlayAnimation(CrowAnimations.ComeBack);
    }
}

public enum CrowAnimations {
    ComeBack, Fly, Attack 
}
