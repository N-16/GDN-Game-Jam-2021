using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    private static UIManager _instance;

    public static UIManager Instance {
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

    [SerializeField] Text bigCentredText;
    [SerializeField] GameObject MainMenu, AfterDeadUI;
    [SerializeField] Image fadeImage;
    [SerializeField] Animator fadeController;

    [SerializeField] Animator mainMenuUIAnimator;


    public void DisplayBigCentredText(string text) {
        bigCentredText.text = text;
    }

    public void FadeOut() {
        fadeController.SetBool("FadeIn", false);
        fadeController.SetTrigger("FadeOut");
    }
    public void FadeIn() {
        fadeController.SetBool("FadeIn", true);
    }

    public void OpenMainMenu() {
        mainMenuUIAnimator.SetTrigger("OpenMainMenu");
    }
    public void CloseMainMenu() {
        mainMenuUIAnimator.SetTrigger("CloseMainMenu");
    }
    public void OnPlayButton() {
        FadeOut();
        CloseMainMenu();
        GameManager.Instance.LoadLevel(LevelStages.EntryLore);
    }
    public void OnQuitButton() {
        FadeOut();
        Application.Quit();
    }

    public void SetAfterDeadUI(bool set) {
        if (set) {
            AfterDeadUI.SetActive(true);
            return;
        }
        AfterDeadUI.SetActive(false);
    }
    public void OnRespawnButton() {
        if (GameManager.Instance.currentLevel.levelName == LevelStages.Farm) {
            SetAfterDeadUI(false);
            PlayerManager.Instance.Revive();
            GameManager.Instance.ReloadLevel();
        }
        else {
            SetAfterDeadUI(false);
            PlayerManager.Instance.SpawnAtRespawnPoint();
            PlayerManager.Instance.Revive();
        }
    }

    IEnumerator QuitRoutine() {
        yield return new WaitForSeconds(0.5f);
        Application.Quit();
    }

}
