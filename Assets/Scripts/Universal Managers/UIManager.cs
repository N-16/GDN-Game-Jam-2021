using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;

    public static UIManager Instance {
        get {
            if (_instance == null) {
                Debug.LogError("null instance");
            }
            return _instance;
        }
    }

    private void Awake() {
        _instance = this;
    }

    [SerializeField] Text bigCentredText;

    public void DisplayBigCentredText(string text) {
        Debug.Log("WHY TEXT AINT WORKING THEN");
        bigCentredText.text = text;
    }
}
