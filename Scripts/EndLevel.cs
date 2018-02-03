using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour {

    public GameObject player;

    // If the player has planets left, cause a lose state. Else, a win state.
	private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject == player) {
            if(PlanetsLeft.instance.getRemainingPlanets() != 0) {
                GameMaster.instance.GameOver(GameOverCause.Player_Fled);
            }
            else {
                GameMaster.instance.LevelComplete();
            }
        }
    }
}
