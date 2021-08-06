using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorKey : MonoBehaviour
{
    [SerializeField] Tractor tractor;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player")) {
            tractor.Unlock();
            Destroy(this.gameObject);
        }
    }
}
