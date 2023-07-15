using UnityEngine;

public class ScrewTracker : MonoBehaviour
{
    public int screwsRequired = 10; // Number of screws required to trigger activation
    private int screwsDrilled = 0; // Number of screws drilled so far
    public GameObject triggerObject; // Object to activate once screwsRequired is reached

    // This method is called whenever a screw is drilled
    public void DrillScrew()
    {
        screwsDrilled++;

        if (screwsDrilled >= screwsRequired)
        {
            triggerObject.SetActive(true); // Activate the trigger on the objecgt
        }
    }
}
