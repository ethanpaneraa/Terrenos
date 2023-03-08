using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ManaBar : MonoBehaviour
{
    
    public Slider slider; 
    public int prevNumZombies = 0; 

    public void setMana(int Mana) {

        if (Mana <= 0) {
            slider.value = 0; 
        }
        else {
            
            slider.value = Mana; 
        }

    }

    public void setMaxMana(int Mana) {

        slider.maxValue = Mana;
        slider.value = Mana; 

    }

    private void Update() {

        GameObject[] zombies = GameObject.FindGameObjectsWithTag("zombie");

        int numZombies = zombies.Length;

        if (numZombies < prevNumZombies) {
            // Update the currentXP variable
            int currMana = (int) slider.value; 
            currMana += 10;
            setMana(currMana); 
        }
        
        prevNumZombies = numZombies;

    }



}
