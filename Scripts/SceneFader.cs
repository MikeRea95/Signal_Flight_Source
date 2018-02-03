using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour {

    public Image img;
    public AnimationCurve curve;
    public GameObject child;

    // Fade in. If scenefader is disabled, re-enable. 
    // Scenefaders are typically disabled because it blocks the game view during development.
    private void Start() {
        if (child.activeSelf == false)
            child.SetActive(true);
        StartCoroutine(FadeIn());
    }

    // Public method to fade out to a new scene.
    public void FadeTo(string scene) {
        StartCoroutine(FadeOut(scene));
    }

    // Reactivate time and fade into the new scene.
    private IEnumerator FadeIn() {
        Time.timeScale = 1f;
        float t = 1f;

        while(t > 0f) {
            t -= Time.unscaledDeltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            yield return null;
        }
    }

    // Deactivate time and fade out of the current scene, then load the new scene.
    // If the new scene could not be found, load the error scene.
    private IEnumerator FadeOut(string scene) {
        float t = 0f;

        while(t < 1f) {
            t += Time.unscaledDeltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            yield return null;
        }

        if (Application.CanStreamedLevelBeLoaded(scene)){
            SceneManager.LoadScene(scene);
        }
        else {
            Debug.LogError(scene + " could not be found!");
            SceneManager.LoadScene("IAMERROR");
        }
    }

}
