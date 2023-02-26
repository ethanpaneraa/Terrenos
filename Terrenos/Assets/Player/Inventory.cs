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
    private GameObject front_hand;
    private GameObject Bow;
    private GameObject Sword;
    private GameObject Pickaxe;
    private GameObject Block;
    public GameObject activeItem;

    // Start is called before the first frame update
    void Start()
    {
        // Hand
        front_hand = GameObject.Find("male_arm_front");

        // Bow
        InventoryItem bow = new InventoryItem();
        bow.Sprite = bowSprite;
        bow.HitDamage = 1;
        bow.itemName = "bow";
        InventoryItems.Add(bow);
        Bow = new GameObject("Bow");
        Bow.AddComponent<SpriteRenderer>();
        Bow.GetComponent<SpriteRenderer>().sprite = bowSprite;
        Bow.SetActive(false);

        // Sword
        InventoryItem sword = new InventoryItem();
        sword.Sprite = swordSprite;
        sword.HitDamage = 2;
        sword.itemName = "sword";
        InventoryItems.Add(sword);
        Sword = new GameObject("Sword");
        Sword.AddComponent<SpriteRenderer>();
        Sword.GetComponent<SpriteRenderer>().sprite = swordSprite;
        Sword.SetActive(false);


        // Pickaxe
        InventoryItem pickaxe = new InventoryItem();
        pickaxe.Sprite = pickaxeSprite;
        pickaxe.HitDamage = 1;
        pickaxe.Destroys = true;
        pickaxe.itemName = "pickaxe";
        InventoryItems.Add(pickaxe);
        Pickaxe = new GameObject("Pickaxe");
        Pickaxe.AddComponent<SpriteRenderer>();
        Pickaxe.GetComponent<SpriteRenderer>().sprite = pickaxeSprite;
        Pickaxe.SetActive(true);
        activeItem = Pickaxe;

        // Block
        InventoryItem block = new InventoryItem();
        block.Sprite = blockSprite;
        block.Places = true;
        InventoryItems.Add(block);
        block.itemName = "block";
        Block = new GameObject("Block");
        Block.AddComponent<SpriteRenderer>();
        Block.GetComponent<SpriteRenderer>().sprite = blockSprite;
        Block.SetActive(false);

        // Empty

        // Etc
        GameObject slot_0 = GameObject.Find("InventorySlot (0)");
    }

    // Update is called once per frame
    void Update()
    {
        activeItem.transform.position = front_hand.transform.position;
    }
}
