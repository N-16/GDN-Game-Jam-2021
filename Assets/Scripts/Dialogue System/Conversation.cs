using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Conversation { 
    public List<Dialogue> dialogues = new List<Dialogue>();
    public KeyCode nextDialogueKey = KeyCode.Return;

    int currentDialogueIndex = -1;

    void MoveWithNextDialogue() {
        currentDialogueIndex += 1;
        dialogues[currentDialogueIndex].StartDialogue();
    }

    public void ConversationUpdate() {
        if (Input.GetKeyDown(nextDialogueKey)) {
            MoveWithNextDialogue();
        }
    }
}
