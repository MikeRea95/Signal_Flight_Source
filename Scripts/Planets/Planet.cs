using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {

    public bool gotSignal = false;
    public GameObject ring;
    public bool evil;
    public Vector3 target;
    public GameObject Spawn;
    public GameObject redRing;
    public float birthday = 0;
    float count = 0;
    public float period = 2;
    public GameObject Player;
    public SpriteRenderer sprite;

    // Make sure the planet's particle system isn't running, then update the planet's sprite.
    private void Start () {
        gameObject.GetComponent<ParticleSystem>().Stop();
        modifySprite();
	}

    // Get the sprite array. Then, start calculating which sprite to use. 
    // Get the sine of the levels complete, so it's consistent between saves and retries.
    // Multiply this sine by the number of sprites in the array to allow for all sprites to be used.
    // Get the absolute value to not get negative numbers.
    // Mod by the sprite array length to not go out of bounds.
    private void modifySprite() {
        Sprite[] spriteArray = PlanetSprites.instance.planetSprites;
        float baseFloat = Mathf.Sin(PlayerPrefs.GetInt("LevelsComplete")) * spriteArray.Length;
        int index = (int)baseFloat;
        index = Mathf.Abs(index);
        index += PlanetsCounter.planetSpritesSet;
        index %= spriteArray.Length;
        sprite.sprite = spriteArray[index];

        float scale = baseFloat / 50;

        transform.position = new Vector3(transform.position.x, transform.position.y, index);
        transform.localScale += new Vector3(scale, scale, scale);

        PlanetsCounter.planetSpritesSet++;
    }

    // Start the escape ships and release planet's warning signal.
    public void signal(Vector3 inPos, float inBirth) {
        if (gotSignal == false) {
            PlanetsLeft.instance.OneFewerPlanet();
            gotSignal = true;
            gameObject.GetComponent<ParticleSystem>().Play();
            Instantiate(ring, transform.position, transform.rotation);

            // Play animation of ships flying away.
            if (evil) {
                GameObject a = Instantiate(Spawn, transform.position + new Vector3(-3, 0, 0), transform.rotation);
                if(a.tag == "Chaser")
                    a.GetComponent<Alien>().Player = Player;
                if(a.tag == "Turret")
                    a.GetComponent<Turret>().Player = Player;
                a = Instantiate(Spawn, transform.position + new Vector3(3, 0, 0), transform.rotation);
                if (a.tag == "Chaser")
                    a.GetComponent<Alien>().Player = Player;
                if (a.tag == "Turret")
                    a.GetComponent<Turret>().Player = Player;
            }
        }
        if (inBirth > birthday) {
            birthday = inBirth;
            target = inPos;
        }
    }

	// Emit a red ring if evil.
	private void Update () {
        if (evil && gotSignal) {
            count += Time.deltaTime;
            if (count > period) {
                count = 0;
                GameObject newRing = Instantiate(redRing, transform.position, transform.rotation);
                newRing.GetComponent<RedRing>().target = this.target;
                newRing.GetComponent<RedRing>().birthday = this.birthday;
            }
        }
    }
}
