using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour {

    public GameObject player;

	void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject == player) {
            if(PlanetsLeft.instance.getRemainingPlanets() != 0f) {
                GameMaster.instance.GameOver(GameOverCause.Player_Fled);
            }
            else {
                GameMaster.instance.LevelComplete();
            }
        }
    }
}
