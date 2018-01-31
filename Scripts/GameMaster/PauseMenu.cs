using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject ui;

    public SceneFader sceneFader;

    public string menuSceneName = "MainMenu";

    private void Start() {
        Time.timeScale = 1f;

        if(ui.activeSelf) {
            Toggle();
        }
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            Toggle();
        }
    }

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

    public void Retry() {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu() {
        sceneFader.FadeTo(menuSceneName);
    }
}
