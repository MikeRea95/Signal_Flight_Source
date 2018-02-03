using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetsCounter : MonoBehaviour {

    public static int planetsInScene;
    public static int planetSpritesSet;

    // Establish how many planets are in this level. Other scripts reference this.
    private void Start() {
        planetsInScene = transform.childCount;
        planetSpritesSet = 0;
    }
}
