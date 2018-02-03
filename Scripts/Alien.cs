using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour {

    public Vector3 target;
    public bool chase = false;
    public float rotation = 0.5f;
    public float thrust;
    public bool smart;
    public float targetBirthday;
    public GameObject Player;
    Vector3 dir;

    // Assure aliens are always on the same z axis as the player.
    private void Start () {
        if (transform.position.z != 0)
            transform.position = new Vector3(transform.position.x,transform.position.y,0);
    }
	
    // Face the player and move towards them.
	private void Update () {
        if(chase) { 
            Vector3 vectorToTarget = target - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, rotation * Time.deltaTime);
        }
    }

    // Move.
    private void FixedUpdate() {
        if (chase) {
            transform.position += thrust * Vector3.Normalize(dir)* Time.deltaTime;
        }
    }

    // Signal towards where the smart alien believes the player is.
    public void signal(Vector3 xy, float birthday) {
        chase = true;
        if ((smart && birthday > targetBirthday) || !smart) {
            target = xy;
            dir = xy - transform.position;
            targetBirthday = birthday;
        }
    }

    // Kill the player if collision occurs.
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject == Player)
            collision.gameObject.GetComponent<Killable>().Die();
    }

    // Try to move towards the player.
    private void OnTriggerStay2D(Collider2D collision) {
        if(smart && collision.gameObject == Player) {
            chase = true;
            target = Player.GetComponent<Transform>().position;
            dir = Player.GetComponent<Transform>().position - transform.position;
        }
    }
}
