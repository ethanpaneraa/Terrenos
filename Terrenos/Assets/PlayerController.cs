using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 2;
    public float jumpHeight = 4;
    public bool onGround = true;
    public float horizontalMovement;
    public float verticalMovement;
    public float experiencePoints = 0;
    public float healthPoints = 10;
    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalMovement = Input.GetAxis("Horizontal") * movementSpeed;
        verticalMovement = Input.GetAxisRaw("Jump");
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
