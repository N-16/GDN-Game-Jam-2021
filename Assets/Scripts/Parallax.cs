using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float startPos = 0f;
    [SerializeField] private float spriteLength;
    [SerializeField] private float parallaxFx;
    void Awake()
    {
        //spriteLength = GetComponent<SpriteRenderer>().bounds.size.x;
        startPos = transform.position.x;
    }

    void Update()
    {
        transform.position = new Vector3(startPos + (Camera.main.transform.position.x * parallaxFx), transform.position.y, transform.position.z);
    }
}
