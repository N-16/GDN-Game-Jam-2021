using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scarecrow : MonoBehaviour
{
    public bool Activated { private set; get; }

    private void Start() {
        Activated = true;
    }

    public void SetActivation(bool activation) {
        Activated = activation;
    }
}

