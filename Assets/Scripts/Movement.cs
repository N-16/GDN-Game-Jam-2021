using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField] private LayerMask solidEnvironment;
    [SerializeField] private Collider2D baseCollider; 
    [Header ("Movement Values")]
    [SerializeField] float jumpHeight = 1.5f;
    [SerializeField] float moveSpeed = 12f;
    [SerializeField] float moveSpeedOnFlight = 6f;
    [SerializeField] float fallGravityMultiplier = 2.5f;
    [SerializeField] bool enableSnappyFall = true;


    [SerializeField] BoxCollider2D playerCollider;
    [SerializeField] bool controlOnFlight = true;

    private bool isGrounded;
    private float headRotate = 0f;
    float playerSpeed;

    private bool jumpInput = false;
    private float horizontal = 0f;

    float jumpVelocity; // will be calculated according to jump height

    void Awake() { 

        if (!playerRB) 
            playerRB = GetComponent<Rigidbody2D>();
 
        if (!playerCollider)
            playerCollider = GetComponent<BoxCollider2D>();
    }

    private void Start() {
        jumpVelocity = Mathf.Sqrt(2 * -playerRB.gravityScale * Physics2D.gravity.y * jumpHeight);
        Debug.Log(Physics.gravity.y);
    }

    void Update() {
        TakeInput();
        if (enableSnappyFall) {
            SnappyFall();
        }
    }
    void FixedUpdate() {
        Move();
        Jump();
    }

    private void TakeInput() {
        horizontal = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && baseCollider.IsTouchingLayers(solidEnvironment))
            jumpInput = true;

    }

    public void Jump() {
        if (baseCollider.IsTouchingLayers(solidEnvironment) && jumpInput) {
            jumpInput = false;
            playerRB.velocity += Vector2.up * jumpVelocity;
            //playerRB.AddForce(Vector2.up * 400f, ForceMode2D.Impulse);
        }
    }
    public void Move() {
        if (baseCollider.IsTouchingLayers(solidEnvironment)) {

            if (horizontal != 0f)
                playerRB.velocity = new Vector2(horizontal * moveSpeed, playerRB.velocity.y);

        }
        else if (controlOnFlight) {
            if (horizontal != 0f) {
                playerRB.velocity = new Vector2(horizontal * moveSpeedOnFlight, playerRB.velocity.y);
            }
        }

        headRotate = horizontal < 0 ? 180 : horizontal > 0 ? 0 : headRotate;
        transform.localRotation = Quaternion.Euler(0f, headRotate, 0f);
    }
    public void SnappyFall() {
        if (playerRB.velocity.y < 0)
            playerRB.velocity += Physics.gravity * playerRB.gravityScale * Vector2.up * (fallGravityMultiplier - 1f) * Time.deltaTime;
    }
}
