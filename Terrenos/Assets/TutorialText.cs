using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class TutorialText : MonoBehaviour
{
    // Start is called before the first frame update

    public string [] tutorialTextArray;
    public int currIndex = 0; 
    public Text tutText; 
    private bool firstText = false; 

    void Start() {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && firstText == false) {
            tutText.text = "You can move around with 'A' and 'D' and 'SPACE' to Jump \nPress 'E' to see tool controls \nPress 'T' to remove tutorial text";
        }

        if (Input.GetKeyUp(KeyCode.E)) {
            firstText = true; 
        }

        if (Input.GetKeyDown(KeyCode.E) && firstText) {
            tutText.text = "You can switch between items using the number row. \nEquip the sword and bow to damage enemies \nEquip the Pixaxe to destory blocks \nEquip a block to place it! \nPress 'T' to end the tutorial"; 
        }

        if (Input.GetKeyDown(KeyCode.T)) {
            Destroy(this.gameObject); 
        }
    }
}
