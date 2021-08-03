using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue {
    public string characterName  = "beta";

    public virtual void StartDialogue() {
        DialogueManager.Instance.SpeakDialogue(characterName, new List<string>());
    }
}
