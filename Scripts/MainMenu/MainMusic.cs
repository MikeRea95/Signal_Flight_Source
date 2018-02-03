using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMusic : MonoBehaviour {

    public float birthday;
    public float wait = 300;
    public GameObject next;
    public float current;

    // Reset birthday.
    private void Start () {
        birthday = Time.time;
	}
	
    // Update time since spawn and play secret music after 5 minutes.
	private void Update () {
        current = Time.time - birthday;

        if (current > wait) {
            next.GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }
	}
}
