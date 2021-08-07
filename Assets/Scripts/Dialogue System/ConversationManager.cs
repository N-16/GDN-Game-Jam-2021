using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationManager : MonoBehaviour
{
    private static ConversationManager _instance;

    public static ConversationManager Instance {
        get {
            if (_instance == null) {
                Debug.LogError("null instance");
            }
            return _instance;
        }
    }

    void Awake() {
        _instance = this;
        currentConvo = null;
    }


    public List<Conversation> convos = new List<Conversation>();
    Conversation currentConvo;
    bool convoActive = false;

    public void StartConversation(Conversation convo) { {
            if (currentConvo == null) {
                Debug.Log("STARTING CONVERSATION......");
                convoActive = true;
                currentConvo = convo;
                currentConvo.EnterConversation();
                PlayerManager.Instance.DisablePlayerMovement();
                return;
            }
            Debug.Log("convo ongoing");
        }
    }
    private void Update() {
        if (convoActive) {
            if (!currentConvo.isConvoActive) { // if conversation is over
                convoActive = false;
                UIDialogueManager.Instance.RemovePanel();
                currentConvo = null;
                PlayerManager.Instance.EnablePlayerMovement();
                return;
            }
            currentConvo.ConversationUpdate();
        }
    }
}

public enum ConversationName {
    Test
}
