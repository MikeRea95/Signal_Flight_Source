using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMarker : MonoBehaviour {

    public float birthday;
    public float fade;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        float age = Time.time - birthday;
        gameObject.GetComponent<SpriteRenderer>().color *= (fade - age) / fade;
        if(age >= fade)
        {
            Destroy(gameObject);
        }
	}
}
