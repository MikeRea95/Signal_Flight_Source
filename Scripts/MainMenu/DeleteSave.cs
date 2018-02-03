using UnityEngine;
using UnityEngine.SceneManagement;

public class DeleteSave : MonoBehaviour {

    public GameObject mainMenu;

    // Delete save and reload main menu.
    public void Yes() {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Return to the main menu.
    public void No() {
        mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
