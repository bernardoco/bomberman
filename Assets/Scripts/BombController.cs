using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BombController : MonoBehaviour
{
    public GameObject explosionObject;
    public float gridSize = 0.16f;
    public int explosionLength = 4;

    Tilemap tilemap;

    void Start() {
        GetComponent<SpriteRenderer>().enabled = true;
        Invoke("Explode", 2f);
    }

    void Explode() {
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
                Vector3 bombPosition = (Vector2)transform.position + (i * gridSize * direction);
                bombPosition.z = transform.position.z;

                GameObject explosion = Instantiate(
                    explosionObject, 
                    bombPosition, 
                    transform.rotation) as GameObject;
                Destroy(explosion, 0.8f);

            } else if (hit.collider.tag == "Player") {
                hit.collider.gameObject.GetComponent<PlayerMovement>().alive = false;
                
            } else if (hit.collider.tag == "DestructableWall") {
                tilemap = hit.collider.gameObject.GetComponent<Tilemap>();
                Vector3Int tileCell = tilemap.WorldToCell(hit.point + direction*gridSize/2);
                tilemap.SetTile(tileCell, null);
                break;

            } else {
                break;
            }

            yield return new WaitForSeconds(0f);
        }
    }
}
