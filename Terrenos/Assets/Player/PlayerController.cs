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
    public Sprite blockSprite;
    private Animator anim;
    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRenderer;
    private CapsuleCollider2D capsuleCollider;
    private Vector2 mousePos;
    public WorldGeneration worldGenerator;
    public GamePauseScreen gamePauseScreen; 
    // Player stats
    public int playerHealth = 100;
    public int playerMana = 50; 
    public float movementSpeed = 2;
    public int attackDamage = 15; 
    public HealthBar HealthBar; 
    public ManaBar ManaBar; 
    public XpBar XpBar; 

    //private float timeBetweenAttacks;
    //public float startTimeBetweenAttacks;
    //public Transform attackPos;
    //public LayerMask whatIsEnemies;
    //public float attackRange; 
    //public int inflictDamage; 



    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        //transform.position = new Vector2(0, WorldGeneration.worldHeight + capsuleCollider.size.y);
        HealthBar.setMaxHealth(playerHealth); 
        ManaBar.setMaxMana(playerMana); 

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalMovement = Input.GetAxis("Horizontal") * movementSpeed;
        verticalMovement = Input.GetAxisRaw("Jump");

        hit = Input.GetMouseButton(0) && !hit;
        place = Input.GetKey(KeyCode.P) && !place;
        if (hit)
        {
            worldGenerator.RemoveBlock(mousePos);
        }
        if (place)
        {
            //worldGenerator.PlaceBlock("placedBlock", "ground", blockSprite, mousePos);
        }

        if (onGround && verticalMovement > 0.1)
        {
            // Gets rid of health and mana when you jump
            playerHealth -= 10; 
            playerMana -= 10; 
            HealthBar.setHealth(playerHealth); 
            ManaBar.setMana(playerMana); 
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
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.x = Mathf.RoundToInt(mousePos.x);
        mousePos.y = Mathf.RoundToInt(mousePos.y);
        anim.SetBool("hit", hit);

        if (Input.GetKeyDown(KeyCode.X)) {
            XpBar.setXP(XpBar.currentXP += 10); 
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
}
