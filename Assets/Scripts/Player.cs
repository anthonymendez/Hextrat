using System.Collections;
using System.Collections.Generic;
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
        if (Input.GetMouseButtonDown(0)) {
            Vector3 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int roundedPos = new Vector3Int((int)(clickPos.x), (int)(clickPos.y), 0);
            TileBase tile = tilemap.GetTile(roundedPos);
            
            if (tile != null) {

            }
        }
    }
}
