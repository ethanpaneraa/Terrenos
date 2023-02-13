using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class WorldGeneration : MonoBehaviour
{
    public Sprite blockSprite;
    public static int worldWidth = 100;
    public static int worldHeight = 100;
    public List<Vector2> blocks = new List<Vector2>();
    public List<GameObject> blockObjects = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        GenerateWorld();
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
        if (!blocks.Contains(position))
        {
            GameObject newBlock = new GameObject(name);
            newBlock.tag = tag;
            newBlock.AddComponent<BoxCollider2D>();
            newBlock.GetComponent<BoxCollider2D>().size = new Vector2(1, 1);
            newBlock.transform.position = position;
            newBlock.transform.parent = transform;
            newBlock.AddComponent<SpriteRenderer>();
            newBlock.GetComponent<SpriteRenderer>().sprite = sprite;
            blocks.Add(position);
            blockObjects.Add(newBlock);
        }
    }

    public void RemoveBlock(Vector2 position)
    {
        if (blocks.Contains(position))
        {
            int removal_index = blocks.IndexOf(position);
            Destroy(blockObjects[removal_index]);
            blockObjects.RemoveAt(removal_index);
            blocks.Remove(position);
        }
    }
}