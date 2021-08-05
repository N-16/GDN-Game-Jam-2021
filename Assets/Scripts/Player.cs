using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    [SerializeField] Animator playerAnimation;
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] LayerMask scareCrowLayer;
    [SerializeField] GameObject scareCrowDummy;
    [SerializeField] KeyCode scareCrowPickupKey = KeyCode.X;
    [SerializeField] BoxCollider2D playerCollider;

    PlayerAnimations currentAnimation = PlayerAnimations.idle;
    Transform scareCrowOrgParent;
    GameObject scareCrowCarried;
    void Start()
    {
        PlayAnimation(PlayerAnimations.idle);
    }

    private void Update() {
        UpdateAnimation();
        if (!scareCrowCarried) {
            Collider2D col = Physics2D.OverlapBox(playerCollider.transform.position, playerCollider.bounds.size, 0f, scareCrowLayer);
            if (col && Input.GetKeyDown(scareCrowPickupKey)) {
                PickUpScareCrow(col.gameObject);
            }
        }
        else if (Input.GetKeyDown(scareCrowPickupKey) || Mathf.Abs( playerRb.velocity.y ) > 1f) {
            PutDownScareCrow();
        }

    }

    void UpdateAnimation() {
        if (Mathf.Abs(playerRb.velocity.x) > 0.1f) {
            if (currentAnimation != PlayerAnimations.run) {
                PlayAnimation(PlayerAnimations.run);
                currentAnimation = PlayerAnimations.run;
            }
        }
        else if (playerRb.velocity.y != 0f) {
            if (currentAnimation != PlayerAnimations.jump) {
                PlayAnimation(PlayerAnimations.jump);
                currentAnimation = PlayerAnimations.jump;
            }
        }
        else if (currentAnimation != PlayerAnimations.idle) {
            PlayAnimation(PlayerAnimations.idle);
            currentAnimation = PlayerAnimations.idle;
        }
    }
    private void OnCollisionStay2D(Collision2D collision) {
        
    }
    public void PlayAnimation(PlayerAnimations  animation) {
        playerAnimation.SetInteger("animationID", (int)animation);
    }

    void PickUpScareCrow(GameObject scareCrow) {
        if (scareCrowCarried == null) {
            scareCrow.SetActive(false);
            scareCrowDummy.SetActive(true);
            scareCrowCarried = scareCrow;
            return;
        }
        Debug.Log("Already carrying Scare Crow");
    }

    void PutDownScareCrow() {
        if (scareCrowCarried) {
            scareCrowCarried.transform.position = scareCrowDummy.transform.position;
            scareCrowCarried.SetActive(true);
            scareCrowDummy.SetActive(false);
            scareCrowCarried = null;
            return;
        }
        Debug.Log("no scareCrow pickedUP");
    }
}

public enum PlayerAnimations{
    idle , run, jump
}
