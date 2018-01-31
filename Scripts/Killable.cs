using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Killable : MonoBehaviour {

    public GameObject deathParticles;

    public bool dead = false;

    public abstract void Die();
}
