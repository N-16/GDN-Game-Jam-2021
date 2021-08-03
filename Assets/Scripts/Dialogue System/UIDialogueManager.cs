using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDialogueManager : MonoBehaviour{
    private static UIDialogueManager _instance;
    public static UIDialogueManager Instance {
        get {
            if (_instance == null) {
                Debug.LogError("null instance");
            }

            return _instance;
            }
        }

    void Awake() {
        _instance = this;
    }

    [SerializeField] Text characterText;
    [SerializeField] Text dialogueText;
    [SerializeField] Animator uiAnimator;


    public void DisplayDialogue(string characterName, string dialogue) {
        if (!uiAnimator.GetBool("PanelActive")) {
            uiAnimator.SetBool("PanelActive", true);
        }
        WipeThePanel();
        characterText.text = characterName + " :";
        dialogueText.text = dialogue;
    }

    public void RemovePanel() {
        uiAnimator.SetBool("PanelActive", false);
        WipeThePanel();
    }

    void WipeThePanel() {
        characterText.text = "";
        dialogueText.text = "";
    }
}
