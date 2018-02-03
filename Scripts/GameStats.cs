using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStats : MonoBehaviour {

    public Text deaths;
    public Text cowardly;
    public Text fullPlanetsEaten;
    public Text emptyPlanetsEaten;
    public Text time;

    // Initialize all the player stats.
    private void Start() {
        SetDeaths();
        SetCowardly();
        SetTime();
        SetFullPlanetsEaten();
        SetEmptyPlanetsEaten();
    }

    // Every method in this region updates the appropriate player stat and determines the text color based on how well the player did.
    #region SET STATS
    private void SetDeaths() {
        deaths.text = PlayerPrefs.GetInt("Deaths", 0).ToString();
        if(PlayerPrefs.GetInt("Deaths") >= 20) {
            deaths.color = Color.red;
        }
        else if(PlayerPrefs.GetInt("Deaths") >= 10) {
            deaths.color = Color.yellow;
        }
        else {
            deaths.color = Color.green;
        }
    }

    private void SetCowardly() {
        cowardly.text = PlayerPrefs.GetInt("Cowardly", 0).ToString();
        if (PlayerPrefs.GetInt("Cowardly") >= 2) {
            cowardly.color = Color.red;
        }
        else if(PlayerPrefs.GetInt("Cowardly") == 1) {
            cowardly.color = Color.yellow;
        }
        else {
            cowardly.color = Color.green;
        }
    }

    private void SetTime() {
        float timer = PlayerPrefs.GetFloat("Time", 0);
        float minutes = Mathf.Floor(timer / 60);
        Debug.Log(minutes);
        float seconds = timer % 60;

        time.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        //time.text = string.Format("{0:00.00}", PlayerPrefs.GetFloat("Time", 0));
        if (PlayerPrefs.GetFloat("Time") >= 600f) {
            time.color = Color.red;
        }
        else if (PlayerPrefs.GetFloat("Time") == 300f) {
            time.color = Color.yellow;
        }
        else {
            time.color = Color.green;
        }
    }
    
    private void SetFullPlanetsEaten() {
        fullPlanetsEaten.text = PlayerPrefs.GetInt("FullPlanetsEaten", 0).ToString();
        if(PlayerPrefs.GetInt("FullPlanetsEaten") >= 5) {
            fullPlanetsEaten.color = Color.red;
        }
        else if(PlayerPrefs.GetInt("FullPlanetsEaten") >= 3) {
            fullPlanetsEaten.color = Color.yellow;
        }
        else {
            fullPlanetsEaten.color = Color.green;
        }
    }

    private void SetEmptyPlanetsEaten() {
        emptyPlanetsEaten.text = PlayerPrefs.GetInt("EmptyPlanetsEaten", 0).ToString();
        if (PlayerPrefs.GetInt("EmptyPlanetsEaten") >= 100) {
            emptyPlanetsEaten.color = Color.red;
        }
        else if (PlayerPrefs.GetInt("EmptyPlanetsEaten") >= 50) {
            emptyPlanetsEaten.color = Color.yellow;
        }
        else {
            emptyPlanetsEaten.color = Color.green;
        }
    }
    #endregion
}
