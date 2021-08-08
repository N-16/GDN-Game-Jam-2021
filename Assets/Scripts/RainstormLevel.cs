using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainstormLevel : MonoBehaviour {

    private void Awake() {
        SoundManager.Instance.PlaySound(soundsType.RainAmbience);
        PlayerManager.Instance.SetFootstep(soundsType.WaterFootstep);
        PlayerManager.Instance.SetCameraMode(CameraType.ParkourCamera);
    }
}
