using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Killable : Killable {

    // If an enemy is killed, create the death particles and destroy the GameObject.
    public override void Die() {
        if (dead)
            return;
        dead = true;

        GameObject deathParticlesObject = (GameObject)Instantiate(deathParticles, transform.position, Quaternion.identity);
        deathParticlesObject.GetComponent<ParticleSystem>().Play();
        Destroy(deathParticlesObject, 1f);
        Destroy(gameObject);
    }
}
