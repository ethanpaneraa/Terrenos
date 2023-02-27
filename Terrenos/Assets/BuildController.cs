using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildController : MonoBehaviour
{
    private Vector3Int mousePos;
    private Vector3 playerPos;
    private Vector3 playerPosBelow;
    private float startMouseDown;
    private float destroyTime = 0.8f;
    public Tilemap destructibleTilemap;
    public TileBase[] tileBaseArray;
    public GameObject player;
    private Transform playerTransform;
    private BuildController buildController;
    private int blocksDestroyed = 0; 
    public XpBar XpBar;
    public PlayerController playerController;
    private Inventory inventory;
    private InventoryItem inventoryItem;
    
    // Start is called before the first frame update
    void Start()
    {
        destructibleTilemap = GetComponent<Tilemap>();
        playerTransform = player.GetComponent<Transform>();
        buildController = this;
        playerController = player.GetComponent<PlayerController>();
        inventory = playerController.inventory;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = destructibleTilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        playerPos = destructibleTilemap.WorldToCell(playerTransform.position);
        playerPosBelow = new Vector3(playerPos.x, playerPos.y - 1, playerPos.z);
        inventoryItem = inventory.selectedInventoryItem;

        if (Input.GetMouseButtonDown(0))
        {
            startMouseDown = Time.time;
        }



        // destroying blocks
        if (Input.GetMouseButton(0) &&
            Time.time - startMouseDown > destroyTime &&
            buildController.CanDestroy(mousePos) &&
            inventoryItem.Destroys)
        {
            destructibleTilemap.SetTile(mousePos, null);
            startMouseDown = Time.time;
            blocksDestroyed += 1; 
            if (blocksDestroyed == 5) {
                XpBar.setXP(XpBar.currentXP += 10); 
                blocksDestroyed = 0; 
            }
        }

        // placing blocks
        if (Input.GetMouseButton(0) && 
            CanBuild(mousePos) &&
            inventoryItem.Places)
        {
            // set tile
            destructibleTilemap.SetTile(mousePos, tileBaseArray[0]);
            startMouseDown = Time.time;
        }
    }
    // check if any tiles are adjacent
    public bool CanBuild(Vector3Int cellPos)
    {
        if (cellPos == playerPos || cellPos == playerPosBelow)
        {
            return false;
        }
        if (destructibleTilemap.GetTile(cellPos) != null)
        {
            return false;
        }
        if ((destructibleTilemap.GetTile(new Vector3Int(cellPos.x + 1, cellPos.y, cellPos.z)) != null) ||
            (destructibleTilemap.GetTile(new Vector3Int(cellPos.x - 1, cellPos.y, cellPos.z)) != null) ||
            (destructibleTilemap.GetTile(new Vector3Int(cellPos.x, cellPos.y + 1, cellPos.z)) != null) ||
            (destructibleTilemap.GetTile(new Vector3Int(cellPos.x, cellPos.y - 1, cellPos.z)) != null))
        {
            return inventoryItem.Places;
        }
        return false;
    }
    public bool CanDestroy(Vector3Int cellPos)
    {
        if (destructibleTilemap.GetTile(cellPos) != null)
        {
            return inventoryItem.Destroys;
        }
        return false;
    }
}
