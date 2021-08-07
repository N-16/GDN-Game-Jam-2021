using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{

    BoxCollider2D interactionZone;
    [SerializeField] Conversation convo = new Conversation();
    [SerializeField] LayerMask playerLayer;

    private void Awake() {
        interactionZone = GetComponent<BoxCollider2D>();
    }

    private void Update() {
        if (Physics2D.OverlapBox(interactionZone.transform.position, interactionZone.bounds.size, 0f, playerLayer)) {
            if (!convo.isConvoActive && Input.GetKeyDown(convo.nextDialogueKey)) {
                Debug.Log("bruh");
                ConversationManager.Instance.StartConversation(convo);
            }
        }
    }

}
