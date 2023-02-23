using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{

    public float attackRadius = 1.5f;
    public float cooldownTime = 0.5f;

    private float lastAttackTime;

    private void Update()
    {
        // Check if player can attack again
        if (Time.time - lastAttackTime > cooldownTime)
        {
            // Check if the player presses the attack button (assumes "Fire1" input is used)
            if (Input.GetButtonDown("Fire1"))
            {
                // Attack nearby enemies with "zombie" tag
                Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, attackRadius);
                foreach (Collider2D collider in colliders)
                {
                    if (collider.CompareTag("zombie"))
                    {
                        // Do damage to enemy here (you'll need to implement this yourself)
                        Debug.Log("here"); 
                    }
                }

                // Update last attack time
                lastAttackTime = Time.time;
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
