using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginGame : MonoBehaviour {

    public GameObject nameInput;
    public GameObject mainMenu;

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
