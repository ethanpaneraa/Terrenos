using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with the player
        if (collision.gameObject.CompareTag("zombie"))
        {
            Zombie zombie = collision.gameObject.GetComponent<Zombie>(); 
            zombie.zombieHealth -= 75; 
            Destroy(this.gameObject); 
        }

        else if (collision.gameObject.CompareTag("ground")) {
            Destroy(this.gameObject);
        }


        
    }



}
