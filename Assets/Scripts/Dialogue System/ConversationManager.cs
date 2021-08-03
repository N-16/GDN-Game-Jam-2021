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
    }
    private void Start() {
        StartConversation(ConversationName.Test);
    }

    public List<Conversation> convos = new List<Conversation>();
    Conversation currentConvo;
        bool convoActive = false;

    public void StartConversation(ConversationName convoTag) {
        foreach( Conversation convo in convos) {
            if ( convo.convoName == convoTag) {
                convoActive = true;
                currentConvo = convo;
                break;
            }
        }
    }
    private void Update() {
        if (convoActive) {
            if (currentConvo.isConvoOver) { // if conversation is over
                convoActive = false;
                UIDialogueManager.Instance.RemovePanel();
                currentConvo.EndOfConversation();
                return;
            }
            currentConvo.ConversationUpdate();
        }
    }
}

public enum ConversationName {
    Test,
}
