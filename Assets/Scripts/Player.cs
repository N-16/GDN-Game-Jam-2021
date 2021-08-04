using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] Animator playerAnimation;
    [SerializeField] Rigidbody2D playerRb;

    PlayerAnimations currentAnimation = PlayerAnimations.idle;
    // Start is called before the first frame update
    void Start()
    {
        PlayAnimation(PlayerAnimations.idle);
    }

    private void Update() {
        if (Mathf.Abs( playerRb.velocity.x ) > 1f) {
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

    public void PlayAnimation(PlayerAnimations  animation) {
        playerAnimation.SetInteger("animationID", (int)animation);
    }
}

public enum PlayerAnimations{
    idle , run, jump
}
