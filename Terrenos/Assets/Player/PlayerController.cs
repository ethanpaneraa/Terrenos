using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpHeight = 4;
    public bool onGround = true;
    public float horizontalMovement;
    public float verticalMovement;
    public float experiencePoints = 0;
    public float healthPoints = 10;
    public bool hit = false;
    public bool place = false;
    private Animator anim;
    private Rigidbody2D rigidBody;

    public Sprite blockSprite;
    private SpriteRenderer spriteRenderer;
    private SpriteRenderer[] childSpriteRenderers;

    private CapsuleCollider2D capsuleCollider;
    private Vector2 mousePos;
    public WorldGeneration worldGenerator;
    public GamePauseScreen gamePauseScreen;

    private AudioSource audioSource;
    public AudioClip hitSound;

    // Player stats
    public int playerHealth = 100;
    public int playerMana = 50; 
    public float movementSpeed = 2;
    public int attackDamage = 15; 
    public HealthBar HealthBar; 
    public ManaBar ManaBar; 
    public XpBar XpBar;
    public int inventorySlot = 2;
    public Inventory inventory;
    public bool HoldingBow = false; 
    public bool HoldingSword = false;
    public Bow bow; 
    public bool playerCanShoot; 
    public bool playerShootVolley; 
    public bool playerCanHeavyAttack; 
    

    //private float timeBetweenAttacks;
    //public float startTimeBetweenAttacks;
    //public Transform attackPos;
    //public LayerMask whatIsEnemies;
    //public float attackRange; 
    //public int inflictDamage; 



    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<Bow>(); 
        bow = this.gameObject.GetComponent<Bow>(); 
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        //transform.position = new Vector2(0, WorldGeneration.worldHeight + capsuleCollider.size.y);
        HealthBar.setMaxHealth(playerHealth); 
        ManaBar.setMaxMana(playerMana);
        childSpriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalMovement = Input.GetAxis("Horizontal") * movementSpeed;
        verticalMovement = Input.GetAxisRaw("Jump");

        hit = Input.GetMouseButton(0) && !hit;
        place = Input.GetKey(KeyCode.P) && !place;
        InventorySlot();

        // Behavior when player is hitting
        if (hit)
        {
            worldGenerator.RemoveBlock(mousePos);
        }

        // Behavior when player is placing???
        if (place)
        {
            //worldGenerator.PlaceBlock("placedBlock", "ground", blockSprite, mousePos);
        }

        if (onGround && verticalMovement > 0.1)
        {
            // Gets rid of health and mana when you jump
            verticalMovement = jumpHeight;
        }
        else
        {
            verticalMovement = rigidBody.velocity.y;
        }
        rigidBody.velocity = new Vector2(horizontalMovement, verticalMovement);

        if (horizontalMovement > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (horizontalMovement < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);

        }   

    }

    private void Update()
    {


        if (playerHealth <= 0){
            Destroy(this.gameObject); 
        }

        if (playerMana < 10) {
            playerCanShoot = false; 
        }

        if (playerMana < 20) {
            playerShootVolley = false; 
        } 

        if (playerMana < 15) {
            playerCanHeavyAttack = false; 
        }

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.x = Mathf.RoundToInt(mousePos.x);
        mousePos.y = Mathf.RoundToInt(mousePos.y);
        anim.SetBool("hit", hit);
        anim.SetFloat("horizontal", horizontalMovement);

        if (Input.GetKeyDown(KeyCode.X)) {
            XpBar.setXP(XpBar.currentXP += 10); 
        }

        if (Input.GetMouseButtonDown(0) && HoldingBow && playerMana >= 10 && bow.canFire) {
            playerMana -= 10;
            ManaBar.setMana(playerMana);
        }


        if (Input.GetKeyDown(KeyCode.Q) && HoldingBow && playerMana >= 20 && bow.canFireVolley) {
            playerMana -= 20;
            ManaBar.setMana(playerMana);
        }

        if (Input.GetKeyDown(KeyCode.Q) && playerMana >= 15 && HoldingSword) {
            playerMana -= 15;
            ManaBar.setMana(playerMana); 
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ground"))
        {
            onGround = false;
        }    
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("ground"))
        {
            onGround = true;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with the player
        if (collision.gameObject.CompareTag("zombie"))
        {
            // Get the player's health component
            playerHealth -= 20; 
            HealthBar.setHealth(playerHealth);
            foreach (SpriteRenderer spriteRenderer in childSpriteRenderers)
            {
                spriteRenderer.color = Color.red;
            }
            audioSource.PlayOneShot(hitSound);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        foreach (SpriteRenderer spriteRenderer in childSpriteRenderers)
        {
            spriteRenderer.color = Color.white;
        }
    }


    private void InventorySlot()
    {
        if (Input.GetKey(KeyCode.Alpha1) && inventorySlot != 0)
        {
            HoldingBow = true; 
            playerCanShoot = true; 
            playerShootVolley = true; 
            HoldingSword = true; 
            inventorySlot = 0;
        }
        else if (Input.GetKey(KeyCode.Alpha2) && inventorySlot != 1)
        {
            HoldingBow = false; 
            HoldingSword = true; 
            playerCanHeavyAttack = true; 
            inventorySlot = 1;

        }
        else if (Input.GetKey(KeyCode.Alpha3) && inventorySlot != 2)
        {
            HoldingBow = false; 
            HoldingSword = false; 
            inventorySlot = 2;
        }
        else if (Input.GetKey(KeyCode.Alpha4) && inventorySlot != 3)
        {
            HoldingBow = false; 
            HoldingSword = false; 
            inventorySlot = 3;
        }
        else if (Input.GetKey(KeyCode.Alpha5) && inventorySlot != 4)
        {
            HoldingBow = false; 
            HoldingSword = false; 
            inventorySlot = 4;
        }
        else if (Input.GetKey(KeyCode.Alpha6) && inventorySlot != 5)
        {
            HoldingBow = false; 
            HoldingSword = false; 
            inventorySlot = 5;
        }
        else if (Input.GetKey(KeyCode.Alpha7) && inventorySlot != 6)
        {
            HoldingBow = false;
            HoldingSword = false;  
            inventorySlot = 6;
        }
        else
        {
            return;
        }

        inventory.switchToItem(inventorySlot);
        // Debug.Log(inventory.InventoryItems[inventorySlot].itemName);
    }
}
