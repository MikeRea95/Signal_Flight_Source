using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeriodicEmit : MonoBehaviour {

    public bool emit;
    public GameObject ring;
    public float period;
    public Player player;
    public SpriteRenderer playerSprite;
    public float speedReduction;

    private float counter = 1;

	void Update () {
        counter += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space)) {
            emit = !emit;
            if (!emit) {
                player.translateSpeed *= speedReduction;
                playerSprite.color *= speedReduction;
                playerSprite.color += new Color(0, 0, 0, 255);
                return;
            }
            else {
                player.translateSpeed /= speedReduction;
                playerSprite.color /= speedReduction;
            }
        }

        if (!emit)
            return;

        if (counter > period)
        {
            GameObject.Instantiate(ring, transform.position, transform.rotation);
            counter = 0;
        }
	}
}
