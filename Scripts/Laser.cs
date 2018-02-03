using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    public float speed;
    public Vector3 dir;
    public float range;
    public float age = 0;
    public GameObject Player;

    // Continuously move forward.
	private void Update () {
        transform.position += speed * dir * Time.deltaTime;
        age += Time.deltaTime;
        if(age > range)
        {
            Destroy(gameObject);
        }
	}

    // Kill the player.
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject == Player) {
            Player.GetComponent<Killable>().Die();
        }
    }
}
