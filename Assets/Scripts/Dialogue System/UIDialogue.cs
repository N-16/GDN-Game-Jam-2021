using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDialogue : MonoBehaviour {

    [SerializeField] Text characterText;
    [SerializeField] Text dialogueText;
    [SerializeField] Animator uiAnimator;


    bool dialoguePanelActive = false;
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
