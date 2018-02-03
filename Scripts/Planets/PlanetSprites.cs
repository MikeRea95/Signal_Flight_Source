using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSprites : MonoBehaviour {

    public static PlanetSprites instance;
    public Sprite[] planetSprites;

    // Create static reference to non-static class, allowing for direct reference to this object.
    private void Start() {
        if (instance != null) {
            Debug.LogError("More than one PlanetSprites script in scene!");
            Destroy(gameObject);
        }
        else {
            instance = this;
        }
    }
}
