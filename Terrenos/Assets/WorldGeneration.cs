using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class WorldGeneration : MonoBehaviour
{
    public Sprite blockSprite;
    public int worldWidth = 100;
    public static int worldHeight = 100;
    public List<Vector2> blocks = new List<Vector2>();
    public List<GameObject> blockObjects = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        GenerateWorld();
        RemoveBlock(new Vector2(1, 99));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnValidate()
    {
    }

    public void GenerateWorld()
    {
        for (int y = worldHeight - 1; y >= 0; y--)
        {
            for (int x = 0; x < worldWidth; x++)
            {
                PlaceBlock("block", "ground", blockSprite, new Vector2(x, y));
            }
        }
    }

    public void PlaceBlock(string name, string tag, Sprite sprite, Vector2 position)
    {
        GameObject newBlock = new GameObject(name);
        newBlock.tag = tag;
        newBlock.AddComponent<SpriteRenderer>();
        newBlock.GetComponent<SpriteRenderer>().sprite = sprite;
        newBlock.AddComponent<BoxCollider2D>();
        newBlock.transform.parent = transform;
        newBlock.transform.position = position;
        blocks.Add(position);
        blockObjects.Add(newBlock);
    }

    public void RemoveBlock(Vector2 position)
    {
        Destroy(blockObjects[blocks.IndexOf(position)]);
    }
}
