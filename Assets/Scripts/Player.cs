using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{

    private Tilemap tilemap;

    void Start()
    {
        tilemap = GetComponentInParent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    void HandleInput() {
        bool playerTile = Input.GetMouseButtonDown(0);
        bool enemyTile = Input.GetMouseButtonDown(1);

        if (playerTile || enemyTile) {
            Vector3 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int roundedPos = tilemap.LocalToCell(clickPos);
            
            BoardTile tile = (BoardTile)tilemap.GetTile(roundedPos);
            
            if (tile != null) {
                if (playerTile)
                    tile.tileType = BoardTile.TileType.Player;
                else if (enemyTile)
                    tile.tileType = BoardTile.TileType.Enemy;
                tilemap.RefreshTile(roundedPos);
            }
        }
    }
}