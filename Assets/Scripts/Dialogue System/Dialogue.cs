using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue {
    public string characterName  = "beta";
    [TextArea (3, 5)]
    public string sentence = "maybe u forgot to fill the sentences lol";

    public virtual void StartDialogue() {
        SpeakDialogue(characterName, sentence);
    }
    public void SpeakDialogue(string character, string sentence) {
        Debug.Log(character + " : ");
        Debug.Log(sentence);
        UIDialogueManager.Instance.DisplayDialogue(character, sentence);
    }
}
