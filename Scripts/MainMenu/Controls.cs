using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {

    public GameObject mainMenu;

    // Go back to the main menu.
    public void Back() {
        mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
