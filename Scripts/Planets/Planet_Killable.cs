using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet_Killable : Killable {

    public SpriteRenderer[] spriteRenderers;
    public CircleCollider2D planetCollider;
    public ParticleSystem planetParticleSystem;
    public Planet planet;

    public override void Die() {
        if (dead)
            return;
        dead = true;

        GameObject deathParticlesObject = (GameObject)Instantiate(deathParticles, transform.position, Quaternion.identity);
        deathParticlesObject.GetComponent<ParticleSystem>().Play();
        Destroy(deathParticlesObject, 1f);
        if (!planet.gotSignal) {
            GameMaster.instance.GameOver(GameOverCause.Planet_Died);
            return;
        }

        PlayerPrefs.SetInt("EmptyPlanetsEaten", PlayerPrefs.GetInt("EmptyPlanetsEaten", 0) + 1);
        foreach(SpriteRenderer sr in spriteRenderers) {
            sr.enabled = false;
        }
        planetCollider.enabled = false;
        planetParticleSystem.Stop();
        StartCoroutine(waitForParticleDeath());
    }

    IEnumerator waitForParticleDeath() {
        while(planetParticleSystem.particleCount > 0) {
            yield return null;
        }

        Destroy(gameObject);
    }

}
