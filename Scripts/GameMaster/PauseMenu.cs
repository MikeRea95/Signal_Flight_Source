using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject ui;
    public SceneFader sceneFader;
    public string menuSceneName = "MainMenu";

    // Make sure time is set to normal, in case of outside influence.
    private void Start() {
        Time.timeScale = 1f;

        if(ui.activeSelf) {
            Toggle();
        }
    }

    // Press escape to turn on/off the pause menu.
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            Toggle();
        }
    }

    // Toggle the time scale, pause menu, and the Game Master's timer.
    public void Toggle() {
        ui.SetActive(!ui.activeSelf);

        if(ui.activeSelf) {
            Time.timeScale = 0f;
            GameMaster.instance.countTime = false;
        }
        else {
            Time.timeScale = 1f;
            GameMaster.instance.countTime = true;
        }
    }

    // Reload current scene. 
    public void Retry() {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    // Go back to the main menu.
    public void Menu() {
        sceneFader.FadeTo(menuSceneName);
    }
}
