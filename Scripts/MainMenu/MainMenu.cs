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

    public void StartGame() {
        SceneManager.LoadScene("Level" + (PlayerPrefs.GetInt("LevelsComplete") + 1));
    }

    public void DeleteSave() {
        deleteSave.SetActive(true);
        gameObject.SetActive(false);
    }

    public void QuitGame() {
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void Controls() {
        controls.SetActive(true);
        gameObject.SetActive(false);
    }
}
