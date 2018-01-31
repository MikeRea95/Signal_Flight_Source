using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour {

    public Image img;
    public AnimationCurve curve;
    public GameObject child;

    private void Start() {
        if (child.activeSelf == false)
            child.SetActive(true);
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string scene) {
        StartCoroutine(FadeOut(scene));
    }

    IEnumerator FadeIn() {
        Time.timeScale = 1f;
        float t = 1f;

        while(t > 0f) {
            t -= Time.unscaledDeltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            yield return null;
        }
    }

    IEnumerator FadeOut(string scene) {
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
