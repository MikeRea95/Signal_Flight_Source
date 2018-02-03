using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    public GameObject gameOverUI;
    public Text sadFeelsText;
    public Text hintText;

    // Update the player's lose condition stats, then set the game over screen texts to the appropriate message.
    public void gameOver(GameOverCause cause) {
        updateStats(cause);
        sadFeelsText.text = setSadFeelsText(cause);
        hintText.text = setHintText(cause);
        gameOverUI.SetActive(true);
    }

    // Update the player's lose condition stats depending on why they lost.
    private void updateStats(GameOverCause cause) {
        PlayerPrefs.SetFloat("Time", PlayerPrefs.GetFloat("Time", 0f) + GameMaster.instance.totalTime);
        switch (cause) {
            case GameOverCause.Player_Died:
                PlayerPrefs.SetInt("Deaths", PlayerPrefs.GetInt("Deaths", 0) + 1);
                break;
            case GameOverCause.Player_Fled:
                PlayerPrefs.SetInt("Cowardly", PlayerPrefs.GetInt("Cowardly", 0) + 1);
                break;
            case GameOverCause.Planet_Died:
                PlayerPrefs.SetInt("FullPlanetsEaten", PlayerPrefs.GetInt("FullPlanetsEaten", 0) + 1);
                break;
        }
    }

    // Set the dramatic text to hint to why the player lost.
    private string setSadFeelsText(GameOverCause cause) {
        string str = "You shouldn't see this. Let me know if you do.";
        switch (cause) {
            case GameOverCause.Player_Died:
                str = "They outsmarted you...";
                break;
            case GameOverCause.Player_Fled:
                str = "You gave in to cowardice...";
                break;
            case GameOverCause.Planet_Died:
                str = "You couldn't save them...";
                break;
        }
        return str;
    }

    // Give the player a hint as to what to do next time they play.
    private string setHintText(GameOverCause cause) {
        string str = "You shouldn't see this. Let me know if you do.";
        switch (cause) {
            case GameOverCause.Player_Died:
                str = "Try distracting them before entering stealth mode.";
                break;
            case GameOverCause.Player_Fled:
                str = "You have to save every planet to progress.";
                break;
            case GameOverCause.Planet_Died:
                str = "A planet was killed before you could warn them.";
                break;
        }
        return str;
    }
}
