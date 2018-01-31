using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    public static GameMaster instance;
    public GameOver gameOver;
    public LevelComplete levelComplete;
    public float totalTime = 0f;
    public bool countTime = true;

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

    IEnumerator timer() {
        while (true) {
            if (countTime) {
                totalTime += Time.deltaTime;
            }
            yield return null;
        }
    }

    public void GameOver(GameOverCause cause) {
        Time.timeScale = 0f;
        gameOver.gameOver(cause);
    }

    public void LevelComplete() {
        Time.timeScale = 0f;
        levelComplete.levelComplete();
    }
}
