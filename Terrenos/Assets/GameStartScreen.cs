using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 
using UnityEngine;

public class GameStartScreen : MonoBehaviour
{
    
    public bool gameStarted = true;

    // gets rid of the main menu screen
    public void StartGame() {
        gameObject.SetActive(false);
        gameStarted = true; 
    }

    // Happens when player presses the quit button
    public void QuitGame() {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false; 
    }

}
