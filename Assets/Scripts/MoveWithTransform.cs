using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithTransform : MonoBehaviour
{
    public Transform toFollow;

    private void Start() {
        if (toFollow == null) {
            toFollow = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    private void Update() {
        transform.position = Vector2.right * toFollow.position.x;
    }
}
