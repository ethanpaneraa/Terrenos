using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public float climbSpeed;
    private bool onLadder;
    public GameObject player;
    private Rigidbody2D rb;
    private float gravityScale;
    // Start is called before the first frame update
    void Start()
    {
        onLadder = false;
        rb = player.GetComponent<Rigidbody2D>();
        gravityScale = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        // going up
        if (Input.GetKeyDown(KeyCode.UpArrow) && onLadder)
        {
            rb.velocity = new Vector2(rb.velocity.x, climbSpeed);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) && onLadder)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }

        // going down
        if (Input.GetKeyDown(KeyCode.DownArrow) && onLadder)
        {
            rb.velocity = new Vector2(rb.velocity.x, -climbSpeed);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow) && onLadder)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.gravityScale = 0;
        onLadder = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        rb.gravityScale = gravityScale;
        onLadder = false;
    }
}
