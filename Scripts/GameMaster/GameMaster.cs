using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    public static GameMaster instance;
    public GameOver gameOver;
    public LevelComplete levelComplete;
    public float totalTime = 0f;
    public bool countTime = true;

    // Create static reference to non-static class, allowing for direct reference to this object.
    private void Start() {
        if(instance != null) {
            Debug.LogError("More than one GameMaster script in scene!");
            Destroy(gameObject);
        }
        else {
            instance = this;
            StartCoroutine(timer());
        }
    }

    // A timer used for counting how long the player plays the game. This is displayed in the end screen.
    private IEnumerator timer() {
        while (true) {
            if (countTime) {
                totalTime += Time.deltaTime;
            }
            yield return null;
        }
    }

    // Pause the game and cause a lose state.
    public void GameOver(GameOverCause cause) {
        Time.timeScale = 0f;
        gameOver.gameOver(cause);
    }

    // Pause the game and cause a win state.
    public void LevelComplete() {
        Time.timeScale = 0f;
        levelComplete.levelComplete();
    }
}
