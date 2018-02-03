using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputName : MonoBehaviour {

    public GameObject mainMenu;

    // Upon pressing enter while entering the player's name, PlayerName is updated and main menu is opened.
    public void enterName(string name) {
        PlayerPrefs.SetString("PlayerName", name);
        MainMenu.playerName = name;
        mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
