using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryLoreLevel : MonoBehaviour
{
    [SerializeField] Vector2 playerSpawnPos;

    bool levelExited = false;
    private void Awake() {
        levelExited = false;
        UIManager.Instance.FadeIn();
        PlayerManager.Instance.SetFootstep(soundsType.GrassFootstep);
        PlayerManager.Instance.SetCameraMode(CameraType.ZoomedInCamera);
        PlayerManager.Instance.SpawnPlayer(playerSpawnPos);
        SoundManager.Instance.PlaySound(soundsType.TownAmbience);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player") && !levelExited) {
            UIManager.Instance.FadeOut();
            SoundManager.Instance.SmoothStop(soundsType.TownAmbience, 2f);
            StartCoroutine(ExitLevelRoutine());
            levelExited = true;
        }
    }

    IEnumerator ExitLevelRoutine() {
        yield return new WaitForSeconds(2f);
        GameManager.Instance.LoadAfterUnloadLevel(LevelStages.EntryLore, LevelStages.Farm);
    }
}
