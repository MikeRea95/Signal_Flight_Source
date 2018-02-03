using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Threat : MonoBehaviour {

    public GameObject Player;
    private float difficulty;

    // Initialize the difficulty for this level. Scales consistently.
    private void Start() {
        difficulty = PlayerPrefs.GetInt("LevelsComplete")/5 + 1;
    }

    // Move towards the right at a speed determined by the difficulty.
    private void Update () {
        transform.position += Vector3.right * Time.deltaTime * difficulty;
	}

    // Kill anything this GameObject touches.
    private void OnTriggerEnter2D(Collider2D other) {
        Killable kill = other.GetComponent<Killable>();
        if(kill != null) {
            kill.Die();
        }
    }
}
