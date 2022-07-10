using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickBomb : MonoBehaviour
{
    public float force = 0.03f;

    private Rigidbody2D rb;
    private Vector2 forceDirection;

    void Awake() {
        forceDirection = new Vector2(0f, 0f);
        rb = GetComponent<Rigidbody2D>();
    }
    

    void OnTriggerEnter2D(Collider2D collider) {
        Debug.Log(collider.tag);
        forceDirection = collider.gameObject.GetComponent<PlayerMovement>().direction;
        rb.AddForce(forceDirection * force, ForceMode2D.Impulse);
    }
}