using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] Player player;
    [SerializeField] Movement playerMovement;
    private static PlayerManager _instance;

    public static PlayerManager Instance {
        get {
            if (_instance == null) {
                Debug.LogError("null instance");
            }
            return _instance;
        }
    }
    private void Awake() {
        _instance = this;
    }

    public void SpawnPlayer(Vector2 pos) {
        playerTransform.position = pos;
    }

    public void DisablePlayerMovement() {
        playerMovement.DisableMovement();
    }
    public void EnablePlayerMovement() {
        playerMovement.EnableMovement();
    }
    public Transform GetTransform() {
        return playerTransform;
    }
}
