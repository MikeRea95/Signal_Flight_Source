using UnityEngine;
using UnityEngine.SceneManagement;

public class DeleteSave : MonoBehaviour {

    public GameObject mainMenu;

    public void Yes() {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void No() {
        mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
