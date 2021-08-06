using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tractor : MonoBehaviour
{

    bool playerHasKey = false;
    [SerializeField] GameObject destroyThisLol;
    [SerializeField] float timeBeforeAdios = 0.5f;
    [SerializeField] Animator tireAnimator, tractorAnimator;
    
    public void Unlock() {
        playerHasKey = true;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player")) {
            if (playerHasKey) {
                Adios();
            }
        }
    }

    void Adios() {
        tireAnimator.SetTrigger("adios");
        tractorAnimator.SetTrigger("adios");
        Destroy(destroyThisLol, timeBeforeAdios);
    }
}
