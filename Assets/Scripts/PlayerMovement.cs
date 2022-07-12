using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public KeyCode Up = KeyCode.W;
    public KeyCode Down = KeyCode.S;
    public KeyCode Left = KeyCode.A;
    public KeyCode Right = KeyCode.D;
    public KeyCode Dash = KeyCode.E;

    public float dashCooldown = 4f;
    private float dashRemainingCooldown = 0f;

    public float dashSpeed = 2f;
    public float dashTimeLength = 1f;
    private float dashTimeLeft = 0f;
    private bool canDash;

    public float movementSpeed = 0.5f;
    
    public Vector2 direction;
    public bool alive;

    public float speed;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sr;

    public GameObject dashObject;

    public Sprite deadSprite;

    void Awake() {
        direction = new Vector2(0f, -1f);
        alive = true;
        canDash = true;

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void move(Vector2 direction) {
        rb.MovePosition(rb.position + direction * movementSpeed * Time.fixedDeltaTime);
    }

    private void dash(Vector2 direction) {
        rb.MovePosition(rb.position + direction * dashSpeed * Time.fixedDeltaTime * dashTimeLeft * 10);
    }

    void Update() {
        if (alive) {
            if (Input.GetKeyDown(Dash) && canDash) {
                canDash = false;
                dashRemainingCooldown = dashCooldown;
                dashTimeLeft = dashTimeLength;
                GameObject d = Instantiate(dashObject, transform.position, transform.rotation) as GameObject;
                Destroy(d, 0.6f);
            }

            if (!canDash) {
                dashRemainingCooldown = dashRemainingCooldown - Time.deltaTime;
                if (dashRemainingCooldown <= 0) {
                    canDash = true;
                }
            }

            if (dashTimeLeft <= 0) {
                speed = movementSpeed;
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
            }

        } else {
            animator.enabled = false;
            sr.sprite = deadSprite;
            direction = new Vector2(0f, 0f);
        }

        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Speed", direction.sqrMagnitude);
    }


    void FixedUpdate() {
        if (dashTimeLeft > 0) {
            dash(direction);
            dashTimeLeft = dashTimeLeft - Time.deltaTime;
            speed = dashSpeed * dashTimeLeft * 10;
        }
        else {
            move(direction);
        }
    }
}