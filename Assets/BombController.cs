using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public GameObject explosionObject;
    public float gridSize = 0.16f;
    public int explosionLength = 4;

    void Update() {
        Ray explosionRayUp = new Ray(transform.position, Vector3.up);
        Ray explosionRayDown = new Ray(transform.position, Vector3.down);
        Ray explosionRayLeft = new Ray(transform.position, Vector3.left);  
        Ray explosionRayRight = new Ray(transform.position, Vector3.right);

        RaycastHit hitUp;
        RaycastHit hitDown;
        RaycastHit hitLeft;
        RaycastHit hitRight;

        for (int i = 1; i <= explosionLength; i++) {
            Physics.Raycast(explosionRayUp, out hitUp, i);

            if (!hitUp.collider) {
                Instantiate(
                    explosionObject, 
                    transform.position + (i * gridSize * Vector3.up), 
                    transform.rotation);
            } else {
                break;
            }
        }
    }
}
