using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealthRingClean : MonoBehaviour {

    public GameObject ring;
    public GameObject ship;

    // Garbage collection.
    private void Update () {
		if(ring == null && ship == null) {
            Destroy(gameObject); 
        }
	}
}
