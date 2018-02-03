using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginGame : MonoBehaviour {

    public GameObject nameInput;
    public GameObject mainMenu;

    // Get the player name. If there is none, go to name input. If there is a player name, go to the main menu.
    public void beginGame() {
        MainMenu.playerName = PlayerPrefs.GetString("PlayerName", "");
        if (MainMenu.playerName == "") {
            nameInput.SetActive(true);
        }
        else {
            mainMenu.SetActive(true);
        }
        gameObject.SetActive(false);
    }
}
