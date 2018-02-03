using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

    public Transform player;
    public float distance = 10f;
    public float speed;
    public float scroll;

    // TODO: This'll probably get changed to FixedUpdate when the player switches to addforce.
    // This did not get done.
    // Allows for the main camera to be scrolled in and out.
	private void Update () {
        if (Input.GetKey(KeyCode.E)) {
            distance -= speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Q)) {
            distance += speed * Time.deltaTime;
        }
        float msw = Input.GetAxis("Mouse ScrollWheel");
        if (0 != msw) {
            distance -= scroll * Time.deltaTime * msw;
        }
        distance = Mathf.Clamp(distance, 2, 31);
        transform.position = player.position - new Vector3(0, 0, distance);
	}
}
