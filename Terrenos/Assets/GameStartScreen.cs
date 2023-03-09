using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 
using UnityEngine;

public class GameStartScreen : MonoBehaviour
{
    public Canvas toolbar;
    private bool gameStarted = false;

    private void Start()
    {
        toolbar.gameObject.SetActive(false);
    }
    // gets rid of the main menu screen
    public void StartGame() {
        gameObject.SetActive(false);
        toolbar.gameObject.SetActive(true);
        gameStarted = true; 
    }

    // Happens when player presses the quit button
    public void QuitGame() {
        Application.Quit();
    }

    public bool getGameState() {
        return gameStarted; 
    }

}
