using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class error : MonoBehaviour {

    public AudioSource muzak;

    // If the player manages to reach the error screen, delete their save.
    private void Start() {
        PlayerPrefs.DeleteAll();
        StartCoroutine(closeAfterSong());
    }

    // Once the song is done, close the game.
    // First while loop is fix to avoid the screen quitting too early.
    private IEnumerator closeAfterSong() {
        while (!muzak.isPlaying) {
            yield return null;
        }
        while (muzak.isPlaying) {
            yield return null;
        }

        Debug.Log("Bye!");
        Application.Quit();
    }
}
