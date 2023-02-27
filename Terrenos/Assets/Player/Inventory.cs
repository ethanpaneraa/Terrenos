using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> InventoryItems; 
    public List<GameObject> InventoryObjects; 
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
    public InventoryItem selectedInventoryItem;
    private SpriteRenderer handSpriteRenderer;
    private SpriteRenderer itemSpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        InventoryItems = new List<InventoryItem>();
        InventoryObjects = new List<GameObject>();
        // Hand
        front_hand = GameObject.Find("male_arm_front");
        handSpriteRenderer = front_hand.GetComponent<SpriteRenderer>();

        // Bow
        InventoryItem bow = new InventoryItem();
        bow.Sprite = bowSprite;
        bow.HitDamage = 1;
        bow.itemName = "bow";
        InventoryItems.Add(bow);
        Bow = new GameObject("Bow");
        Bow.AddComponent<SpriteRenderer>();
        Bow.AddComponent<Bow>(); 
        Bow.GetComponent<SpriteRenderer>().sprite = bowSprite;
        Bow.GetComponent<SpriteRenderer>().flipY = true;
        Bow.SetActive(false);
        InventoryObjects.Add(Bow);

        // Sword
        InventoryItem sword = new InventoryItem();
        sword.Sprite = swordSprite;
        sword.HitDamage = 2;
        sword.itemName = "sword";
        InventoryItems.Add(sword);
        Sword = new GameObject("Sword");
        Sword.AddComponent<SpriteRenderer>();
        Sword.GetComponent<SpriteRenderer>().sprite = swordSprite;
        Sword.AddComponent<Sword>(); 
        Sword.SetActive(false);
        InventoryObjects.Add(Sword);
        Sword.GetComponent<SpriteRenderer>().flipY = true;

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
        Pickaxe.GetComponent<SpriteRenderer>().flipY = true;
        Pickaxe.SetActive(true);
        InventoryObjects.Add(Pickaxe);

        // Block
        InventoryItem block = new InventoryItem();
        block.Sprite = blockSprite;
        block.Places = true;
        InventoryItems.Add(block);
        block.itemName = "block";
        Block = new GameObject("Block");
        Block.AddComponent<SpriteRenderer>();
        Block.GetComponent<SpriteRenderer>().sprite = blockSprite;
        Block.GetComponent<SpriteRenderer>().flipY = true;
        Block.SetActive(false);
        InventoryObjects.Add(Block);

        // Empty
        InventoryItem item_5 = new InventoryItem();
        GameObject object_5 = new GameObject("Block");
        InventoryItems.Add(item_5);
        InventoryObjects.Add(object_5);
        InventoryItem item_6 = new InventoryItem();
        GameObject object_6 = new GameObject("Block");
        InventoryItems.Add(item_6);
        InventoryObjects.Add(object_6);
        InventoryItem item_7 = new InventoryItem();
        GameObject object_7 = new GameObject("Block");
        InventoryItems.Add(item_7);
        InventoryObjects.Add(object_7);

        // Etc
        activeItem = Pickaxe;
        selectedInventoryItem = pickaxe;
        activeItem.transform.rotation = new Quaternion(0, 0, 0, 0);
        itemSpriteRenderer = activeItem.GetComponent<SpriteRenderer>();
        InventoryIcons();
    }

    public void switchToItem(int activeItemSlot)
    {
        activeItem.SetActive(false);
        activeItem = InventoryObjects[activeItemSlot];
        selectedInventoryItem = InventoryItems[activeItemSlot];
        activeItem.SetActive(true);
        itemSpriteRenderer = activeItem.GetComponent<SpriteRenderer>();

    }

    void UpdateHandItemPosition()
    {
        Vector3 handPosition = front_hand.transform.position;
        Quaternion handRotation = front_hand.transform.rotation;
        float playerDirection = front_hand.transform.lossyScale.x;
        float handWidth = handSpriteRenderer.size.x;
        float handHeight = handSpriteRenderer.size.y;
        float itemWidth = itemSpriteRenderer.size.x;
        float itemHeight = itemSpriteRenderer.size.y;
        Vector3 handSizeAdjustments = new Vector3(handWidth * -playerDirection, -handHeight, 0);
        Vector3 itemSizeAdjustments = new Vector3(itemWidth / 2.4f * playerDirection, itemHeight / 2.35f, 0);
        activeItem.transform.position = handPosition + handSizeAdjustments + itemSizeAdjustments;
        // Quaternion rotationQuaternion = handRotation;
        // rotationQuaternion.z = rotationQuaternion.z - playerDirection * 30;
        //Debug.Log(handRotation.z);
        //handRotation.z = -handRotation.z;
        activeItem.transform.rotation = handRotation;
        Vector3 activeItemScale = activeItem.transform.localScale;
        Vector3 updatedItemScale = new Vector3(-playerDirection * Mathf.Abs(activeItemScale.x), Mathf.Abs(activeItemScale.y), activeItemScale.z);
        activeItem.transform.localScale = updatedItemScale;
    }

    void InventoryIcons()
    {
        // Add inventory icons here
        GameObject slot_0 = GameObject.Find("InventorySlot (0)");
        GameObject slot_1 = GameObject.Find("InventorySlot (1)");
        GameObject slot_2 = GameObject.Find("InventorySlot (2)");
        GameObject slot_3 = GameObject.Find("InventorySlot (3)");
        GameObject slot_4 = GameObject.Find("InventorySlot (4)");
        GameObject slot_5 = GameObject.Find("InventorySlot (5)");
        GameObject slot_6 = GameObject.Find("InventorySlot (6)");
        GameObject slot_0_go = new GameObject("Slot0");
        slot_0_go.AddComponent<SpriteRenderer>();
        slot_0_go.GetComponent<SpriteRenderer>().sprite = bowSprite;
        slot_0_go.transform.position = slot_0.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHandItemPosition();
    }
}
