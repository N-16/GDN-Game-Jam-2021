using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowOnInterval : MonoBehaviour
{
    [SerializeField] Transform toFollow;
    [SerializeField] Vector3 offset;
    [SerializeField] float Interval = 5f;

    private void Start() {
        StartCoroutine(FollowOnIntervalRoutine());
    }

    IEnumerator FollowOnIntervalRoutine() {
        while (true) {
            yield return new WaitForSeconds(Interval);
            UpdatePosition();
        }
    }

    void UpdatePosition() {
        transform.position = toFollow.position + offset;
    }
}
