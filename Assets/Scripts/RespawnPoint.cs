using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    public bool covered { private set; get; }

    private void Awake() {
        covered = false;
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player") && !covered && !PlayerManager.Instance.IsDead()) {
            Debug.Log("Respawn Point set");
            covered = true;
            PlayerManager.Instance.SetRespawnPosition(transform.position);
        }
    }
}
