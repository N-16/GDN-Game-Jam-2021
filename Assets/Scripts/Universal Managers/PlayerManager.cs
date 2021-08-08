using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] Player player;
    [SerializeField] Movement playerMovement;
    [SerializeField] GameObject parkourCamera, zoomedInCamera;
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] Animator playerAnimator;

    Vector3 respawnPosition;
    public bool dead = false;
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
        playerRb.isKinematic = false;
        playerMovement.EnableMovement();
    }

    public void SpawnAtRespawnPoint() {
        SpawnPlayer(respawnPosition);
        Debug.Log("respawned at" + respawnPosition);
    }

    public void DespawnPlayer() {
        playerMovement.DisableMovement();
        playerRb.isKinematic = true;
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
    public void SetFootstep(soundsType footstep) {
        if (footstep != soundsType.WaterFootstep && footstep != soundsType.GrassFootstep) {
            Debug.LogError("Invalid Footstep");
            return;
        }
        player.footstepMode = footstep;
        if (footstep == soundsType.WaterFootstep) {
            player.fallSoundMode = soundsType.FallWaterSound;
            return;
        }
        player.fallSoundMode = soundsType.FallGrassSound;
    }

    public void SetCameraMode(CameraType camType) {
        if (camType == CameraType.ParkourCamera) {
            zoomedInCamera.SetActive(false);
            parkourCamera.SetActive(true);
            return;
        }
        parkourCamera.SetActive(false);
        zoomedInCamera.SetActive(true);
    }

    public void PlayTheFinale() {
        DisablePlayerMovement();
        playerRb.velocity = new Vector2(0f, 0f);
        playerAnimator.SetTrigger("kneel");
        StartCoroutine(DisableKneelRoutine());
    }

    public void SetRespawnPosition(Vector3 pos) {
        respawnPosition = pos;
    }

    public void Die() {
        if (!dead) {
            playerMovement.DisableMovement();
            playerAnimator.SetTrigger("die");
            dead = true;
        }
    }

    public void Revive() {
        if (dead) {
            playerAnimator.SetTrigger("revive");
            playerMovement.EnableMovement();
            StartCoroutine(InVulnerableRoutine());
        }
    }

    public void OnPlayerDeath() {
        UIManager.Instance.SetAfterDeadUI(true);
        Die();
    }

    IEnumerator DisableKneelRoutine() {
        yield return new WaitForSeconds(3f);
        playerAnimator.SetTrigger("kneelOver");
    }
    public bool IsDead() {
        return dead;
    }
    IEnumerator InVulnerableRoutine() {
        yield return new WaitForSeconds(2f);
        dead = false;
    }
}

public enum CameraType {
    ParkourCamera, ZoomedInCamera
}

