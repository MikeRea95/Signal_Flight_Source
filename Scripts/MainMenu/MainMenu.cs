using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class MainMenu : MonoBehaviour {

    public GameObject deleteSave;
    public GameObject controls;
    public Text welcomeMessage;
    public static string playerName = "";

    // Change the welcome message based on the player's name, and whether or not they've been here before.
    private void OnEnable() {
        if(playerName == "") {
            playerName = "MISSINGNO.";
        }
        if (PlayerPrefs.GetInt("HasVisited", 0) == 1) {
            welcomeMessage.text += Environment.NewLine + playerName + "_";
        }
        else {
            welcomeMessage.text = "Hello_pilot_" + Environment.NewLine + playerName + "_";
            PlayerPrefs.SetInt("HasVisited", 1);
        }
    }

    // Load the next level the player hasn't finished.
    public void StartGame() {
        SceneManager.LoadScene("Level" + (PlayerPrefs.GetInt("LevelsComplete") + 1));
    }

    // Open delete save menu.
    public void DeleteSave() {
        deleteSave.SetActive(true);
        gameObject.SetActive(false);
    }

    // Close the game.
    public void QuitGame() {
        Debug.Log("Quit!");
        Application.Quit();
    }

    // Open the controls menu.
    public void Controls() {
        controls.SetActive(true);
        gameObject.SetActive(false);
    }
}
