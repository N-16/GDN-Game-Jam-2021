using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NormalDialogue : Dialogue {

    [TextArea (3,10)]
    public List<string> sentences = new List<string>();

    public override void StartDialogue() {
        DialogueManager.Instance.SpeakDialogue(characterName, sentences);
    }
}
