using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickBomb : MonoBehaviour
{
    public float force = 0.03f;

    private Rigidbody2D rb;
    private Vector2 forceDirection;
    private Vector2 movementDirection;

    void Awake() {
        forceDirection = new Vector2(0f, 0f);
        rb = GetComponent<Rigidbody2D>();
    }
    

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Wall") {
            // Movement Direction
            movementDirection = GetComponent<Rigidbody2D>().velocity;
            Debug.Log(movementDirection);
            rb.AddForce(-movementDirection * force * 2f, ForceMode2D.Impulse);
        }
        else {
            forceDirection = collider.gameObject.GetComponent<PlayerMovement>().direction;
            rb.AddForce(forceDirection * force, ForceMode2D.Impulse);
        }
    }
}