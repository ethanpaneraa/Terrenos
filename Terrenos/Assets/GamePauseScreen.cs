using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GamePauseScreen : MonoBehaviour
{
    private bool gamePaused = false; 
    public void continueGame() {
        gameObject.SetActive(false);
        gamePaused = false; 

    }

    public void setGamePaused() {
        gameObject.SetActive(true);
        gamePaused = true; 
    }

    public void quitGame() {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }


    public bool getGamePausedState() {
        return gamePaused; 
    }
}

// test