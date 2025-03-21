using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int checkpointNumber;
    public bool isActiveCheckpoint;

    private Light passLight;
    private RaceController raceController;

    // Use this for initialization
    void Start()
    {
        passLight = GetComponentInChildren<Light>();
        raceController = GetComponentInParent<RaceController>();
    }

    private void Update()
    {
        if (isActiveCheckpoint)
        {
            // Mathf.Sin(Time.time) brings a cool effect of intensity increasing and decreasing
            // Multiplier for Time.time defines the frequency
            // Multiplier for the whole Sin value defines the amount (Sin gets values between -1 and 1)
            passLight.intensity = 4 + Mathf.Sin(Time.time * 2) * 2;
            passLight.color = Color.red;
        }
        else
        {
            passLight.intensity -= 0.1f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if current checkpoint is active, and if the passed object was the player's ship
        if (isActiveCheckpoint && other.name == "Spaceship")
        {
            passLight.intensity = 50;
            passLight.color = Color.green;
            // Call a function in the RaceController
            raceController.CheckpointPassed();
            isActiveCheckpoint = false;
        }
    }
}
