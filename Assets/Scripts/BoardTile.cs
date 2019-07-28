using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BoardTile : TileBase
{

    public enum TileType { Player, Enemy, Default };
    [SerializeField] private Sprite playerTileSprite;
    [SerializeField] private Sprite enemyTileSprite;
    [SerializeField] private Sprite defaultTileSprite;

    [SerializeField] public TileType tileType;

    override public void RefreshTile(Vector3Int location, ITilemap tilemap) {
        base.RefreshTile(location, tilemap);
    }

    public override void GetTileData(Vector3Int location, ITilemap tileMap, ref TileData tileData) {
        base.GetTileData(location, tileMap, ref tileData);
        switch (tileType) {
            case TileType.Default:
                tileData.sprite = defaultTileSprite;
                break;
            case TileType.Player:
                tileData.sprite = playerTileSprite;
                break;
            case TileType.Enemy:
                tileData.sprite = enemyTileSprite;
                break;
        }
    }

    #if UNITY_EDITOR
        // The following is a helper that adds a menu item to create a Tile
        [MenuItem("Assets/Create/BoardTile")]
        public static void CreateRoadTile() {
            string path = EditorUtility.SaveFilePanelInProject("Save Board Tile", "New Board Tile", "Asset", "Save Board Tile", "Assets");
            if (path == "")
                return;
            AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<BoardTile>(), path);
        }
    #endif
}
