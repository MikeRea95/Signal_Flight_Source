using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Killable : MonoBehaviour {

    // This is the base class for all inherited killable classes.
    // Anything that causes death will call this.

    public GameObject deathParticles;

    public bool dead = false;

    public abstract void Die();
}
