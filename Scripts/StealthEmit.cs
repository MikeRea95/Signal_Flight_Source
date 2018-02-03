﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealthEmit : MonoBehaviour {
    public GameObject ring;
    public float period;
    public float counter=0;
    public GameObject Player;

    // Emit the stealth ring.
    private void Update () {
        counter += Time.deltaTime;
        if (counter > period) {
            counter = 0;
            GameObject baby = GameObject.Instantiate(ring, transform.position, transform.rotation);
            baby.SetActive(true);
            baby.GetComponentInChildren<StealthRing>().Player = Player;
        }
    }
}
