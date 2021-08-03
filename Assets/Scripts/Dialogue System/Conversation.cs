using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Conversation {
    public ConversationName convoName;
    public List<Dialogue> dialogues = new List<Dialogue>();
    public KeyCode nextDialogueKey = KeyCode.Return;

    public bool isConvoOver { private set; get; }

    int currentDialogueIndex = -1;

    void MoveWithNextDialogue() {
        if (currentDialogueIndex + 1 == dialogues.Count) {
            currentDialogueIndex = -1;
            isConvoOver = true;
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
    public void EndOfConversation() {
        isConvoOver = false;
    }
}
