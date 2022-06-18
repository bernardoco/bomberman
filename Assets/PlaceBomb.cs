using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBomb : MonoBehaviour
{
    public GameObject Bomb;
    public KeyCode placeBombKey = KeyCode.C;
    public float gridSize = 0.16f;

    private float offsetX = 0f;
    private float offsetY = 0f;

    void Update() {
        if (Input.GetKeyDown(placeBombKey)) {
            Vector3 bombPosition = transform.position;
            bombPosition.y -= 0.08f;

            // Snap bomb to grid
            offsetX = Mathf.Floor(bombPosition.x / gridSize);
            offsetX = gridSize * offsetX + gridSize/2;

            offsetY = Mathf.Floor(bombPosition.y / gridSize);
            offsetY = gridSize * offsetY + gridSize/2;         

            Instantiate(Bomb, new Vector3(offsetX, offsetY, 0), transform.rotation);
        }
    }
}
