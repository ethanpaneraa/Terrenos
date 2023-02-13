using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileLogic : MonoBehaviour
{
    public Tilemap hoverTilemap;
    public TileBase hoverTile;
    Vector2 mousePos;
    Vector3Int oldCellPos;
    Vector3Int currCellPos;
    // Start is called before the first frame update
    void Start()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        oldCellPos.x = hoverTilemap.WorldToCell(mousePos).x;
        oldCellPos.y = hoverTilemap.WorldToCell(mousePos).y;
        hoverTilemap.SetTile(oldCellPos, hoverTile);
    }

    // Update is called  once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        currCellPos.x = hoverTilemap.WorldToCell(mousePos).x;
        currCellPos.y = hoverTilemap.WorldToCell(mousePos).y;
        if (currCellPos.x != oldCellPos.x || currCellPos.y != oldCellPos.y)
        {
            hoverTilemap.SetTile(oldCellPos, null);
            hoverTilemap.SetTile(currCellPos, hoverTile);
            oldCellPos = currCellPos;
        }
    }
}
