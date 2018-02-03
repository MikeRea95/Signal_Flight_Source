using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealthRing : MonoBehaviour
{

    public float speed;
    public float range;
    public GameObject Player;
    public GameObject meSprite;

    // Deactivate the sprite immediately.
    private void Start() {
        meSprite.SetActive(false);
    }

    // Continuously grow until a maximum size is reached, the destroy this GameObject.
    private void Update() {
        transform.localScale += new Vector3(speed * Time.deltaTime, speed * Time.deltaTime, speed * Time.deltaTime);
        if (transform.localScale.y > range) {
            Destroy(gameObject);
        }
    }

    // Show the stealth ship if the player hits the stealth ring.
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject == Player) {
            meSprite.SetActive(true);
            meSprite.GetComponent<ShipMarker>().birthday = Time.time;
        }
    }
}
