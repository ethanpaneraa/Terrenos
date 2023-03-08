using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class HealthBar : MonoBehaviour
{
    public Slider slider; 
    public int prevNumZombies = 0; 

    public void setHealth(int Health) {
        slider.value = Health; 
    }

    public void setMaxHealth(int Health) {
        slider.maxValue = Health; 
        slider.value = Health; 
    }


    private void Update() {
        GameObject[] zombies = GameObject.FindGameObjectsWithTag("zombie");

        int numZombies = zombies.Length;

        if (numZombies < prevNumZombies) {
            int currHealth = (int) slider.value;
            currHealth += 20;
            setHealth(currHealth);
        }

        prevNumZombies = numZombies;

    }

}
