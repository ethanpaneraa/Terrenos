using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class XpBar : MonoBehaviour
{

    public Slider slider; 
    public int currentLevel = 1;
    public int currentMaxXP = 100; 
    public int currentXP = 0; 
    public int prevNumZombies = 0; 
    public LevelUpBackground LevelUpBackground; 


    public void setXP(int XP) {
        slider.value = XP; 
    }



    public void levelUp() {
        currentLevel += 1;
        currentMaxXP += 100; 
        currentXP = 0; 
        slider.maxValue = currentMaxXP; 
    }

    

    void Update() {

        GameObject[] zombies = GameObject.FindGameObjectsWithTag("zombie");

        int numZombies = zombies.Length;

        if (numZombies < prevNumZombies) {
            // Update the currentXP variable
            currentXP += 50;
            setXP(currentXP); 
        }


        if (currentXP == currentMaxXP) {
            setXP(0);  
            levelUp(); 
            LevelUpBackground.showLevelUpScreen(); 
        }

        prevNumZombies = numZombies;

    }

    void Start() {
        slider.maxValue = 100; 
    }

}
