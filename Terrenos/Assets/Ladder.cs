using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public float climbSpeed;
    private bool onLadder;
    private GameObject player;
    private Rigidbody2D rb;
    private float gravityScale;
    // Start is called before the first frame update
    void Start()
    {
        onLadder = false;
        player = FindObjectOfType<PlayerController>().gameObject;
        rb = player.GetComponent<Rigidbody2D>();
        gravityScale = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (onLadder)
        {
            if (Input.GetAxisRaw("Jump") == 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, Input.GetAxis("Vertical") * climbSpeed);
            } else
            {
                rb.velocity = new Vector2(rb.velocity.x, climbSpeed);
            }
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
