using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpMovement : MonoBehaviour {

    public float speed = 100;

    // Continuously rotate the warp zone.
    private void Update () {
        transform.Rotate(Vector3.right * Time.deltaTime * speed);  
        transform.Rotate(Vector3.forward * Time.deltaTime * speed * 10);
	}
}
