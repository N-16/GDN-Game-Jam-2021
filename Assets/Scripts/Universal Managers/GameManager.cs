using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    [SerializeField] string playerSceneName;
    [SerializeField] List<GameLevel> levels = new List<GameLevel>();
    public GameLevel currentLevel { private set; get; }

    Vector2 zeroVector = Vector2.zero;
    float timeAtLastLevelLoad;

    public static GameManager Instance {
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




    private void Update() {
        
    }

    public void LoadLevel(LevelStages levelNameNoCapsBro) {
        foreach(GameLevel level in levels) {
            if (level.levelName == levelNameNoCapsBro) {
                if (!SceneManager.GetSceneByName(level.sceneName).isLoaded) {
                    SceneManager.LoadSceneAsync(level.sceneName, LoadSceneMode.Additive);
                    currentLevel = level;
                    timeAtLastLevelLoad = Time.time;
                }
                return;
            }
        }
        //Debug.LogError("Invalid level name");
    }
    public void UnloadLevel(LevelStages levelName) {
        foreach (GameLevel level in levels) {
            if (level.levelName == levelName) {
                //load scene 
                //load player
                PlayerManager.Instance.DespawnPlayer();
                if (SceneManager.GetSceneByName(level.sceneName).isLoaded) {
                    SceneManager.UnloadSceneAsync(level.sceneName, UnloadSceneOptions.None);
                }
                return;
            }
        }
    }

    public void ReloadLevel() {
        if (SceneManager.GetSceneByName(currentLevel.sceneName).isLoaded) {
            SceneManager.UnloadSceneAsync(currentLevel.sceneName, UnloadSceneOptions.None);
        }
        else { return; }
        SceneManager.LoadSceneAsync(currentLevel.sceneName, LoadSceneMode.Additive);
        StartCoroutine(LoadLevelRoutine(currentLevel));
    }

    public void LoadAfterUnloadLevel(LevelStages unload, LevelStages load) {
        UnloadLevel(unload);
        LoadLevel(load);
    }

    IEnumerator LoadLevelRoutine(GameLevel level) {
        yield return new WaitForSeconds(1f);

    }

}

[System.Serializable]
public struct GameLevel {
    public LevelStages levelName;
    public string sceneName;
    public Vector2 playerDefaultSpawn;
}

public enum LevelStages { 
    EntryLore,
    Farm,
    RainStorm,
    ExitLore,
    Test
}




