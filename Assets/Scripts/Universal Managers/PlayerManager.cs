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
}

public enum CameraType {
    ParkourCamera, ZoomedInCamera
}

