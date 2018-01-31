using UnityEngine;
using UnityEngine.UI;

public class PlanetsLeft : MonoBehaviour {

    private int totalPlanets;
    private int planetsLeft;
    public Text planetsLeftText;
    public static PlanetsLeft instance;

    private void Start() {
        if(instance != null) {
            Debug.LogError("More than one PlanetsLeft script in scene!");
            Destroy(gameObject);
        }
        else {
            instance = this;
        }

        totalPlanets = PlanetsCounter.planetsInScene;
        planetsLeft = totalPlanets;
        changeTextColor();

        planetsLeftText.text = planetsLeft + "/" + totalPlanets;
    }

    public void OneFewerPlanet() {
        planetsLeft--;
        changeTextColor();

        planetsLeftText.text = planetsLeft + "/" + totalPlanets;
    }

    private void changeTextColor() {
        if(planetsLeft == 0) {
            planetsLeftText.color = Color.green;
        }
        else if(planetsLeft <= totalPlanets / 2) {
            planetsLeftText.color = Color.yellow;
        }
        else{
            planetsLeftText.color = Color.red;
        }
    }

    public float getRemainingPlanets() {
        return (float)planetsLeft / totalPlanets;
    }

}
