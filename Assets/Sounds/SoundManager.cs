using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;
    public static SoundManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("null instance");
            return _instance;
        }
    }
    [SerializeField] private List<Sound> sounds;
    [SerializeField] private List<Sound> grassFootsteps;
    [SerializeField] private List<Sound> waterFootsteps;

    Sound soundsOnSmooothStop;
    private void Awake()
    {
        _instance = this;
        foreach(Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.loop = sound.looping;
        }

        foreach(Sound sound in grassFootsteps) {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.loop = sound.looping;
        }

        foreach (Sound sound in waterFootsteps) {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.loop = sound.looping;
        }
    }
    public void PlaySound(soundsType type)
    {
        foreach (Sound sound in sounds)
        {
            if (type == sound.soundType)
            {
                sound.source.Play();
                return;
            }
            
        }
    }
    public void PauseSound(soundsType type)
    {
        foreach (Sound sound in sounds)
        {
            if (type == sound.soundType)
            {
                sound.source.Pause();
                return;
            }
            
        }
    }
    public void StopSound(soundsType type)
    {
        foreach (Sound sound in sounds)
        {
            if (type == sound.soundType)
            {
                sound.source.Stop();
                return;
            }
        }
        
    }
    public void PlayFootstep(soundsType footstep) {
        if (footstep == soundsType.GrassFootstep) {
            grassFootsteps[Random.Range(0, grassFootsteps.Count)].source.Play();
            return;
        }
        if (footstep == soundsType.WaterFootstep) {
            waterFootsteps[Random.Range(0, waterFootsteps.Count)].source.Play();
            return;
        }
        Debug.LogError("Invalid Footstep sound");
    }

    public void SmoothStop(soundsType type, float timeOfStop) {
        if (soundsOnSmooothStop != null) {
            StopSound(type);
            Debug.Log("Sound Already on smoothstop");
            return;
        }
        foreach (Sound sound in sounds) {
            if (type == sound.soundType) {
                StartCoroutine(SoundStopCoroutine(sound, sound.volume, timeOfStop));
                soundsOnSmooothStop = sound;
            }
        }
    }

    IEnumerator SoundStopCoroutine(Sound soundToStop, float orgVolume, float timeOfStop) {
        yield return new WaitForSeconds(timeOfStop);
        StopSound(soundToStop.soundType);
        soundToStop.source.volume = orgVolume;
        soundsOnSmooothStop = null;
    }

    void Update() {
        if (soundsOnSmooothStop != null) {
            soundsOnSmooothStop.source.volume -= 0.05f;
        }
    }
}
[System.Serializable]
public class Sound
{
    [Range(0f, 1f)] public float volume;
    public AudioClip clip;
    public bool looping;
    public soundsType soundType;
    [HideInInspector] public AudioSource source;
}
public enum soundsType
{
    FallGrassSound,
    FallWaterSound,
    JumpSound,
    CrowAttackSound,
    RainAmbience,
    TownAmbience,
    FarmAmbience,
    ScareCrowInteraction,
    GrassFootstep,
    WaterFootstep
}

public enum FootstepType {
    Water, Grass
}