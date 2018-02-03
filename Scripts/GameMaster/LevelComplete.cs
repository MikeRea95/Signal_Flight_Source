using UnityEngine;

public class LevelComplete : MonoBehaviour {

    public GameObject levelCompleteUI;
    public SceneFader sceneFader;
    public bool endGame;

    // Turn on the win screen and update player stats.
	public void levelComplete() {
        levelCompleteUI.SetActive(true);
        PlayerPrefs.SetInt("LevelsComplete", PlayerPrefs.GetInt("LevelsComplete", 0) + 1);
        PlayerPrefs.SetFloat("Time", PlayerPrefs.GetFloat("Time", 0f) + GameMaster.instance.totalTime);
    }

    // Load the next level, or the end of the game.
    public void Continue() {
        if (!endGame) {
            sceneFader.FadeTo("Level" + (PlayerPrefs.GetInt("LevelsComplete") + 1));
        }
        else {
            sceneFader.FadeTo("EndOfGame");
        }
    }
}
