using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float rotateSpeed;
    public float translateSpeed;
    public float maxX;
    public float maxY;
    public ParticleSystem playerParticleSystem;

    // These ended up not being used. Forces are still weird.
    [Header("Don't touch these.")]
    public float maxSpeed;
    public float engineStrength;
    public Rigidbody2D rb;

    // Press W to move forward and emit the flames. A and D to turn left and right, respectively.
    private void Update() {
        if (Input.GetKey(KeyCode.W)) {
            if(!playerParticleSystem.isEmitting)
                playerParticleSystem.Play();
            transform.Translate(Vector3.right * Time.deltaTime * translateSpeed, Space.Self);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -maxX, maxX),
                Mathf.Clamp(transform.position.y, -maxY, maxY), 
                0);
        }
        else {
            if(playerParticleSystem.isPlaying)
                playerParticleSystem.Stop();
        }
        if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(new Vector3(0, 0, -Time.deltaTime * rotateSpeed));
        }
        else if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(new Vector3(0, 0, Time.deltaTime * rotateSpeed));
        }
    }

    // This is unused.
    private void FixedUpdate() {
        if (rb.velocity.magnitude > maxSpeed) {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }
}
