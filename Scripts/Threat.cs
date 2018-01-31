using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Threat : MonoBehaviour {

    public GameObject Player;
    private float difficulty;

    private void Start() {
        difficulty = PlayerPrefs.GetInt("LevelsComplete")/5 + 1;
    }

    void Update () {
        transform.position += Vector3.right * Time.deltaTime * difficulty;
	}

    void OnTriggerEnter2D(Collider2D other) {
        Killable kill = other.GetComponent<Killable>();
        if(kill != null) {
            kill.Die();
        }
    }
}
