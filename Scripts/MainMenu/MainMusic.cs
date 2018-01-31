using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMusic : MonoBehaviour {

    public float birthday;
    public float wait = 300;
    public GameObject next;
    public float current;
	// Use this for initialization
	void Start () {
        birthday = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        current = Time.time - birthday;

        if (current > wait)
        {
            next.GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }
	}
}
