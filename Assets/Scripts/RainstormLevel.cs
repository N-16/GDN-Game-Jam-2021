using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainstormLevel : MonoBehaviour {
    [SerializeField] Vector2 playerSpawnPos;
    bool levelExited = false;

    private void Awake() {
        levelExited = false;
        UIManager.Instance.FadeIn();
        SoundManager.Instance.PlaySound(soundsType.RainAmbience);
        PlayerManager.Instance.SetFootstep(soundsType.WaterFootstep);
        PlayerManager.Instance.SetCameraMode(CameraType.ParkourCamera);
        PlayerManager.Instance.SetRespawnPosition(playerSpawnPos);
        PlayerManager.Instance.SpawnPlayer(playerSpawnPos);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player") && !levelExited) {
            UIManager.Instance.FadeOut();
            SoundManager.Instance.SmoothStop(soundsType.RainAmbience, 2f);
            StartCoroutine(ExitLevelRoutine());
            levelExited = true;
        }
    }

    IEnumerator ExitLevelRoutine() {
        yield return new WaitForSeconds(2f);
        GameManager.Instance.LoadAfterUnloadLevel(LevelStages.RainStorm, LevelStages.ExitLore);
    }
}
