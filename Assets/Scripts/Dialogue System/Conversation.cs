using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Conversation {
    public ConversationName convoName;
    public List<Dialogue> dialogues = new List<Dialogue>();
    public KeyCode nextDialogueKey = KeyCode.Return;

    public bool isConvoActive = false;

    int currentDialogueIndex = -1;

    public void EnterConversation() {
        if (isConvoActive == false) {
            isConvoActive = true;
            MoveWithNextDialogue();
        }
    }

    public void MoveWithNextDialogue() {
        if (currentDialogueIndex + 1 == dialogues.Count) {
            currentDialogueIndex = -1;
            isConvoActive = false;
            return;
        }
        currentDialogueIndex += 1;
        dialogues[currentDialogueIndex].StartDialogue();
    }

    public void ConversationUpdate() {
        if (Input.GetKeyDown(nextDialogueKey)) {
            MoveWithNextDialogue();
        }
    }
}
