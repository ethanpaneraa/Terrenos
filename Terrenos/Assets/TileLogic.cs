using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileLogic : MonoBehaviour
{
    public Tilemap hoverTilemap;
    public TileBase hoverTile;
    private GameObject player;
    private Vector3 playerPos;
    private Vector3 playerPosBelow;
    public BuildController buildController;
    Vector3Int mousePos;
    Vector3Int oldPos;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
    }

    // Update is called  once per frame
    void Update()
    {
        mousePos = hoverTilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        playerPos = hoverTilemap.WorldToCell(player.transform.position);
        playerPosBelow = new Vector3(playerPos.x, playerPos.y-1, playerPos.z);

        if (mousePos.x != oldPos.x || mousePos.y != oldPos.y)
        {
            hoverTilemap.SetTile(oldPos, null);
            if (buildController.CanBuild(mousePos) || buildController.CanDestroy(mousePos))
            {
                hoverTilemap.SetTile(mousePos, hoverTile);
            }
            oldPos = mousePos;
        }
        if (mousePos == playerPos || mousePos == playerPosBelow)
        {
            hoverTilemap.SetTile(mousePos, null);
        }
    }
}
