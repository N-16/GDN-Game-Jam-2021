using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonMushroom : MonoBehaviour
{
    [SerializeField] ParticleSystem particles;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player")) {
            particles.Play();
            PlayerManager.Instance.OnPlayerDeath();
        }
    }
}
