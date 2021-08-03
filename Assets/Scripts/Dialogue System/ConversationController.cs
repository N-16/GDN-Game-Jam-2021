using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationController : MonoBehaviour {

    public Conversation convo;

    private void Update() {
        convo.ConversationUpdate();
    }
}
