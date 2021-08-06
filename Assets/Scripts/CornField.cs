using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornField : MonoBehaviour
{
    [SerializeField] Animator cornAnimator;

    private void Awake() {
        cornAnimator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player")) {
            cornAnimator.SetTrigger("wiggle");
        }
    }
}
