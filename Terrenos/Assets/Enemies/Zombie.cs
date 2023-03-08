using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveSpeed = 2f; // the speed at which the Zombie moves towards the player
    public float jumpForce = 9f; // the force with which the Zombie jumps
    public float minJumpInterval = 1f; // the minimum time interval between jumps
    public float maxJumpInterval = 9f; // the maximum time interval between jumps
    private Transform player; // a reference to the player's Transform component
    private Rigidbody2D rb; // a reference to the Zombie's Rigidbody2D component
    //private float jumpTimer = 0f; // a timer to track when the Zombie can jump again
    private float nextJumpTime = 0f; // the time when the Zombie will jump next
    public int zombieHealth = 150; 
    public int zombieDamage = 20;
    public AudioClip zombieDeath;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("player").transform; // find the player GameObject and get its Transform component
        rb = GetComponent<Rigidbody2D>(); // get the Zombie's Rigidbody2D component
        // calculate the time for the next jump
        nextJumpTime = Time.time + Random.Range(minJumpInterval, maxJumpInterval);
        jumpForce = 9f;    }

    private void Update()
    {

        if (zombieHealth <= 0) {
//<<<<<<< Updated upstream
//            // float currMana = manabar.GetCurrMana(); 
//            // currMana += 10;
//            // manabar.setMana((int)currMana); 
//=======
            AudioSource.PlayClipAtPoint(zombieDeath, rb.position);
//>>>>>>> Stashed changes
            Destroy(this.gameObject); 
        }

        // calculate the direction to move towards the player
        Vector3 direction = player.position - transform.position;
        direction.Normalize();

        // move towards the player
        transform.position += direction * moveSpeed * Time.deltaTime;

        // jump at random intervals
        if (Time.time >= nextJumpTime)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);

            // calculate the time for the next jump
            nextJumpTime = Time.time + Random.Range(minJumpInterval, maxJumpInterval);
        }
    }
     

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "arrow")
            {
                // Get the direction from the arrow to the zombie
                Vector2 direction = transform.position - col.transform.position;

                // Normalize the direction vector to get a unit vector
                direction = direction.normalized;

                Vector2 pointOfImpact = col.contacts[0].point;

                // Add a force to the zombie in the opposite direction of the arrow
                
                GetComponent<Rigidbody2D>().AddForceAtPosition(direction * 200, pointOfImpact, ForceMode2D.Impulse);

                // col.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            }
    }   

    
}
