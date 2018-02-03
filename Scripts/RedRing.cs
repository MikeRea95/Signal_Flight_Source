using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedRing : MonoBehaviour {

    public float speed;
    public float range;
    public float birthday;
    public Vector3 target;
    public SpriteRenderer sprite;

    // Continuously grow larger, until a max distance is reached. Then destroy the ring.
	private void Update () {
        transform.localScale += new Vector3(speed * Time.deltaTime, speed * Time.deltaTime, speed * Time.deltaTime);
        sprite.color -= new Color(0, 0, 0, Time.deltaTime/2);
        if (transform.localScale.y > range) {
            Destroy(gameObject);
        }
    }

    // Signal an object if the ring hits something.
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Chaser") {
            other.gameObject.GetComponent<Alien>().signal(target, birthday);
        }
        if (other.gameObject.tag == "Scout") {
            other.gameObject.GetComponent<Scout>().signal(target, birthday);
        }
        if (other.gameObject.tag == "Turret") {
            other.gameObject.GetComponent<Turret>().signal(transform.position);
        }
    }
}
