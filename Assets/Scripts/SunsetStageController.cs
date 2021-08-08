using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunsetStageController : MonoBehaviour
{
    [SerializeField] Vector2 playerSpawnPos;

    bool levelExited = false;
    private void Awake() {
        levelExited = false;
        UIManager.Instance.FadeIn();
        PlayerManager.Instance.SetFootstep(soundsType.GrassFootstep);
        PlayerManager.Instance.SetCameraMode(CameraType.ZoomedInCamera);
        PlayerManager.Instance.SpawnPlayer(playerSpawnPos);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player") && !levelExited) {
            PlayerManager.Instance.PlayTheFinale();
            StartCoroutine(ExitLevelRoutine());
            levelExited = true;
        }
    }

    IEnumerator ExitLevelRoutine() {
        yield return new WaitForSeconds(3f);
        UIManager.Instance.FadeOut();
        GameManager.Instance.LoadAfterUnloadLevel(LevelStages.ExitLore, LevelStages.EntryLore);
    }
}
