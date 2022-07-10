using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public KeyCode Up = KeyCode.W;
    public KeyCode Down = KeyCode.S;
    public KeyCode Left = KeyCode.A;
    public KeyCode Right = KeyCode.D;

    public float movementSpeed = 0.1f;
    
    public Vector2 direction;
    public bool alive;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sr;

    void Awake() {
        direction = new Vector2(0f, -1f);
        alive = true;

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void move(Vector2 direction) {
        rb.MovePosition(rb.position + direction * movementSpeed * Time.deltaTime);
    }

    void Update() {
        if (alive) {
            if (Input.GetKey(Up)) {
                direction = new Vector2(0f, 1f);
            } else if (Input.GetKey(Down)) {
                direction = new Vector2(0f, -1f);
            } else if (Input.GetKey(Left)) {
                direction = new Vector2(-1f, 0f);
            } else if (Input.GetKey(Right)) {
                direction = new Vector2(1f, 0f);
            } else {
                direction = new Vector2(0f, 0f);
            }

            if (direction.x < 0.01) {
                sr.flipX = true;
            } else {
            sr.flipX = false;
            }

        } else {
            direction = new Vector2(0f, 0f);
        }

        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Speed", direction.sqrMagnitude);
    }


    void FixedUpdate() {
        move(direction);
    }
}