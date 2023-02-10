using UnityEngine;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 2;
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

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        transform.position = new Vector2(0, WorldGeneration.worldHeight + capsuleCollider.size.y);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalMovement = Input.GetAxis("Horizontal") * movementSpeed;
        verticalMovement = Input.GetAxisRaw("Jump");
        hit = Input.GetMouseButton(0) && !hit;
        place = Input.GetMouseButton(1) && !place;
        if (hit)
        {
            worldGenerator.RemoveBlock(mousePos);
        }
        if (place)
        {
            worldGenerator.PlaceBlock("placedBlock", "ground", blockSprite, mousePos);
        }

        if (onGround && verticalMovement > 0.1)
        {
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
