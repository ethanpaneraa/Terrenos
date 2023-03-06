using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    // Start is called before the first frame update
    // Reference to the arrow prefab
    public GameObject arrowPrefab;

    // Reference to the arrow spawn point
    public Transform arrowSpawnPoint;

    // The force applied to the arrow when it's fired

    // The cooldown time between shots
    public float shotCooldown = 0.5f;

    // The time when the next shot is available
    private float nextShotTime = 0f;

    private GameObject player; 


    private PlayerController PlayerController; 
    public float arrowSpeed = 17f; 

    public bool canFire = true; 

    public bool canFireVolley = true; 

    Quaternion rotation; 

    void Start() {
        arrowPrefab = GameObject.Find("Arrow"); 
        player = GameObject.FindGameObjectWithTag("player"); 
        PlayerController = player.GetComponent<PlayerController>(); 
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 direction = player.transform.right;

        if (player.transform.localScale.x > 0) {
            direction = -direction; 
            rotation = Quaternion.Euler(0,0, -225); 
        }

        else {
            rotation = Quaternion.Euler(0,0, -45); 
        }

        if (Time.time >= nextShotTime && Input.GetButtonDown("Fire1") && PlayerController.playerCanShoot && PlayerController.HoldingBow){
            // instantiate the arrow prefab in the middle of the player's facing direction
            GameObject arrow = Instantiate(arrowPrefab, player.transform.position + (Vector3)direction * 0.5f, Quaternion.identity);


            // rotate the arrow to face the player's direction
            arrow.transform.right = direction;

            arrow.transform.rotation = rotation; 

            // shoot the arrow in the direction the player is facing
            Rigidbody2D arrowRigidbody = arrow.GetComponent<Rigidbody2D>();
            arrowRigidbody.velocity = direction * arrowSpeed;

         }


         else if (Time.time >= nextShotTime && PlayerController.playerShootVolley && Input.GetKeyDown(KeyCode.Q) && PlayerController.HoldingBow) {

            for (int i = 0; i < 3; i++) {
                GameObject arrow = Instantiate(arrowPrefab, player.transform.position + (Vector3)direction * 0.5f, Quaternion.identity);


                // rotate the arrow to face the player's direction
                arrow.transform.right = direction;

                arrow.transform.rotation = rotation; 

                // shoot the arrow in the direction the player is facing
                Rigidbody2D arrowRigidbody = arrow.GetComponent<Rigidbody2D>();
                arrowRigidbody.velocity = direction * arrowSpeed;
            }
         }

    }
    
}
