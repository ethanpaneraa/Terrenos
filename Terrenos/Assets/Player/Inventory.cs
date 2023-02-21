using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> InventoryItems = new List<InventoryItem>();
    public Sprite bowSprite;
    public Sprite swordSprite;
    public Sprite pickaxeSprite;
    public Sprite blockSprite;

    // Start is called before the first frame update
    void Start()
    {
        // Bow
        InventoryItem bow = new InventoryItem();
        bow.Sprite = bowSprite;
        bow.HitDamage = 1;
        bow.itemName = "bow";
        InventoryItems.Add(bow);

        // Sword
        InventoryItem sword = new InventoryItem();
        sword.Sprite = swordSprite;
        sword.HitDamage = 2;
        sword.itemName = "sword";
        InventoryItems.Add(sword);

        // Pickaxe
        InventoryItem pickaxe = new InventoryItem();
        pickaxe.Sprite = pickaxeSprite;
        pickaxe.HitDamage = 1;
        pickaxe.Destroys = true;
        pickaxe.itemName = "pickaxe";
        InventoryItems.Add(pickaxe);

        // Block
        InventoryItem block = new InventoryItem();
        block.Sprite = blockSprite;
        block.Places = true;
        InventoryItems.Add(block);
        block.itemName = "block";

        // Empty

        // Etc
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
