using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public GameObject explosionObject;
    public float gridSize = 0.16f;
    public int explosionLength = 4;

    void Start() {
        GetComponent<SpriteRenderer>().enabled = true;
        Debug.Log("Bomb Placed");
        Invoke("Explode", 2f);
    }

    void Explode() {
        Debug.Log("Exploded");
        StartCoroutine(CreateExplosion(Vector2.up));
        StartCoroutine(CreateExplosion(Vector2.down));
        StartCoroutine(CreateExplosion(Vector2.left));
        StartCoroutine(CreateExplosion(Vector2.right));

        GetComponent<SpriteRenderer>().enabled = false;
    }

    IEnumerator CreateExplosion(Vector2 direction) {
        for (int i = 1; i <= explosionLength; i++) {
            RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position, direction, i*gridSize);
            
            if (!hit.collider) {               
                GameObject explosion = Instantiate(
                    explosionObject, 
                    (Vector2)transform.position + (i * gridSize * direction), 
                    transform.rotation) as GameObject;
                Destroy(explosion, 0.8f);

            } else {
                break;
            }

            yield return new WaitForSeconds(0f);
        }
    }
}
