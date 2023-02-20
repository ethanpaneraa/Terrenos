using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class LevelUpBackground : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player; 
    public PlayerController playerScript; 
    public Text currentMaxHealth; 
    public Text currentMaxMana; 
    public Text currentAttackDamage;
    public Text currentMovementSpeed; 
    public Text currentMiningSpeed; 


    private void Start() {
        playerScript = player.GetComponent<PlayerController>(); 
    }


    public void UpgradeHealth() {
        playerScript.HealthBar.slider.maxValue = playerScript.HealthBar.slider.maxValue + 100; 
        playerScript.playerHealth = (int) playerScript.HealthBar.slider.maxValue; 
        playerScript.HealthBar.setHealth(playerScript.playerHealth); 
        gameObject.SetActive(false); 
        currentMaxHealth.text = "Max Health: " + $"{playerScript.HealthBar.slider.maxValue}"; 
    }

    public void UpgradeMana() {
        playerScript.ManaBar.slider.maxValue = playerScript.ManaBar.slider.maxValue + 50; 
        playerScript.playerMana = (int) playerScript.ManaBar.slider.maxValue; 
        playerScript.ManaBar.setMana(playerScript.playerMana); 
        gameObject.SetActive(false); 
        currentMaxMana.text = "Max Mana: " + $"{playerScript.ManaBar.slider.maxValue}"; 
    }

    public void UpgradeAttack() {
        playerScript.attackDamage += 15; 
        gameObject.SetActive(false); 
        currentAttackDamage.text = "Base Attack Damange: " + $"{playerScript.attackDamage}"; 
    }
    

    public void UpgradeMovement() {
        playerScript.movementSpeed += 1; 
        gameObject.SetActive(false); 
        currentMovementSpeed.text = "Movement Speed: " + $"{playerScript.movementSpeed}"; 
    }

    
    public void showLevelUpScreen() {
        gameObject.SetActive(true); 
    }


}
