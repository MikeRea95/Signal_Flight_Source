using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class error : MonoBehaviour {

    public AudioSource muzak;

    private void Start() {
        PlayerPrefs.DeleteAll();
        StartCoroutine(closeAfterSong());
    }

    IEnumerator closeAfterSong() {
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
