using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector2 move;
    float space;
    bool grounded;
    bool ladderTouch;
    Rigidbody2D rb;
    Transform tr;

    BoxCollider2D BoxCollider2D;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        grounded = false;
        tr = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        move.x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move.x * 5, rb.velocity.y);
        if (Input.GetKeyDown("space") && grounded && !ladderTouch)
        {
            rb.velocity += new Vector2(0, 10);
            grounded = false;
        }
        if (ladderTouch)
        {
            if (Input.GetKeyDown("space"))
            {
                rb.velocity = new Vector2(rb.velocity.x, 5);
            }
            if(Input.GetKeyUp("space"))
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Level")
        {
            grounded = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Ladder")
        {
            ladderTouch = true;
            rb.gravityScale = 0;
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("here asf");
        ladderTouch = false;
        rb.gravityScale = 2;
    }
}
