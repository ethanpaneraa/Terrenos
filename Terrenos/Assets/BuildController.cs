using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildController : MonoBehaviour
{
    private Vector2 mousePos;
    private Vector3 playerPos;
    private Vector3 playerPosBelow;
    private float startMouseDown;
    private float destroyTime = 0.8f;
    public Tilemap destructibleTilemap;
    public TileBase[] tileBaseArray;
    public GameObject player;
    private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        destructibleTilemap = GetComponent<Tilemap>();
        playerTransform = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        playerPos = destructibleTilemap.WorldToCell(playerTransform.position);
        playerPosBelow = new Vector3(playerPos.x, playerPos.y - 1, playerPos.z);


        if (Input.GetMouseButtonDown(0))
        {
            startMouseDown = Time.time;
        }

        // destroying blocks
        if (Input.GetMouseButton(0) && Time.time - startMouseDown > destroyTime)
        {
            destructibleTilemap.SetTile(destructibleTilemap.WorldToCell(mousePos), null);
            startMouseDown = Time.time;
        }

        // placing blocks
        if (Input.GetKey(KeyCode.P))
        {
            if ((destructibleTilemap.WorldToCell(mousePos) != playerPos) &&
                (destructibleTilemap.WorldToCell(mousePos) != playerPosBelow))
            {
                destructibleTilemap.SetTile(destructibleTilemap.WorldToCell(mousePos), tileBaseArray[0]);
                startMouseDown = Time.time;
            }
        }
    }
}
