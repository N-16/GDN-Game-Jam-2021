using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmLevel : MonoBehaviour
{
    [SerializeField] Vector2 playerSpawnPos;


    bool levelExited = false;
    // Start is called before the first frame update
    void Awake()
    {
        levelExited = false;
        UIManager.Instance.FadeIn();
        PlayerManager.Instance.SetFootstep(soundsType.GrassFootstep);
        PlayerManager.Instance.SetCameraMode(CameraType.ZoomedInCamera);
        PlayerManager.Instance.SpawnPlayer(playerSpawnPos);
        SoundManager.Instance.StopSound(soundsType.FarmAmbience);
        SoundManager.Instance.PlaySound(soundsType.FarmAmbience);
        PlayerManager.Instance.SetRespawnPosition(playerSpawnPos);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player") && !levelExited) {
            UIManager.Instance.FadeOut();
            SoundManager.Instance.SmoothStop(soundsType.FarmAmbience, 2f);
            StartCoroutine(ExitLevelRoutine());
            levelExited = true;
        }
    }


    IEnumerator ExitLevelRoutine() {
        yield return new WaitForSeconds(2f);
        GameManager.Instance.LoadAfterUnloadLevel(LevelStages.Farm, LevelStages.RainStorm);
    }

}
