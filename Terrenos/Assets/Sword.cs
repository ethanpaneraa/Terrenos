using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{

    public float attackRadius = 1.5f;
    public float cooldownTime = 0.2f;

    private float lastAttackTime;

    public GameObject player; 
    public GameObject XPBar; 
    public PlayerController PlayerController; 
    public XpBar experienceBar; 

    private void Start() {
        attackRadius = 3.5f; 
        cooldownTime = 0.75f; 
        player = GameObject.FindGameObjectWithTag("player"); 
        PlayerController = player.GetComponent<PlayerController>(); 
    }


    private void Update()
    {
        // Check if player can attack again
        if (Time.time - lastAttackTime > cooldownTime)
        {
            // Check if the player presses the attack button (assumes "Fire1" input is used)
            if (Input.GetButtonDown("Fire1"))
            {
                // Check the direction the sword is facing
                Vector2 swordDirection = transform.right;
                if (transform.localScale.x < 0) // flip sword if player is facing left
                {
                    swordDirection = -transform.right;
                }

                // Attack nearby enemies with "zombie" tag in front of the sword
                Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, attackRadius);
                foreach (Collider2D collider in colliders)
                {
                    if (collider.CompareTag("zombie"))
                    {
                        // Check if zombie is in front of the sword
                        Vector2 zombieDirection = collider.transform.position - transform.position;
                        if (Vector2.Dot(zombieDirection.normalized, swordDirection.normalized) > 0.5f)
                        {
                            // Debug.Log("here"); 
                            // Do damage to enemy here (you'll need to implement this yourself)
                            // Debug.Log(collider); 
                            Zombie zombie = collider.gameObject.GetComponent<Zombie>(); 
                            zombie.zombieHealth -= 60; 
                            // if (zombie.zombieHealth <= 0) {
                            //     int currXP = experienceBar.currentXP; 
                            //     experienceBar.setXP(currXP + 75); 
                            // }
                            zombie.makeRed();
                        }
                    }
                }

                // Update last attack time
                lastAttackTime = Time.time;
            }

            else if (Input.GetKeyDown(KeyCode.Q) && PlayerController.HoldingSword) {

                Vector2 swordDirection = transform.right;
                if (transform.localScale.x < 0) // flip sword if player is facing left
                {
                    swordDirection = -transform.right;
                }

                // Attack nearby enemies with "zombie" tag in front of the sword
                Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, attackRadius);
                foreach (Collider2D collider in colliders)
                {
                    if (collider.CompareTag("zombie"))
                    {
                        // Check if zombie is in front of the sword
                        Vector2 zombieDirection = collider.transform.position - transform.position;
                        if (Vector2.Dot(zombieDirection.normalized, swordDirection.normalized) > 0.5f)
                        {
                            // Debug.Log("here"); 
                            // Do damage to enemy here (you'll need to implement this yourself)
                            // Debug.Log(collider); 
                            Zombie zombie = collider.gameObject.GetComponent<Zombie>(); 
                            zombie.zombieHealth -= 200; 

                        }
                    }
                }
            }
        }
    }

    // private void OnDrawGizmosSelected()
    // {
    //     // Draw attack radius in scene view
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawWireSphere(transform.position, attackRadius);
    // }



}
