using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealthRingClean : MonoBehaviour {

    public GameObject ring;
    public GameObject ship;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(ring == null && ship == null)
        {
            Destroy(gameObject); 
        }
	}
}
