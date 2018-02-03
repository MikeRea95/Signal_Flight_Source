using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scout : MonoBehaviour
{

    public float birthday = 0;
    public bool alerted;
    public Vector3 target;
    public float period;
    float count;
    public GameObject redRing;
    public GameObject Player;

    // Initialize variables.
    private void Start() {
        Player = GameObject.Find("Player");
        count = period;
    }

    // Gain signal from rings.
    public void signal(Vector3 inPos, float inBirth) {
        if (inBirth > birthday) {
            birthday = inBirth;
            alerted = true;
            target = inPos;
        }
    }

    // Start alerting other alien ships.
    private void Update() {
        if (alerted) {
            count += Time.deltaTime;
            if (count > period) {
                count = 0;
                GameObject newRing = Instantiate(redRing, transform.position, transform.rotation);
                newRing.GetComponent<RedRing>().target = this.target;
                newRing.GetComponent<RedRing>().birthday = this.birthday;
            }
        }
    }

    // Kill the player.
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject == Player)
            collision.gameObject.GetComponent<Killable>().Die();
    }

}
