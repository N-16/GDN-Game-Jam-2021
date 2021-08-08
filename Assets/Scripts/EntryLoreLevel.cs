using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryLoreLevel : MonoBehaviour
{
    [SerializeField] Vector2 playerSpawnPos;
    private void Awake() {
        UIManager.Instance.FadeIn();
        PlayerManager.Instance.SetFootstep(soundsType.GrassFootstep);
        PlayerManager.Instance.SetCameraMode(CameraType.ZoomedInCamera);
        PlayerManager.Instance.SpawnPlayer(playerSpawnPos);
        SoundManager.Instance.PlaySound(soundsType.TownAmbience);
    }
}
