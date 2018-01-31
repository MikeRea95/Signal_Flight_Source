using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetsCounter : MonoBehaviour {

    public static int planetsInScene;
    public static int planetSpritesSet;

    private void Start() {
        planetsInScene = transform.childCount;
        planetSpritesSet = 0;
    }

}
