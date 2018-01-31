using UnityEngine;

public class LevelComplete : MonoBehaviour {

    public GameObject levelCompleteUI;
    public SceneFader sceneFader;
    public bool endGame;

	public void levelComplete() {
        levelCompleteUI.SetActive(true);
        PlayerPrefs.SetInt("LevelsComplete", PlayerPrefs.GetInt("LevelsComplete", 0) + 1);
        PlayerPrefs.SetFloat("Time", PlayerPrefs.GetFloat("Time", 0f) + GameMaster.instance.totalTime);
    }

    public void Continue() {
        if (!endGame) {
            sceneFader.FadeTo("Level" + (PlayerPrefs.GetInt("LevelsComplete") + 1));
        }
        else {
            sceneFader.FadeTo("EndOfGame");
        }
    }
}
