using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ManaBar : MonoBehaviour
{
    
    public Slider slider; 

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



}
