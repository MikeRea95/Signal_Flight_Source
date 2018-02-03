using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMarker : MonoBehaviour {

    public float birthday;
    public float fade;

    // Occassionally display a darker version of the ship.
	private void Update () {
        float age = Time.time - birthday;
        gameObject.GetComponent<SpriteRenderer>().color *= (fade - age) / fade;
        if(age >= fade) {
            Destroy(gameObject);
        }
	}
}
