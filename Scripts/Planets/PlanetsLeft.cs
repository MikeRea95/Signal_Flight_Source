using UnityEngine;
using UnityEngine.UI;

public class PlanetsLeft : MonoBehaviour {

    private int totalPlanets;
    private int planetsLeft;
    public Text planetsLeftText;
    public static PlanetsLeft instance;

    // Create static reference to non-static class, allowing for direct reference to this object.
    // Then update the goal for the level.
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

    // Reduce the number of planets needing warning by 1.
    public void OneFewerPlanet() {
        planetsLeft--;
        changeTextColor();

        planetsLeftText.text = planetsLeft + "/" + totalPlanets;
    }

    // Tell the player visually how well they're doing.
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

    // Return how many planets are left.
    public int getRemainingPlanets() {
        return planetsLeft;
    }

}
