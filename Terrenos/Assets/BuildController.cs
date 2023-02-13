using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildController : MonoBehaviour
{
    private Vector2 mousePos;
    private float startMouseDown;
    private float destroyTime = 0.8f;
    public Tilemap destructibleTilemap;
    public TileBase tileBase;
    // Start is called before the first frame update
    void Start()
    {
        destructibleTilemap = GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

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
            destructibleTilemap.SetTile(destructibleTilemap.WorldToCell(mousePos), null);
            startMouseDown = Time.time;
        }
    }
}
