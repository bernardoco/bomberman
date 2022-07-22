using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildWall : MonoBehaviour
{
    public Tilemap buildableWallTileMap;
    public Tile buildableWallTile;

    public KeyCode buildWallKey;


    private Vector3 movementDirection;

    void Update() {
        if (Input.GetKeyDown(buildWallKey)) {
            movementDirection = GetComponent<PlayerMovement>().direction;
            if (movementDirection == new Vector3(0f, 0f, 0f)) {
                return;
            }

            Vector3Int currentCell = buildableWallTileMap.WorldToCell(transform.position);
            currentCell += Vector3Int.FloorToInt(movementDirection);

            buildableWallTileMap.SetTile(currentCell, buildableWallTile);
        }
    }
}
