using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour {
    public static DialogueManager _instance;

    public static DialogueManager Instance {
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

    //List<Conversation> conversations = new List<Conversation>();

    public void SpeakDialogue(string character, List<string> sentences) {
        Debug.Log(character + " : " );
        foreach(string sentence in sentences) {
            Debug.Log(sentence);
        }
    }
}
