using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    [SerializeField] string playerSceneName;
    [SerializeField] List<GameLevel> levels = new List<GameLevel>();
    GameLevel currentLevel;

    Vector2 zeroVector = Vector2.zero;

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

    public void OnPlayerDeath() {
        UIManager.Instance.DisplayBigCentredText("PLAYER DEAD GAME OVER");
    } 
    public void LoadLevel(LevelStages levelNameNoCapsBro) {
        foreach(GameLevel level in levels) {
            if (level.levelName == levelNameNoCapsBro) {
                if (!SceneManager.GetSceneByName(level.sceneName).isLoaded) {
                    SceneManager.LoadSceneAsync(level.sceneName, LoadSceneMode.Additive);
                    PlayerManager.Instance.SpawnPlayer(level.playerDefaultSpawn);
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
                if (SceneManager.GetSceneByName(level.sceneName).isLoaded) {
                    SceneManager.UnloadSceneAsync(level.sceneName, UnloadSceneOptions.None);
                }
                return;
            }
        }
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




